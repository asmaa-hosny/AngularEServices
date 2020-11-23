using System.Collections.Generic;
using System.Threading.Tasks;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.AdminTranslation;
using EServicesApplication.Services.Common;
using EServicesCommon.Common;
using EservicesDomain.ExternalDomain.SP;
using EServicesWithAngular.ActionsFilter;
using Microsoft.AspNetCore.Mvc;

namespace EServicesWithAngular.Controllers
{

    public class AdminTranslationController : BaseController
    {
        private readonly IAdminTranslationService _serviceManager;

        public AdminTranslationController(IAdminTranslationService ServiceManager)
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
        [ServiceFilter(typeof(ValidateModelAsyncFilter))]
        public async Task<IActionResult> PostRequest([FromBody] AdminTranslationDTO dto)
        {
            dto.SessionId = await base.getUserSession();
            dto.DomainModel.EmployeeEmail = CurrentUserEmail;
            dto.Requester.Username = CurrentUser;
            var employeedata = await EmployeeService.FindEmployeeWithEmailAsync(CurrentUserEmail);
            dto.DomainModel.EmployeeDepartment = employeedata.DepartmentEn;
            await _serviceManager.SaveRequestData(dto);
            return Ok();
        }

        [HttpPut("ProcessRequest")]
        [ServiceFilter(typeof(ValidateModelAsyncFilter))]
        public async Task<IActionResult> ProcessRequest([FromBody] AdminTranslationDTO dto)
        {
            if (dto == null)
                return BadRequest();

            if (dto.ManagerDecision == null)
                return BadRequest();

            dto.SessionId = await base.getUserSession();

            dto.Requester.Username = CurrentUser;

            await _serviceManager.ProcessRequest(dto);

            return Ok();

        }

        [HttpGet("GetTranslators")]
        public IActionResult GetTranslators()
        {
            var TranslatorsList = _serviceManager.GetTranslators();

            return Ok(TranslatorsList);
        }

        [HttpGet("GetPendingInstructionRequest")]
        public IActionResult GetPendingInstructionRequest()
        {
            var returned = _serviceManager.GetPendingInstructionTasks();

            return Ok(new { returned.pendingtasks, returned.instruction });
        }
  
        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(AdminTranslationDTO), nodeId);
            return Ok(fields);
        }

        [HttpGet("{jobId}/GetAttachment")]
        public IActionResult GetAttachment(string jobid)
        {

            if (string.IsNullOrEmpty(jobid))
                return BadRequest();

            List<Attachment> attachments = FacadeService.GetAttachmentsCSOM(AppConfiguaraton.TranslationAttachementListName, jobid);

            return Ok(attachments);

        }

    

    }
}