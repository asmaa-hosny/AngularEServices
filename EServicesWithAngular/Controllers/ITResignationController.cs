using System.Collections.Generic;
using System.Threading.Tasks;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.Common;
using EServicesApplication.Services.Resignation;
using EServicesCommon.Common;
using EServicesWithAngular.ActionsFilter;
using Microsoft.AspNetCore.Mvc;


namespace EServicesWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class ITResignationController : BaseController
    {
        private readonly IResignationService _serviceManager;

        public ITResignationController(IResignationService ServiceManager)
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


        [HttpPut("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] ITResignationDTO dto)
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



        [HttpPost("PostRequest")]
        public async Task<IActionResult> PostRequest([FromBody] ITResignationDTO dto)
        {
            dto.SessionId = await base.getUserSession();

            if (string.IsNullOrEmpty(dto.DomainModel.EmployeeEmail))
                return BadRequest();

            await _serviceManager.SaveRequestData(dto);

            if (dto.Requester == null)
                return BadRequest();

            return Ok();
        }


        [HttpGet("GetResignedEmployee/{email}")]
        public async Task<IActionResult> GetResignedEmployee(string email)
        {
            var employee = await _serviceManager.GetResignedEmployeeData(email);

            return Ok(employee);
        }

        [HttpGet("GetResignationItems")]
        public IActionResult GetResignationItems(short nodeId)
        {
            var status =  _serviceManager.GetItems(nodeId);
            return Ok(status);
        }


        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(ITResignationDTO), nodeId);
            return Ok(fields);
        }

    }
}
