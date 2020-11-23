using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.Common;
using EServicesApplication.Services.ITServerAccess;
using EServicesCommon.Common;
using EservicesDomain.ExternalModel.ERB;
using EServicesWithAngular.ActionsFilter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class ITServerAccessController : BaseController
    {
        private IService<ITServerAccessDTO> _serviceManager;

        public ITServerAccessController(IService<ITServerAccessDTO> ServiceManager)
        {
            //ITServerAccessService
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
        public async Task<IActionResult> PostRequest([FromBody] ITServerAccessDTO dto)
        {
            dto.SessionId = await base.getUserSession();
            dto.Requester.Username = CurrentUser;
            dto.DomainModel.EmployeeEmail = CurrentUserEmail;
            await _serviceManager.SaveRequestData(dto);

            return Ok();
        }

      
        [HttpPut("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] ITServerAccessDTO dto)
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


        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(ITServerAccessDTO), nodeId);
            return Ok(fields);
        }
    }
}
