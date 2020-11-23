using EservicesDomain.Attributes;
using EServicesWithAngular.Domain;
using EServicesWithAngular.Domain.Commo;
using EServicesWithAngular.Domain.Common;
using EServicesWithAngular.Helpers;
using EServicesWithAngular.ViewModels;
using KTA_ActivityServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Models
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "requisition")]
    public class RequisitionDTO : BaseViewModel
    {
      
        #region Properties

        public Requisition DomainModel { get; set; }

        [StaticDisplayRule(new short[] { Requisition.NodeId_RequestInitiation })]
        [RequiredAttachment(new short[] { Requisition.NodeId_RequestInitiation })]
        public IEnumerable<IFormFile> ScopeOfWorkAR { get; set; }

        [StaticDisplayRule(new short[] { Requisition.NodeId_RequestInitiation })]
        [RequiredAttachment(new short[] { Requisition.NodeId_RequestInitiation })]
        public IEnumerable<IFormFile> QuantitiesAndCostBrakedownTableAR { get; set; }

        [StaticDisplayRule(new short[] { Requisition.NodeId_RequestInitiation })]
        [RequiredAttachment(new short[] { Requisition.NodeId_RequestInitiation })]
        public IEnumerable<IFormFile> ImplementationAndPaymentTimetableAR { get; set; }

        [StaticDisplayRule(new short[] { Requisition.NodeId_RequestInitiation })]
        [RequiredAttachment(new short[] { Requisition.NodeId_RequestInitiation })]
        public IEnumerable<IFormFile> ProjectApprovalInTheBudgetForm { get; set; }

        public IEnumerable<IFormFile> Others { get; set; }

        #endregion
    }
}
