using EServicesCommon.Common;
using CommonLibrary.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace EServicesWithAngular.MiddleWare
{
    public class LoggingMiddleWare
    {
        readonly RequestDelegate _next;
        readonly ILoggerManager _logger;

        public LoggingMiddleWare(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("/api"))
            {
                var requestContext = new RequestContext
                {
                    CallerUsername = context.User.Identity.IsAuthenticated == true ? context.User.Identity.Name : "",
                    ContextId = Guid.NewGuid(),
                    IpAddress = context.Connection.RemoteIpAddress.ToString(),
                    MachineName = Environment.MachineName,
                    UserId = context.User.Identity.IsAuthenticated == true ? context.User.Identity.Name : "",
                    Culture = Thread.CurrentThread.CurrentCulture.Name,
                    RequestUrl = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)
                };

                using (this._logger.FormContext(EServicesCommon.Common.ContextKeys.CORRELATIONID, requestContext.ContextId.ToString()))
                {
                    using (this._logger.FormContext(EServicesCommon.Common.ContextKeys.MethodName, context.Request.Path))
                    {
                        context.Items[EServicesCommon.Common.ContextKeys.CORRELATIONID] = requestContext.ContextId;
                        this._logger.LogDebug("Start Executing", requestContext);
                        var sw = Stopwatch.StartNew();
                        await _next(context);
                        sw.Stop();
                        this._logger.LogDebug("Finish Executing in {0}", sw.Elapsed.TotalMilliseconds);
                    }
                }
            }
            else
            {
                await _next(context);
             }
        }

    }
}
