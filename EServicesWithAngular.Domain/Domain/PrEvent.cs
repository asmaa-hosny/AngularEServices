using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PR_Event")]
    public class PrEvent
    {
        public PrEvent()
        {
            PrEventGuests = new HashSet<PrEventGuests>();
            PrEventHospitalities = new HashSet<PrEventHospitalities>();
            PrEventLogistic = new HashSet<PrEventLogistic>();
            PrEventMedia = new HashSet<PrEventMedia>();
            PrEventPrograms = new HashSet<PrEventPrograms>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(50)]
        public string RefId { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [StringLength(50)]
        public string EventName { get; private set; }
        public int? EventType { get; private set; }
        [StringLength(50)]
        public string OtherEvent { get; private set; }
        public int? GuestType { get; private set; }
        [StringLength(50)]
        public string OtherGuest { get; private set; }
        public int? EventLocation { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? EventStartDate { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? EventEndDate { get; private set; }
        [StringLength(50)]
        public string EventStartTime { get; private set; }
        [StringLength(50)]
        public string EventEndTime { get; private set; }
        public int? EventDays { get; private set; }
        public int? NoOfAttendees { get; private set; }
        [StringLength(50)]
        public string Status { get; private set; }
        [StringLength(50)]
        public string UpdatedBy { get; private set; }
        public string ReceptionNotes { get; private set; }
        [StringLength(50)]
        public string OtherLocation { get; private set; }

        [ForeignKey("EventLocation")]
        [InverseProperty("PrEvent")]
        public PrEventEventLocations EventLocationNavigation { get; private set; }
        [ForeignKey("EventType")]
        [InverseProperty("PrEvent")]
        public PrEventEventType EventTypeNavigation { get; private set; }
        [ForeignKey("GuestType")]
        [InverseProperty("PrEvent")]
        public PrEventGuestType GuestTypeNavigation { get; private set; }
        [InverseProperty("Event")]
        public ICollection<PrEventGuests> PrEventGuests { get; private set; }
        [InverseProperty("Event")]
        public ICollection<PrEventHospitalities> PrEventHospitalities { get; private set; }
        [InverseProperty("Event")]
        public ICollection<PrEventLogistic> PrEventLogistic { get; private set; }
        [InverseProperty("Event")]
        public ICollection<PrEventMedia> PrEventMedia { get; private set; }
        [InverseProperty("Event")]
        public ICollection<PrEventPrograms> PrEventPrograms { get; private set; }
    }
}
