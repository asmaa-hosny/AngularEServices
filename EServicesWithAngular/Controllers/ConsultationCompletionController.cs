using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Service.UCcompletion;
using EServicesApplication.Services.Common;
using EServicesCommon.Common;
using Microsoft.AspNetCore.Mvc;


namespace EServicesWithAngular.Controllers
{
    public class ConsultationCompletionController : BaseController
    {
        private readonly IConsultationCompletionService _serviceManager;


        public ConsultationCompletionController(IConsultationCompletionService ServiceManager)
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
        public async Task<IActionResult> PostRequest([FromBody] ConsultationCompletionDTO dto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                dto.SessionId = await base.getUserSession();
                dto.DomainModel.EmployeeEmail = CurrentUserEmail;
                dto.Requester.Username = CurrentUser;
                await _serviceManager.SaveRequestData(dto);
                scope.Complete();
                return Ok();
            }
        }



        [HttpPut("ProcessRequest")]
        public async Task<IActionResult> ProcessRequest([FromBody] ConsultationCompletionDTO dto)
        {
            
                dto.SessionId = await base.getUserSession();
                dto.Requester.Username = CurrentUser;
                await _serviceManager.ProcessRequest(dto);

              
                return Ok();
            

        }
      
        [HttpGet("GetRequestLists")]
        public IActionResult GetRequestLists()
        {
            string employeeEmail = CurrentUserEmail;
            var  returned = _serviceManager.GetLists(employeeEmail);

            return Ok(new { returned.ConsultationList, returned.ConsultantEvaluationList });
        }

     //   [HttpGet("GetEvaluationItem")]
        //public IActionResult GetEvaluationItem()
        //{
         
        //    var EvaluationItemsList = _serviceManager.GetEvaluationItems();

        //    return Ok(EvaluationItemsList);
        //}

        [HttpGet("{nodeId}/GetJsonFields")]
        public IActionResult GetJsonFields(short nodeId)
        {
            List<JsonFieldsDTO> fields = getObjectPropertiesWithMetadata(typeof(ConsultationCompletionDTO), nodeId);
            return Ok(fields);
        }

    }
}