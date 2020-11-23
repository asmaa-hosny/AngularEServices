using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PRC_Requisition_ProjectTypes")]
    public class PrcRequisitionProjectTypes
    {
        private PrcRequisitionProjectTypes()
        {
            PrcRequisition = new HashSet<PrcRequisition>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [StringLength(100)]
        public string ProjectType { get; set; }

        [InverseProperty("ProjectType")]
        public ICollection<PrcRequisition> PrcRequisition { get; set; }
    }
}
