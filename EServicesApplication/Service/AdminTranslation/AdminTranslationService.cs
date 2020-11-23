using EServicesApplication.Services.Common;
using EservicesDomain.Common;
using System.Threading.Tasks;
using EservicesDomain.Domain.AdTranslation;
using System.Collections.Generic;
using EServicesApplication.Interfaces.Services;
using System.Linq;
using System;

namespace EServicesApplication.Services.AdminTranslation
{

    public class AdminTranslationService : BaseService<EservicesDomain.Domain.AdTranslation.AdminTranslation, int>, IAdminTranslationService
    {
        private IBaseService<AdminTranslator, int> _translationservice;
        private IBaseService<TranslationInstructions, int> _instructions;
        public AdminTranslationService(IBaseService<AdminTranslator, int> translationservice , IBaseService<TranslationInstructions, int> instructionsservice)
        {
            _translationservice = translationservice;
            _instructions = instructionsservice;
        }
        public async Task<AdminTranslationDTO> GetRequestData(RequestDataModel data)
        {
            logger.LogDebug("GetRequestData method fired with these parameters", data);
            var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);
            AdminTranslationDTO dto = new AdminTranslationDTO();
            dto.DomainModel = FindOneByJobId(data.JobId);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.Decisions = decisionService.GetDecisionList(activity.HelpText);
            dto.activity = activity;
            return dto;
        }

        public async Task<AdminTranslationDTO> ReviewRequestData(RequestDataModel data)
        {

            logger.LogDebug("ReviewRequestData method fired with these parameters", data);
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);
            AdminTranslationDTO dto = new AdminTranslationDTO();
            dto.DomainModel = FindOneByJobId(data.JobId);
            dto.activity = activity;
            dto.IsReviewMode = true;
            return dto;
        }

        public async Task<AdminTranslationDTO> SaveRequestData(AdminTranslationDTO dto)
        {
            logger.LogDebug("SaveRequestData method fired with these parameters");
            dto.DomainModel.NumberOfAttachment = dto.Attachement.Count();
            dto.DomainModel.RequestDate = DateTime.Now;
            await AddNewRequest(dto.DomainModel);

            dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.TranslationProcessID, dto.DomainModel.Id);

            await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);


            FileService.UploadRequestFiles(typeof(AdminTranslationDTO), dto,
             AppConfiguaraton.TranslationAttachementPath,
             dto.DomainModel.JobId, AppConfiguaraton.TranslationAttachementListName,
             string.Empty, dto.Requester.Username, multiTypes: false,
             uploadToSharepoint: true, multi: true);


            return dto;
        }


        public async Task<AdminTranslationDTO> ProcessRequest(AdminTranslationDTO dto)
        {
            logger.LogDebug($"ProcessRequest method fired {dto.JobID} and {dto.NodeID}");
            if (dto.activity == null)
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);



            if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.NodeId_TransManager))
            {
                var entity = FindOneById(dto.DomainModel.Id);
                if (dto.DomainModel.Id == entity.Id)
                {
                   // entity.AssignedTo = dto.DomainModel.AssignedTo;
                    entity.Status = dto.ManagerDecision.Id;
                    entity.ManagerNotes = dto.DomainModel.ManagerNotes;
                }
                await UpdateRequest();
            }
            if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.NodeId_Translator))
            {
                var entity = FindOneById(dto.DomainModel.Id);
                if (dto.DomainModel.Id == entity.Id)
                { entity.AssignedTo = dto.Requester.Username;
                  entity.Status = dto.ManagerDecision.Id;
                 entity.DoneDate = DateTime.Now;
                }
                await UpdateRequest();
            }

                await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);

            FileService.UploadRequestFiles(typeof(AdminTranslationDTO), dto,
             AppConfiguaraton.TranslationAttachementPath,
             dto.DomainModel.JobId, AppConfiguaraton.TranslationAttachementListName,
             string.Empty, dto.Requester.Username, multiTypes: false,
             uploadToSharepoint: true, multi: true);

            return dto;
        }

        public List<TranslatorsModel> GetTranslators()
        {
            var items = _translationservice.GetAll();

            var result = Mapper.Map<List<TranslatorsModel>>(items);

            return result;
        }

        public (int pendingtasks, TranslationInstructions instruction) GetPendingInstructionTasks()
           
        {
            var Admin_Translation =(ConstantNodes.InstructionsProcessName.Admin_Translation).ToString();
            var instructionItem = _instructions.GetQuerable().SingleOrDefault(x => x.ProcessName == Admin_Translation);

            string Executed = ((int)ConstantNodes.EnumITStatus.Executed).ToString();
            var PindingRequests = GetQuerable().Where(x => x.Status != Executed).Count();
            
            return (pendingtasks:PindingRequests, instruction: instructionItem);
        }

    

    }
}
