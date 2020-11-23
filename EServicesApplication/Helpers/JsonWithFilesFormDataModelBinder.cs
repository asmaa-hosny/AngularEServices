using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EServicesApplication.Helpers
{
    public class JsonWithFilesFormDataModelBinder : IModelBinder
    {
        private readonly IOptions<MvcNewtonsoftJsonOptions> _jsonOptions;
        private readonly FormFileModelBinder _formFileModelBinder;

        public JsonWithFilesFormDataModelBinder(IOptions<MvcNewtonsoftJsonOptions> jsonOptions, ILoggerFactory loggerFactory)
        {
            _jsonOptions = jsonOptions;
            _formFileModelBinder = new FormFileModelBinder(loggerFactory);
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            // Retrieve the form part containing the JSON
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.FieldName);
            if (valueResult == ValueProviderResult.None)
            {
                // The JSON was not found
                var message = bindingContext.ModelMetadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(bindingContext.FieldName);
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, message);
               

                var initialBody = bindingContext.HttpContext.Request.Body; // Workaround

                bindingContext.HttpContext.Request.EnableBuffering();
                var buffer = new byte[Convert.ToInt32(bindingContext.HttpContext.Request.ContentLength)];
                await bindingContext.HttpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                var json = Encoding.UTF8.GetString(buffer);
                bindingContext.HttpContext.Request.Body = initialBody;
                var modelFromBody = JsonConvert.DeserializeObject(json, bindingContext.ModelType, _jsonOptions.Value.SerializerSettings);
                bindingContext.Result = ModelBindingResult.Success(modelFromBody);
                return;
            }

            var rawValue = valueResult.FirstValue;

            // Deserialize the JSON
            var model = JsonConvert.DeserializeObject(rawValue, bindingContext.ModelType, _jsonOptions.Value.SerializerSettings);

            // Now, bind each of the IFormFile properties from the other form parts
            foreach (var property in bindingContext.ModelMetadata.Properties)
            {
                if (property.ModelType != typeof(IFormFile) && property.ModelType != typeof(ICollection<IFormFile>) && property.ModelType != typeof(IEnumerable<IFormFile>))
                    continue;

                var fieldName = property.BinderModelName ?? property.PropertyName;
                var modelName = fieldName;
                var propertyModel = property.PropertyGetter(bindingContext.Model);
                ModelBindingResult propertyResult;
                using (bindingContext.EnterNestedScope(property, fieldName, modelName, propertyModel))
                {
                    await _formFileModelBinder.BindModelAsync(bindingContext);
                    propertyResult = bindingContext.Result;
                }

                if (propertyResult.IsModelSet)
                {
                    // The IFormFile was sucessfully bound, assign it to the corresponding property of the model
                    property.PropertySetter(model, propertyResult.Model);
                }
                else if (property.IsBindingRequired)
                {
                    var message = property.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(fieldName);
                    bindingContext.ModelState.TryAddModelError(modelName, message);
                }
            }

            // Set the successfully constructed model as the result of the model binding
            bindingContext.Result = ModelBindingResult.Success(model);
        }
    }
}
