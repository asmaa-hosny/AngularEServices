using CommonLibrary.Logging;
using EServicesCommon.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EServicesWithAngular.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _config;

        public ExceptionMiddleWare(RequestDelegate next, ILoggerManager logger, IConfiguration configuaration)
        {
            _next = next;
            _logger = logger;
            _config = configuaration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                using (_logger.FormContext(ContextKeys.CORRELATIONID, Convert.ToString(context.Items[ContextKeys.CORRELATIONID])))
                {
                    using (_logger.FormContext(ContextKeys.MethodName, context.Request.Path))
                    {
                        _logger.LogError(ex.Message, ex);
                    }

                }
                await HandleExceptionAsync(ex, context);
            }
        }

        public async Task HandleExceptionAsync(Exception ex, HttpContext context)
         {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            bool isShowExceptionDetails = Convert.ToBoolean(_config["Core:ShowExceptionDetails"]);
            string exceptionMessage = "An unexpected fault happened. Try again later.";

            if (isShowExceptionDetails)
                exceptionMessage = ex.InnerException != null ? ex.InnerException.Message + System.Environment.NewLine + ex.StackTrace : ex.Message + System.Environment.NewLine + ex.StackTrace;

            var result = JsonConvert.SerializeObject(new { error = exceptionMessage });
            await context.Response.WriteAsync(result);
        }


    }
}
