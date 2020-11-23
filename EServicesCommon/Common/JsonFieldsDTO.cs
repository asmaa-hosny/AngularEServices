

namespace EServicesCommon.Common
{
    public class JsonFieldsDTO
    {
        public string FieldName { get; set; }

        public bool Editable { get; set; }

        public bool Visible { get; set; }

        public bool Required { get; set; }

        public bool IsAttachement { get; set; }

        //Not Implemented Yet
        public string Condition { get; set; }

        public string Pattern { get; set; }


    }
}
