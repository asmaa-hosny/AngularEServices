using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Service.UCconsultation;
using EServicesApplication.Services.Common;
using EServicesCommon.Common;
using EservicesDomain.ExternalDomain.SP;
using Microsoft.AspNetCore.Mvc;

namespace EServicesWithAngular.Controllers
{
  
    public class ConsultationController : BaseController
    {
        private readonly IConsultationService _serviceManager;

        public ConsultationController(IConsultationService ServiceManager)
        {
            _serviceManager = ServiceManager;

        }

        [HttpGet("GetRequest/{jobId}")]
        public async Task<IActionResult> GetRequest(RequestDataModel data)
        {
            data.SessionId = await base.getUserSession();

            var result = await _serviceManager.GetRequestData(data);

            return Ok(result);

        }


        [HttpGet("ReviewRequest/{jobId}")]
        public async Task<IActionResult> ReviewRequest(RequestDataModel data)
        {
            data.SessionId = await base.getUserSession();

            var result = await _serviceManager.ReviewRequestData(data);

            return Ok(result);
        }


        [HttpPost("PostRequest")]
        public async Task<IActionResult> PostRequest([FromBody] ConsultationDTO dto)
        {
           // using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{

                dto.SessionId = await base.getUserSession();
                dto.DomainModel.EmployeeEmail = CurrentUserEmail;
                dto.Requester.Username = CurrentUser;
                await _serviceManager.SaveRequestData(dto);
               // scope.Complete();
                return Ok();
            //}
        }


        [HttpPut("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] ConsultationDTO dto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                dto.SessionId = await base.getUserSession();
                dto.Requester.Username = CurrentUser;
                await _serviceManager.ProcessRequest(dto);

                scope.Complete();
                return Ok();
            }

        }

        [HttpGet("GetUniversity")]
        public async Task<ActionResult> GetUniversity()
        {
            var Universities = await _serviceManager.GetUniversities();
            return Ok(Universities);
        }

        [HttpGet("{selectedUniversity}/GetFellow")]
        public async Task<ActionResult> GetFellow(int selectedUniversity)
        {
            var Felllows = await _serviceManager.GetFellows(selectedUniversity);
            return Ok(Felllows);
        }

        [HttpGet("{fellowEmail}/GetArea")]
        public async Task<ActionResult> GetArea(string fellowEmail)
        {
            var returned = await _serviceManager.GetAreas(fellowEmail);
            return Ok(new { returned.Areas, returned.Rating });
        }
        [HttpGet("{consultantEmail}/GetConsultantRating")]
        public IActionResult GetConsultantRating(string consultantEmail)
        {
            var rating =  _serviceManager.GetRating(consultantEmail);
            return Ok(rating);
        }


        [HttpGet("{employeeEmail}/GetConsultationRequestsHistory")]
        public async Task<IActionResult> GetConsultationRequestsHistory(string employeeEmail)
        {
           
            var ConsultationRequestsHistoryList = await _serviceManager.GetConsultationRequestsHistory(employeeEmail);

            return Ok(ConsultationRequestsHistoryList);
        }

        [HttpGet("{consultantEmail}/{startDate}/{endDate}/{duration}/CheckConsultantAvailabilty")]
        public async Task<IActionResult> CheckConsultantAvailabilty(string consultantEmail , DateTime startDate , DateTime endDate , int duration)
        {

            var ConsultantAvailabiltyList = await _serviceManager.GetConsultantAvailability(consultantEmail , startDate , endDate , duration);

            return Ok(ConsultantAvailabiltyList);
        }

        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(ConsultationDTO), nodeId);
            return Ok(fields);
        }

        [HttpGet("{jobId}/GetAttachment")]
        public IActionResult GetAttachment(string jobid)
        {

            if (string.IsNullOrEmpty(jobid))
                return BadRequest();

            List<Attachment> attachments = FacadeService.GetAttachmentsCSOM(AppConfiguaraton.ConsultaionAttachementListName, jobid);

            return Ok(attachments);

        }

    

    }
}