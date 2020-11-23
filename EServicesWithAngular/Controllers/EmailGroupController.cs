using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services;
using EServicesApplication.Services.Common;
using EServicesApplication.Services.ITEmailGroup;
using EServicesCommon.Common;
using EservicesDomain.Common;
using EservicesDomain.Domain.ITGroupEmail;
using Microsoft.AspNetCore.Mvc;

namespace EServicesWithAngular.Controllers
{
    public class EmailGroupController : BaseController
    {
        private readonly IService<EmailGroupDTO> _serviceManager;


        public EmailGroupController(IService<EmailGroupDTO> ServiceManager)
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
        public async Task<IActionResult> PostRequest([FromBody] EmailGroupDTO dto)
        {

           // using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
          //  {

                dto.SessionId = await base.getUserSession();
                dto.DomainModel.EmployeeEmail = CurrentUserEmail;

            await _serviceManager.SaveRequestData(dto);
              //  scope.Complete();
                return Ok();
          //  }

        }



        [HttpPut("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] EmailGroupDTO dto)
        {
           // using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
          //  {
                dto.SessionId = await base.getUserSession();
                dto.Requester.Username = CurrentUser;

            await _serviceManager.ProcessRequest(dto);

                return Ok();
           // }

        }


        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(EmailGroupDTO), nodeId);
            return Ok(fields);
        }

    }
}