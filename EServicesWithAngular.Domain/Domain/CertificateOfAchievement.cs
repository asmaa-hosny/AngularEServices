using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    public class CertificateOfAchievement
    {
        [Column("id")]
        public int Id { get; private set; }
        [Key]
        [Column("JOB_ID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [StringLength(50)]
        public string VendorName { get; private set; }
        [Column("PONo")]
        [StringLength(50)]
        public string Pono { get; private set; }
        [Column("POValue")]
        public double? Povalue { get; private set; }
        [StringLength(70)]
        public string ProjectPurpose { get; private set; }
        [Column("POStartDate", TypeName = "datetime")]
        public DateTime? PostartDate { get; private set; }
        [Column("POEndDate", TypeName = "datetime")]
        public DateTime? PoendDate { get; private set; }
        [Column("ComercialID")]
        [StringLength(50)]
        public string ComercialId { get; private set; }
        [StringLength(50)]
        public string Nationality { get; private set; }
        [Column("POPaidAmt")]
        public double? PopaidAmt { get; private set; }
        [Column("PORemaininngBalance")]
        public double? PoremaininngBalance { get; private set; }
        [StringLength(10)]
        public string BillNo { get; private set; }
        public double? BillTotalValue { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? BillDate { get; private set; }
        public double? CompletionPercentage { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompletionDate { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? RequestDate { get; private set; }
        [Column("REFID")]
        [StringLength(12)]
        public string Refid { get; private set; }
        [StringLength(10)]
        public string CommitmentNo { get; private set; }
        public double? CommitmentAmt { get; private set; }
        public double? CommitmentRemAmt { get; private set; }
        [StringLength(50)]
        public string AccountName { get; private set; }
        public bool Updated { get; private set; }
        [Column("C_Order_id")]
        public long? COrderId { get; private set; }
        [Column("C_Commitment_id")]
        public long? CCommitmentId { get; private set; }
        [Column("C_CommitmentLine_ID")]
        public long? CCommitmentLineId { get; private set; }
        [StringLength(200)]
        public string Description { get; private set; }
    }
}
