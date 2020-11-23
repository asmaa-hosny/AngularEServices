using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_UpdateProfile")]
    public class HrUpdateProfile
    {
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(12)]
        public string RefId { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Required]
        [StringLength(50)]
        public string UpdateType { get; private set; }
        [StringLength(50)]
        public string PassportNumber { get; private set; }
        [StringLength(50)]
        public string PassportIssueDate { get; private set; }
        [StringLength(50)]
        public string PassportEndDate { get; private set; }
        [StringLength(50)]
        public string PassportIssueLocation { get; private set; }
        [StringLength(50)]
        public string MartialStatus { get; private set; }
        [StringLength(50)]
        public string Country { get; private set; }
        [StringLength(50)]
        public string Region { get; private set; }
        [StringLength(50)]
        public string City { get; private set; }
        [StringLength(70)]
        public string DetailedAddress { get; private set; }
        [StringLength(50)]
        public string Telephone { get; private set; }
        [StringLength(20)]
        public string MobilePhone { get; private set; }
        [StringLength(20)]
        public string DependantRelationship { get; private set; }
        [Column("DependantNameAR")]
        [StringLength(100)]
        public string DependantNameAr { get; private set; }
        [Column("DependantNameEN")]
        [StringLength(100)]
        public string DependantNameEn { get; private set; }
        [StringLength(10)]
        public string DependentTypeOfIdentifier { get; private set; }
        [Column("DependantNationalIDOrIqama")]
        [StringLength(20)]
        public string DependantNationalIdorIqama { get; private set; }
        [Column("DependantDOB")]
        [StringLength(50)]
        public string DependantDob { get; private set; }
        [StringLength(50)]
        public string DependantNationality { get; private set; }
        [StringLength(50)]
        public string DegreeGraduationDate { get; private set; }
        [StringLength(50)]
        public string DegreeLevel { get; private set; }
        [StringLength(50)]
        public string LowDegree { get; private set; }
        [StringLength(50)]
        public string School { get; private set; }
        [Column("LD_GPA")]
        [StringLength(50)]
        public string LdGpa { get; private set; }
        [StringLength(50)]
        public string HighDegree { get; private set; }
        [StringLength(50)]
        public string University { get; private set; }
        [StringLength(50)]
        public string Major { get; private set; }
        [Column("HD_GPA")]
        [StringLength(50)]
        public string HdGpa { get; private set; }
        [StringLength(50)]
        public string TrainingProgramName { get; private set; }
        [StringLength(50)]
        public string TrainingDate { get; private set; }
        [StringLength(50)]
        public string TrainingDescription { get; private set; }
        [StringLength(50)]
        public string TrainingLocation { get; private set; }
        [StringLength(50)]
        public string TrainingCenter { get; private set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? TrainingDuration { get; private set; }
        [StringLength(500)]
        public string Other { get; private set; }
    }
}
