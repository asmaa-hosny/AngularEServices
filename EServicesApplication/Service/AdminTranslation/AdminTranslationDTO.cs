
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EServicesApplication.Helpers;
using EservicesDomain.Attributes;
using EservicesDomain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EServicesApplication.Services.AdminTranslation
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "translation")]
    public class AdminTranslationDTO : BaseDTO
    {
        public EservicesDomain.Domain.AdTranslation.AdminTranslation DomainModel { get; set; }

        public List<TranslatorsModel> Translators { get; set; }

        // [RequiredIf("NodeID", new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_Translator })]
        [RequiredAttachmentAttribute(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_Translator })]
        public IEnumerable<IFormFile> Attachement { get; set; }


    }
   
}
