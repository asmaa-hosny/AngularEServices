using System;


namespace EservicesDomain.Domain.DomainAgility
{
    public partial class LiveActivity
    {
        public byte[] JOB_ID { get; set; }
        public short EMBEDDED_PROCESS_COUNT { get; set; }
        public short NODE_ID { get; set; }
        public short SUB_NODE_ID { get; set; }
        public short ACTIVITY_STATUS { get; set; }
        public short AUTOMATIC { get; set; }
        public byte[] DATA_PROCESS_ID { get; set; }
        public bool DELEGATED { get; set; }
        public System.DateTime DUE_DATE { get; set; }
        public decimal EXPECTED_COST { get; set; }
        public int EXPECTED_DURATION_IN_SECONDS { get; set; }
        public decimal FIXED_COST { get; set; }
        public bool LIBRARY { get; set; }
        public short MACHINE_ID { get; set; }
        public System.DateTime MONITORING_DUE_DATE { get; set; }
        public string NODE_NAME { get; set; }
        public short PRIORITY { get; set; }
        public byte[] PROCESS_ID { get; set; }
        public string PROCESS_NAME { get; set; }
        public short SECURITY { get; set; }
        public short SKILL { get; set; }
        public System.DateTime SLA_STATUS2_DATE { get; set; }
        public System.DateTime SLA_STATUS3_DATE { get; set; }
        public System.DateTime SLA_STATUS4_DATE { get; set; }
        public System.DateTime SLA_STATUS5_DATE { get; set; }
        public int TYPE { get; set; }
        public byte[] UNIQUE_ID { get; set; }
        public short POOLID { get; set; }
        public short USE_ADV_WORKFLOW_RULES { get; set; }
        public decimal VERSION { get; set; }
        public string ASSOCIATED_FILE { get; set; }
        public string HELP_TEXT { get; set; }
        public byte[] OFFERED_RESOURCE_ID { get; set; }
        public Nullable<System.DateTime> OFFERED_TIME { get; set; }
        public Nullable<System.DateTime> PENDING_TIME { get; set; }
        public byte[] PERFORMING_RESOURCE_ID { get; set; }
        public Nullable<short> PREVIOUS_STATUS { get; set; }
        public string SAVED_ACTIVITY { get; set; }
        public byte[] SPP_ID { get; set; }
        public Nullable<System.DateTime> TAKEN_TIME { get; set; }
        public short DESIGN_TIME_TYPE { get; set; }
        public short MFP_READY { get; set; }
        public short RESET_LIMIT { get; set; }
        public short RESET_COUNT { get; set; }
        public short TIME_OUT_ACTION_TYPE { get; set; }
        public int DOCUMENT_COUNT { get; set; }
        public int PAGE_COUNT { get; set; }
    }
}
