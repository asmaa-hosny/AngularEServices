using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_OnBoarding")]
    public class HrOnBoarding
    {
        public HrOnBoarding()
        {
            HrOnBoardingCustody = new HashSet<HrOnBoardingCustody>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(12)]
        public string RefId { get; private set; }
        [Column("EmployeeID")]
        public int EmployeeId { get; private set; }
        [StringLength(10)]
        public string OfficeNumber { get; private set; }
        [StringLength(1000)]
        public string Notes { get; private set; }

        [InverseProperty("AssociatedToNavigation")]
        public ICollection<HrOnBoardingCustody> HrOnBoardingCustody { get; private set; }
    }
}
