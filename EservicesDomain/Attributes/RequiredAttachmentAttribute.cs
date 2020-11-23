using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;


namespace EservicesDomain.Attributes
{
    public class RequiredAttachmentAttribute : RequiredAttribute
    {
        public short[] requiredForNodeIDs;

        public RequiredAttachmentAttribute() { }

        public RequiredAttachmentAttribute(short[] requiredForNodeIDs)
        {
            this.requiredForNodeIDs = requiredForNodeIDs;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
                return ValidationResult.Success;


            Object instance = context.ObjectInstance;
            Type type = instance.GetType();



            short NodeID = 0;
            PropertyInfo prop = type.GetProperty("NodeID");

            if (prop != null)
                NodeID = Convert.ToInt16(prop.GetValue(instance, null));

            if (value.GetType() == typeof(IFormFile[]) && (requiredForNodeIDs == null || requiredForNodeIDs.Contains(NodeID)))
            {
                if (((IEnumerable<IFormFile>)value).Count() == 1 && ((IEnumerable<IFormFile>)value).ElementAt(0) == null)
                    return new ValidationResult(getErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string getErrorMessage()
        {
            if (ErrorMessageResourceType
                != null)
            {
                ResourceManager rm = new ResourceManager(ErrorMessageResourceType);
                return rm.GetString(ErrorMessageResourceName);
            }
            else
                return ErrorMessage;
        }
    }
}
