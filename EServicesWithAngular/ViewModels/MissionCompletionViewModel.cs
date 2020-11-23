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
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "mission")]
    public class MissionCompletionDTO : BaseViewModel
    {
        public MissionCompletionDTO()
        {
            DomainModel = new MissionCompletion();
        }

        #region Properties

        public MissionCompletion DomainModel { get; set; }

        [StaticDisplayRule(new short[] { Requisition.NodeId_RequestInitiation })]
        [RequiredAttachment(new short[] { Requisition.NodeId_RequestInitiation })]
        public IEnumerable<IFormFile> Attachement { get; set; }

        public IEnumerable<BusinessTripLine> MandateTrainingLines { get; set; }

        public IEnumerable<OvertimeLine> OvertimeLines { get; set; }

        public long MissionID { get; set; }

        #endregion
    }
}
