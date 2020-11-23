

using System;
using System.Collections.Generic;

namespace EServicesCommon.Common
{
    public class ResponseObject<T>
    {
        #region Properties
        public T Result { get; set; }
        public bool IsStopExecuting { get; set; } = false;
        public bool IsValid { get; set; }
        public Exception Exception { get; set; }
        public ResponseState Type { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        #endregion

        public void SetValidationError(ValidationError validationError)
        {
            if (validationError != null)
            {
                List<ValidationError> errorsCollection = new List<ValidationError>();
                errorsCollection.Add(validationError);

                SetValidationErrorList(errorsCollection);
            }

        }

        public void SetValidationErrorList(List<ValidationError> validationErrors)
        {
            if (validationErrors != null && validationErrors.Count > 0)
            {
                this.ValidationErrors = validationErrors;
            }

            SetResponse(ResponseState.ValidationError);
        }

        public void SetExceptionResponse(Exception ex)
        {
            this.Exception = ex;
            SetResponse(ResponseState.Failure);
        }

        public void SetResponse(ResponseState state)
        {
            this.Type = state;
            this.IsValid = state == ResponseState.Success ? true : false;
            this.IsStopExecuting = state == ResponseState.Success ? false : true;
        }



    }
}
