using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.Common;
using EServicesApplication.Services.SiteCreation;
using EServicesCommon.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EServicesWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class SPSiteCreationController : BaseController
    {
        public readonly IService<SPSiteCreationDTO> _serviceManager;


        public SPSiteCreationController(IService<SPSiteCreationDTO> ServiceManager)
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
        public  async Task<IActionResult> ReviewRequest(RequestDataModel data)
        {
            data.SessionId = await base.getUserSession();

            var result = await _serviceManager.ReviewRequestData(data);

            return Ok(result);
        }


        [HttpPost("PostRequest")]
        public async Task<IActionResult> PostRequest([FromBody] SPSiteCreationDTO dto)
        {

            dto.SessionId = await base.getUserSession();
            dto.DomainModel.EmployeeEmail = CurrentUserEmail;
            dto.Requester.Username = CurrentUser;
            var employeedata = await EmployeeService.FindEmployeeWithEmailAsync(CurrentUserEmail);
            dto.DomainModel.DepartmentOfRequestor = employeedata.DepartmentEn;
            dto.DomainModel.SectorOfRequestor = employeedata.SectionNameEn;

            await _serviceManager.SaveRequestData(dto);

            return Ok();
        }


        [HttpPut("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] SPSiteCreationDTO dto)
        {
            dto.SessionId = await base.getUserSession();
            dto.Requester.Username = CurrentUser;

            await _serviceManager.ProcessRequest(dto);

            return Ok();

        }


        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(SPSiteCreationDTO), nodeId);
            return Ok(fields);

        }
    }
}
