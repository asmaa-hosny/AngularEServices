using System;


namespace EservicesDomain.Domain.DomainAgility
{
    public partial class VARIABLE
    {
        public byte[] OWNER_ID { get; set; }
        public string VAR_ID { get; set; }
        public decimal VERSION { get; set; }
        public short DYNAMIC { get; set; }
        public short VAR_TYPE { get; set; }
        public byte[] CATEGORY_ID { get; set; }
        public string DISPLAY_NAME { get; set; }
        public byte[] ENTITY_ID { get; set; }
        public Nullable<bool> USE_AS_SKIN_VARIABLE { get; set; }
        public string VAR_VALUE { get; set; }
        public bool IS_SECURE { get; set; }
    }
}
