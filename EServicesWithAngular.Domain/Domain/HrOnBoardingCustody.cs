using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_OnBoarding_Custody")]
    public class HrOnBoardingCustody
    {
        public int AssociatedTo { get; private set; }
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [StringLength(50)]
        public string CustodyName { get; private set; }
        [Required]
        [Column("CustodySN")]
        [StringLength(50)]
        public string CustodySn { get; private set; }
        [Required]
        [StringLength(50)]
        public string CustodyType { get; private set; }

        [ForeignKey("AssociatedTo")]
        [InverseProperty("HrOnBoardingCustody")]
        public HrOnBoarding AssociatedToNavigation { get; private set; }
    }
}
