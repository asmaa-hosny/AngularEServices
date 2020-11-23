using EServicesApplication.Interfaces.Services;
using EServicesApplication.Service.ITSoftware;
using EServicesApplication.Services.Common;
using EServicesCommon.Common;
using EServicesWithAngular.ActionsFilter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class SoftwareController : BaseController
    {
        private readonly ISoftwareService _serviceManager;

        public SoftwareController(ISoftwareService ServiceManager)
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
        public async Task<IActionResult> PostRequest([FromBody] SoftwareDTO dto)
        {
            dto.SessionId = await base.getUserSession();
            dto.Requester.Username = CurrentUser;
            dto.DomainModel.EmployeeEmail = CurrentUserEmail;
            await _serviceManager.SaveRequestData(dto);

            return Ok();
        }


        [HttpPut("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] SoftwareDTO dto)
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

        [HttpGet("GetSoftwareAppsFromCategoryID/{SelectedCategoryId}")]
        public IActionResult GetSoftwareAppsFromCategoryID(int SelectedCategoryId)
        {
            //Retrive the Other Catogary equal "1"
            var SoftwareApps = _serviceManager.RetreiveSoftwareApps(1);
            return Ok(SoftwareApps);
        }

        [HttpGet("GetSoftwareCategories")]
        public IActionResult GetSoftwareCategories()
        {
            var SoftwareCategories = _serviceManager.RetreiveSoftwareCategories();
            return Ok(SoftwareCategories);
        }

        [HttpGet("GetRequestHistory")]
        public IActionResult GetRequestHistory()
        {
            var EmployeeRequestsHistory = _serviceManager.RetriveHistory(CurrentUserEmail);
            return Ok(EmployeeRequestsHistory);
        }


        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(SoftwareDTO), nodeId);
            return Ok(fields);
        }
    
    }
}

