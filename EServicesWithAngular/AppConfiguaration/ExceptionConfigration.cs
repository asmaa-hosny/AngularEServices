using EServicesWithAngular.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EServicesWithAngular.AppConfiguaration
{
    public static class ExceptionConfigration
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        
                       if(contextFeature.GetType().IsSubclassOf(typeof (BugException)))
                        {
                            //Send to TFS
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(contextFeature.Error));
                        }
                       else if (!contextFeature.GetType().IsSubclassOf(typeof(CustomException)))
                        {
                            //Send to TFSfg
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(contextFeature.Error));
                        }

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new BugException()));
                    }
                });
            });
        }
    }
}
