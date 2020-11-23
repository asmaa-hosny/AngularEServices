using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.Common;
using EServicesApplication.Services.ITAccounts;
using EServicesCommon.Common;
using Microsoft.AspNetCore.Mvc;

namespace EServicesWithAngular.Controllers
{
    // [ServiceFilter(typeof(ValidateModelAsyncFilter))]
    public class ITAccountController : BaseController
    {
        private readonly IService<ITAccountDTO> _serviceManager;


        public ITAccountController(IService<ITAccountDTO> ServiceManager)
        {
            _serviceManager = ServiceManager;

        }

        [HttpGet("GetRequest/{jobId}")]
        public async Task<IActionResult> GetRequest(RequestDataModel data)
        {
            data.SessionId =await  base.getUserSession();

            var result = await _serviceManager.GetRequestData(data);

            return Ok(result);

        }


        [HttpGet("ReviewRequest/{jobId}")]
        public async Task<IActionResult> ReviewRequest(RequestDataModel data)
        {
            data.SessionId = await base.getUserSession();

            var result =await  _serviceManager.ReviewRequestData(data);

            return Ok(result);
        }


        [HttpPost("PostRequest")]
        public async Task<IActionResult> PostRequest([FromBody] ITAccountDTO dto)
        {
           using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
           {

                dto.SessionId =await  base.getUserSession();
                dto.DomainModel.EmployeeEmail = CurrentUserEmail;

                await _serviceManager.SaveRequestData(dto);
                scope.Complete();    
                return Ok();
            }
        }



        [HttpPut("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] ITAccountDTO dto)
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


        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(ITAccountDTO), nodeId);
            return Ok(fields);
        }

    }
}