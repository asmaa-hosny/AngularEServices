using System;


namespace EservicesDomain.Domain.DomainAgility
{
    public partial class JOB
    {
        public byte[] JOB_ID { get; set; }
        public bool ARCHIVE_FINISHED_JOB { get; set; }
        public bool ASSESSED_FOR_CHECKING { get; set; }
        public bool ASSESSED_FOR_SAMPLING { get; set; }
        public byte[] ASSOCIATED_CASE_ID { get; set; }
        public byte[] CATEGORY_ID { get; set; }
        public bool COST_OVERRUN { get; set; }
        public System.DateTime CREATION_TIME { get; set; }
        public byte[] CREATOR { get; set; }
        public bool DURATION_OVERRUN { get; set; }
        public short EMBEDDED_PROCESS_COUNT { get; set; }
        public decimal EXPECTED_COST { get; set; }
        public int EXPECTED_DURATION_IN_SECONDS { get; set; }
        public System.DateTime EXPECTED_FINISH_TIME { get; set; }
        public System.DateTime FINISH_TIME { get; set; }
        public short JOB_STATUS { get; set; }
        public System.DateTime LAST_MODIFIED_DATE { get; set; }
        public short MACHINE_ID { get; set; }
        public byte[] ORIGIN_SERVER_ID { get; set; }
        public short PRIORITY { get; set; }
        public byte[] PROCESS_ID { get; set; }
        public string PROCESS_NAME { get; set; }
        public byte[] ROOT_JOB_ID { get; set; }
        public int SCORE { get; set; }
        public bool SELECTED_FOR_CHECKING { get; set; }
        public bool SELECTED_FOR_SAMPLING { get; set; }
        public System.DateTime SLA_STATUS2_DATE { get; set; }
        public System.DateTime SLA_STATUS3_DATE { get; set; }
        public System.DateTime SLA_STATUS4_DATE { get; set; }
        public System.DateTime SLA_STATUS5_DATE { get; set; }
        public decimal SPEND_SO_FAR { get; set; }
        public System.DateTime START_TIME { get; set; }
        public short TYPE { get; set; }
        public decimal VERSION { get; set; }
        public byte[] WORK_QUEUE_DEFINITION_ID { get; set; }
        public Nullable<System.DateTime> ACTIVATION_TIME { get; set; }
        public Nullable<decimal> BUDGET { get; set; }
        public byte[] CHECKED_RESOURCE_ID { get; set; }
        public string CUST_DATA { get; set; }
        public string EXCEPTION_CODE { get; set; }
        public short RAISED_BY { get; set; }
        public Nullable<System.DateTime> HOLD_TIME { get; set; }
        public byte[] JOB_OWNER_ID { get; set; }
        public string LANGUAGE { get; set; }
        public byte[] OWNER_PROCESS_ID { get; set; }
        public string REASON_FOR_HOLD { get; set; }
        public byte[] SKIN_ID { get; set; }
        public string STATE { get; set; }
        public string JOB_SOURCE { get; set; }
        public bool CAPTURE_ENABLED { get; set; }
        public string SUSPEND_REASON { get; set; }
    }
}
