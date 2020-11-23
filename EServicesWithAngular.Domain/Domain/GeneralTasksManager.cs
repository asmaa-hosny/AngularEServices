using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("General_TasksManager")]
    public class GeneralTasksManager
    {
        public GeneralTasksManager()
        {
            GeneralTasksManagerTaskAction = new HashSet<GeneralTasksManagerTaskAction>();
            InverseParentTask = new HashSet<GeneralTasksManager>();
        }

        [Column("id")]
        public int Id { get; private set; }
        [Column("JobID")]
        [StringLength(50)]
        public string JobId { get; private set; }
        [Column("REF_ID")]
        [StringLength(13)]
        public string RefId { get; private set; }
        [Column("ParentTaskID")]
        public int? ParentTaskId { get; private set; }
        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; private set; }
        [Required]
        [StringLength(50)]
        public string AssignedTo { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; private set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; private set; }
        public int? TaskType { get; private set; }
        public int? Priority { get; private set; }
        public int? TaskStatus { get; private set; }
        [StringLength(200)]
        public string TaskTitle { get; private set; }
        [StringLength(200)]
        public string TaskDescription { get; private set; }

        [ForeignKey("ParentTaskId")]
        [InverseProperty("InverseParentTask")]
        public GeneralTasksManager ParentTask { get; private set; }
        [InverseProperty("Task")]
        public ICollection<GeneralTasksManagerTaskAction> GeneralTasksManagerTaskAction { get; private set; }
        [InverseProperty("ParentTask")]
        public ICollection<GeneralTasksManager> InverseParentTask { get; private set; }
    }
}
