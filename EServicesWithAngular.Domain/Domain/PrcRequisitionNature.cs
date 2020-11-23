using EServicesWithAngular.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("PRC_RequisitionNature")]
    public class PrcRequisitionNature
    {
        public PrcRequisitionNature()
        {
            PrcRequisition = new HashSet<PrcRequisition>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Column("RequisitionNatureAR")]
        [StringLength(100)]
        public string RequisitionNatureAr { get; set; }
        [Column("RequisitionNatureEN")]
        [StringLength(100)]
        public string RequisitionNatureEn { get; set; }
        public bool? Default { get; set; }

        [InverseProperty("RequisitionNature")]
        public ICollection<PrcRequisition> PrcRequisition { get; set; }

        public static PrcRequisitionNature Create(int Id, string RequisitionNatureAr, string RequisitionNatureEn, bool? Default)
        {
            return new PrcRequisitionNature()
            {
                Id = Id,
                RequisitionNatureAr = RequisitionNatureAr,
                RequisitionNatureEn = RequisitionNatureEn,
                Default = Default
            };
        }

        public static implicit operator PrcRequisitionNature(PrcRequisitionNatureDTO dto)
        {
            return PrcRequisitionNature.Create(dto.Id, dto.RequisitionNatureAr, dto.RequisitionNatureEn, dto.Default);
        }
    }

    public class PrcRequisitionNatureDTO
    {
        public PrcRequisitionNatureDTO()
        {
            PrcRequisition = new HashSet<PrcRequisition>();
        }
        public int Id { get; set; }
        public string RequisitionNatureAr { get; set; }
        public string RequisitionNatureEn { get; set; }
        public bool? Default { get; set; }
        public ICollection<PrcRequisition> PrcRequisition { get; set; }

        public static PrcRequisitionNatureDTO Create(int Id, string RequisitionNatureAr, string RequisitionNatureEn, bool? Default)
        {
            return new PrcRequisitionNatureDTO()
            {
                Id = Id,
                RequisitionNatureAr = RequisitionNatureAr,
                RequisitionNatureEn = RequisitionNatureEn,
                Default = Default
            };
        }

        public static implicit operator PrcRequisitionNatureDTO(PrcRequisitionNature PrcRequisitionNature)
        {
            return PrcRequisitionNatureDTO.Create(PrcRequisitionNature.Id, PrcRequisitionNature.RequisitionNatureAr, PrcRequisitionNature.RequisitionNatureEn, PrcRequisitionNature.Default);
        }
    }
}




