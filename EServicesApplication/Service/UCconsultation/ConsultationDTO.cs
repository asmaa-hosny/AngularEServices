using EServicesApplication.Helpers;
using EServicesApplication.Services;
using EservicesDomain.Domain.UC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;


namespace EServicesApplication.Service.UCconsultation
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "consultation")]

    public class ConsultationDTO : BaseDTO
    {
        public ConsultationRequest DomainModel { get; set; }
        public List<ConsultationRequestsHistory> ConsultationRequestsHistory { get; set; }
        public ConsultantAvailability ConsultantAvailability { get; set; }
        public IEnumerable<IFormFile> Attachement { get; set; }

     


    }
}
