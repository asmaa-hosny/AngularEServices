using System;


namespace EservicesDomain.Attributes
{
    public class ExecludeAttribute : Attribute
    {
        private  bool _execluded;

        public ExecludeAttribute(bool execluded = true)
        {
            this._execluded = execluded;
        }

        public bool IsExecluded()
        {
            return _execluded;
        }

    }
}
