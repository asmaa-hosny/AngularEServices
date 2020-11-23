using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("Core_Exceptions")]
    public class CoreExceptions
    {
        [Key]
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        public string System { get; private set; }
        public string Title { get; private set; }
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
        [Column("helpLink")]
        public string HelpLink { get; private set; }
        [Column("hResult")]
        public string HResult { get; private set; }
        [Column("innerException")]
        public string InnerException { get; private set; }
        [Column("targetSite")]
        public string TargetSite { get; private set; }
        public string Source { get; private set; }
        public int? Solution { get; private set; }

        [ForeignKey("Solution")]
        [InverseProperty("CoreExceptions")]
        public CoreExceptionsSolutions SolutionNavigation { get; private set; }
    }
}
