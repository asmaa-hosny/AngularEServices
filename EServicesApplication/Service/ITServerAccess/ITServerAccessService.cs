using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.Common;
using EservicesDomain.Common;
using EservicesDomain.Domain.ITServerAccess;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EServicesApplication.Services.ITServerAccess
{
    //ITServerAccessService implement interface of  IService<My DTO > and inherit from baseservice
    public class ITServerAccessService: BaseService<ServerAccess, int>, IService<ITServerAccessDTO>
    {
        //Mapping between parameters and method (get joibid node epc)
        //Get request include request details
        public async Task<ITServerAccessDTO> GetRequestData(RequestDataModel data)
        {
            logger.LogDebug("GetRequestData method fired with these parameters", data);
            var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);
            var dto = await PrepareDTO(data);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.Decisions = decisionService.GetDecisionList(activity.HelpText);
            dto.activity = activity;
            return dto;
        }
        public async Task<ITServerAccessDTO> ReviewRequestData(RequestDataModel data)
        {
            logger.LogDebug("ReviewRequestData method fired with these parameters", data);
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);
            var dto = await PrepareDTO(data);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.activity = activity;
            dto.IsReviewMode = true;
            return dto;
        }

        public async Task<ITServerAccessDTO> SaveRequestData(ITServerAccessDTO dto)
        {
            Mapper.Map(dto.ServerDetailsItems, dto.DomainModel.RequiredServersDetails);
            await AddNewRequest(dto.DomainModel);
            logger.LogDebug($"SessionId {dto.SessionId} , process ID {AppConfiguaraton.ITServerAccessProcessID} , DomainModel.Id {dto.DomainModel.Id} ");

            dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.ITServerAccessProcessID, dto.DomainModel.Id);
            logger.LogDebug($"Create Job ID fired {dto.DomainModel.JobId}");
            await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);
            logger.LogDebug($"Create Job ID fired {dto.DomainModel.JobId}");
            return dto;
        }

        //Update according to ur feature (service request)
        public async Task<ITServerAccessDTO> ProcessRequest(ITServerAccessDTO dto)
        {
            logger.LogDebug($"ProcessRequest method fired {dto.JobID} and {dto.NodeID}");

            if (dto.activity == null)
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);

            if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.NodeId_ITSystems || dto.activity.Identity.NodeId == ConstantNodes.NodeId_EmployeeToUpdate))
            {
                if (dto.activity.Identity.NodeId == ConstantNodes.NodeId_EmployeeToUpdate)
                {
                    Mapper.Map(dto.ServerDetailsItems, dto.DomainModel.RequiredServersDetails);
                }
                var entity = FindOneById(dto.DomainModel.Id);
                Mapper.Map(dto.DomainModel, entity);
                await UpdateRequest();
            }
            logger.LogDebug($"CompleteActivity method fired SessionId {dto.SessionId} and Username {dto.Requester.Username} and Id { dto.ManagerDecision.Id} and Comment {dto.ManagerDecision.Comment} and Identity {dto.activity.Identity}");

            await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);

            return dto;
        }

        #region helpers
        private async Task<ITServerAccessDTO> PrepareDTO(RequestDataModel data)
        {
            //FindOneByJobId(jobId)
            //Inclufe other items so i need querable .include
              ITServerAccessDTO dto = new ITServerAccessDTO();

              dto.DomainModel = await GetQuerable().Where(x => x.JobId == data.JobId).Include(x => x.RequiredServersDetails).FirstOrDefaultAsync();
             
              var items = dto.DomainModel.RequiredServersDetails;
              dto.ServerDetailsItems = Mapper.Map<List<ServerDetails>>(items);

            return dto;
        }

    }
    #endregion
}
