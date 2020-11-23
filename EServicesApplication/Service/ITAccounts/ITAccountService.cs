using CommonLibrary.Configuaration;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.Common;
using EServicesCommon.DI;
using EservicesDomain.Common;
using EservicesDomain.Domain;
using System.Threading.Tasks;

namespace EServicesApplication.Services.ITAccounts
{
    public class ITAccountService : BaseService<ITAccount, int>, IService<ITAccountDTO>
    {

        public async Task<ITAccountDTO> GetRequestData(RequestDataModel data)
        {
           var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);
            ITAccountDTO dto = new ITAccountDTO();
            dto.DomainModel =  FindOneByJobId(data.JobId);
            dto.AddNewAccount();
           if (data.NodeId == ConstantNodes.NodeId_ITSystemsHead || data.NodeId == ConstantNodes.NodeId_ITSystemsTeam)
               dto.createUser = true;
            dto.Decisions =  decisionService.GetDecisionList(activity.HelpText);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.activity = activity;
            return dto;
            
        }

        public async Task<ITAccountDTO> ReviewRequestData(RequestDataModel data)
        {
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);
            ITAccountDTO dto = new ITAccountDTO();
            dto.DomainModel =  FindOneByJobId(data.JobId);
            dto.activity = activity;
            dto.IsReviewMode = true;
            return dto;
        }


        public async Task<ITAccountDTO> SaveRequestData(ITAccountDTO dto)
        {
            logger.LogDebug("SaveRequestData method fired with these parameters");
            var config = FactoryManager.Instance.Resolve<ICoreConfigurations>();
            if (dto.DomainModel.IsForTrainee)
            {
                dto.DomainModel.ContractorCompany = config.TraineeCompany;
                dto.DomainModel.ContractorJobTitle = config.TraineeJobTitle;
                dto.DomainModel.ContractorProject = config.TraineeProject;
            }
            await AddNewRequest(dto.DomainModel);

           dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.KTAProcessIdITAccount, dto.DomainModel.Id);

           await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);

            return dto;
        }



        public async Task<ITAccountDTO> ProcessRequest(ITAccountDTO dto)
        {

           if (dto.activity == null)
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);

           if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.NodeId_ITSystemsHead || dto.activity.Identity.NodeId == ConstantNodes.NodeId_ITSystemsTeam || dto.activity.Identity.NodeId == ConstantNodes.NodeId_ITSystemEmployeeToUpdate))
           {
                var entity = FindOneById(dto.DomainModel.Id);
                Mapper.Map(dto.DomainModel, entity);
                await UpdateRequest();
           }

            await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);

            return dto;

        }

 
    }
}
