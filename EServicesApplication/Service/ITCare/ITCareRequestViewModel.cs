using EServicesApplication.Helpers;
using EservicesDomain.ExternalDomain.ITCare;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EServicesApplication.Service.ITCare
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "itcare")]
    public class ITCareRequestViewModel
    {
        public ITCareRequest DomainModel { get; set; }

        public IEnumerable<IFormFile> Attachement { get; set; }


    }
}
