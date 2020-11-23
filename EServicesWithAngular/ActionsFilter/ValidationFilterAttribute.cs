using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EServicesCommon.DI;
using CommonLibrary.Logging;
using EServicesCommon.Common;

namespace EServicesWithAngular.ActionsFilter
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
      

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var param = context.ActionArguments.SingleOrDefault(p => p.Value is BaseViewModel);
            //var logger = FactoryManager.Instance.Resolve<ILoggerManager>();

            //if (param.Value == null)
            //{
            //    context.Result = new BadRequestObjectResult($"Object  {param.Value}  is null");
            //    logger.LogError($"Object  {param.Value}  is null", null);
            //    return;
            //}
            //if (!context.ModelState.IsValid)
            //{
            //    var items = from ms in context.ModelState
            //                where ms.Value.Errors.Any()
            //                let fieldKey = ms.Key
            //                let errors = ms.Value.Errors
            //                from error in errors
            //                select (Key: fieldKey, ErrorMessage: error.ErrorMessage, ExceptionMessage: error.Exception.Message);
            //    context.Result = new BadRequestObjectResult(items);
            //    logger.LogError(JsonConvert.SerializeObject(items), null);
            //}
        }
    }

    public class ValidateModelAsyncFilter : IAsyncActionFilter
    {
       
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            List<ValidationError> errors = new List<ValidationError>();
            var logger = FactoryManager.Instance.Resolve<ILoggerManager>();
            if (context.ActionArguments.Count == 0)
            {
                errors.Add(new ValidationError() { Key = "Model_Empty", Message = "Model is empty" });
                if (errors.Count() > 0)
                {
                    logger.LogDebug("Model is not valid", errors);
                }
                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            if (!context.ModelState.IsValid)
            {
                var items = from ms in context.ModelState
                            where ms.Value.Errors.Any()
                            let fieldKey = ms.Key
                            let merrors = ms.Value.Errors
                            from error in merrors
                            select (Key: fieldKey, ErrorMessage: error.ErrorMessage, ExceptionMessage: error.Exception !=null? error.Exception.Message: error.ErrorMessage);

                if (items != null && items.Count() > 0) {
                    logger.LogDebug("Model is not valid", items);
                }
                context.Result = new BadRequestObjectResult(items);
                return;
            }
             await next();
        }
    }
}
