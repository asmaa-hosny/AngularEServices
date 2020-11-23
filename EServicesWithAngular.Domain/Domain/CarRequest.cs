using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    public class CarRequest
    {
        [Column("ID")]
        public int Id { get; private set; }
        [Key]
        [Column("JobID")]
        [StringLength(100)]
        public string JobId { get; private set; }
        [StringLength(100)]
        public string RequesterName { get; private set; }
        [StringLength(100)]
        public string RequesterEmail { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; private set; }
        public bool Executed { get; private set; }
        [Column("Car_ID")]
        public int? CarId { get; private set; }
        [Column("RefID")]
        [StringLength(20)]
        public string RefId { get; private set; }
        [Column("StatusID")]
        public int? StatusId { get; private set; }
        [Column("OdometerReading_Before")]
        public int? OdometerReadingBefore { get; private set; }
        [Column("OdometerReading_After")]
        public int? OdometerReadingAfter { get; private set; }
        [Column("RequestPurposeID")]
        public int? RequestPurposeId { get; private set; }
        [StringLength(1000)]
        public string RequestPurposeDetails { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActualStartDate { get; private set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActualEndDate { get; private set; }
        [Column("TypeID_Initiate")]
        public int? TypeIdInitiate { get; private set; }
        public bool? Returned { get; private set; }
        [StringLength(10)]
        public string IsBusinessTrip { get; private set; }
        [Column("BusinessTripRefID")]
        [StringLength(100)]
        public string BusinessTripRefId { get; private set; }

        [ForeignKey("CarId")]
        [InverseProperty("CarRequest")]
        public Cars Car { get; private set; }
        [ForeignKey("RequestPurposeId")]
        [InverseProperty("CarRequest")]
        public CarRequestPurpose RequestPurpose { get; private set; }
        [ForeignKey("StatusId")]
        [InverseProperty("CarRequest")]
        public CarRequestStatuses Status { get; private set; }
    }
}
