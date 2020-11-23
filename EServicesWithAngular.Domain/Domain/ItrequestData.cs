using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("ITRequestData")]
    public class ItrequestData
    {
        public ItrequestData()
        {
            ItrequestDataList = new HashSet<ItrequestDataList>();
        }

        [Key]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [StringLength(100)]
        public string ContractorProject { get; private set; }
        [StringLength(100)]
        public string ContractorCompany { get; private set; }
        [StringLength(100)]
        public string ContractorMobile { get; private set; }
        [StringLength(100)]
        public string ContractorEmail { get; private set; }
        [Column("HDTeamNotes")]
        [StringLength(500)]
        public string HdteamNotes { get; private set; }
        [StringLength(500)]
        public string MsgToNetwork { get; private set; }
        [StringLength(500)]
        public string MsgToServices { get; private set; }
        [StringLength(100)]
        public string ContractorName { get; private set; }
        [StringLength(500)]
        public string OtherItems { get; private set; }
        [Column("REFID")]
        [StringLength(12)]
        public string Refid { get; private set; }
        public bool? Updated { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        public int? Status { get; private set; }
        [StringLength(50)]
        public string RequestType { get; private set; }
        [StringLength(100)]
        public string RequesterEmail { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? Requestdate { get; private set; }
        [StringLength(500)]
        public string Notes { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustodyEndDate { get; private set; }

        [ForeignKey("Status")]
        [InverseProperty("ItrequestData")]
        public CoreStatus StatusNavigation { get; private set; }
        [InverseProperty("ItrequestData")]
        public ICollection<ItrequestDataList> ItrequestDataList { get; private set; }
    }
}
