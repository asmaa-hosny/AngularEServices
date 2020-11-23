using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("General_TasksManager_TaskAction")]
    public class GeneralTasksManagerTaskAction
    {
        [Column("id")]
        public int Id { get; private set; }
        [Required]
        [StringLength(50)]
        public string ActionTaker { get; private set; }
        [Column("TaskID")]
        public int? TaskId { get; private set; }
        public int? TaskStatus { get; private set; }
        [StringLength(500)]
        public string HowItWasDone { get; private set; }
        [StringLength(500)]
        public string Comment { get; private set; }

        [ForeignKey("TaskId")]
        [InverseProperty("GeneralTasksManagerTaskAction")]
        public GeneralTasksManager Task { get; private set; }
    }
}
