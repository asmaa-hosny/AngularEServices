using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Interfaces.Persistence;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services;
using EServicesApplication.Services.Common;
using EServicesCommon.DI;
using EservicesDomain.Common;
using EservicesDomain.Domain.UC;
using EservicesDomain.Domain.UCcompletion;
using EservicesDomain.ExternalDomain.UAC;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EServicesApplication.Service.UCcompletion
{
   public class ConsultationCompletionService : BaseService<ConsultationCompletionRequest, int>, IConsultationCompletionService
    {
        private IBaseService<ConsultationRequest, int> _consultationService;
        private IBaseService<ConsultationQuestions, int> _consultationQuestions;
        private IBaseService<ConsultantEvaluation, int> _consultantEvaluationService;
        private IBaseService<ConsultantEvaluationItems, int> _consultantEvaluationItemsService;
        private IBaseService<ConsultantAvailability, int> _availabilityservice;
        public IRepository<ConsultantAvailability, int> _availabilityrepository;


        private IUACService _uacService => FactoryManager.Instance.Resolve<IUACService>();


        public ConsultationCompletionService(IBaseService<ConsultationRequest, int> consultationService , IBaseService<ConsultationQuestions, int> ConsultationQuestions ,
            IBaseService<ConsultantEvaluation, int> ConsultantEvaluationService , IBaseService<ConsultantEvaluationItems, int> ConsultantEvaluationItemsService,
            IBaseService<ConsultantAvailability, int> Availabilityservice , IRepository<ConsultantAvailability, int> Availabilityrepository)
        {
            _consultationService = consultationService;
            _consultationQuestions = ConsultationQuestions;
            _consultantEvaluationService = ConsultantEvaluationService;
            _consultantEvaluationItemsService = ConsultantEvaluationItemsService;
            _availabilityservice = Availabilityservice;
            _availabilityrepository = Availabilityrepository;
        }
        public async Task<ConsultationCompletionDTO> GetRequestData(RequestDataModel data)
        {
            var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);
            ConsultationCompletionDTO dto = new ConsultationCompletionDTO();
            dto.DomainModel = FindOneByJobId(data.JobId);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.ConsultantEvaluation = await GetConsultantEvaluation(dto);
            dto.Decisions = decisionService.GetDecisionList(activity.HelpText);
            dto.activity = activity;
            return dto;

        }

        public async Task<ConsultationCompletionDTO> ReviewRequestData(RequestDataModel data)
        {
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);
            ConsultationCompletionDTO dto = new ConsultationCompletionDTO();
            dto.DomainModel = FindOneByJobId(data.JobId);
            dto.activity = activity;
            dto.IsReviewMode = true;
            return dto;
        }


        public async Task<ConsultationCompletionDTO> SaveRequestData(ConsultationCompletionDTO dto)
        {
            if (dto.IsTerminated)
            {
                dto.DomainModel.Status = "Terminated";
            }
            await AddNewRequest(dto.DomainModel);

            dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.KTAProcessIdConsultationCompletion, dto.DomainModel.Id);

            await UpdateAvailability(dto);

            dto.ConsultantEvaluation = new ConsultantEvaluation();
            await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);
            dto.ConsultantEvaluation.ConsultationId = dto.DomainModel.ConsultationRequestId;
            dto.ConsultantEvaluation.ConsultationCompletionId = dto.DomainModel.Id;
            dto.ConsultantEvaluation.Comments = dto.Comments;
            dto.ConsultantEvaluation.Rating = dto.Rating;
            dto.ConsultantEvaluation.ConsultantEmail = dto.ConsultantEmail;
            dto.ConsultantEvaluation.EmployeeEmail = dto.DomainModel.EmployeeEmail;

            await AddEvaluation(dto);
         
            await _consultantEvaluationService.AddNewRequest(dto.ConsultantEvaluation);

            

            return dto;
        }



        public async Task<ConsultationCompletionDTO> ProcessRequest(ConsultationCompletionDTO dto)
        {

            if (dto.activity == null)
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);

            if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.Research_Collaboration_Committee) && dto.ManagerDecision.Id == ((int)ConstantNodes.ConsultationDecisions.Approved).ToString())
            {
                if (dto.DomainModel.Status != "Terminated")
                { 
                    dto.DomainModel.StatusId = ((int)ConstantNodes.ConsultationStatus.Completed);
                    dto.DomainModel.Status = "Completed";
                }


                var entity = FindOneById(dto.DomainModel.Id);
                if (dto.DomainModel.Id == entity.Id)
                {
                    Mapper.Map(dto.DomainModel, entity);
                }
                await UpdateRequest();

                var ConsulationCompletionViewModel = new EditConsultationDataViewModel();

                Mapper.Map(dto.DomainModel, ConsulationCompletionViewModel);

                var jsonPatch = new JsonPatchDocument<EditConsultationDataViewModel>();
                jsonPatch.Replace(m => m.ActualCost, ConsulationCompletionViewModel.ActualCost);
                jsonPatch.Replace(m => m.ActualDeliverables, ConsulationCompletionViewModel.ActualDeliverables);
                jsonPatch.Replace(m => m.ActualDuration, ConsulationCompletionViewModel.ActualDuration);
                jsonPatch.Replace(m => m.DurationNotes, ConsulationCompletionViewModel.DurationNotes);
                jsonPatch.Replace(m => m.Status, ConsulationCompletionViewModel.Status);

                string jobId = dto.ConsultationJobId;

                var responce = await _uacService.PatchConsultationData(jsonPatch, jobId);
            }

            await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);

            return dto;

        }

        public (List<ConsultationModel> ConsultationList, List<ConsultantEvaluationModel> ConsultantEvaluationList) GetLists(string employeeEmail)
        {
            var items = _consultationService.GetQuerable().Where(x => x.EmployeeEmail == employeeEmail).DefaultIfEmpty();
            var ConsultationRequests = Mapper.Map<List<ConsultationModel>>(items);

            ConsultationCompletionDTO dto = new ConsultationCompletionDTO();
            var questionsItems = _consultationQuestions.GetAll();
           dto.ConsultantEvaluationItems = Mapper.Map<List<ConsultantEvaluationModel>>(questionsItems);

            return (ConsultationList: ConsultationRequests , ConsultantEvaluationList: dto.ConsultantEvaluationItems);
        }
        public async Task<ConsultantEvaluation> GetConsultantEvaluation(ConsultationCompletionDTO dto )
        {

            dto.ConsultantEvaluation = await _consultantEvaluationService.GetQuerable().Where(x => x.ConsultationCompletionId == dto.DomainModel.Id).Include(x => x.EvaluationItems).FirstOrDefaultAsync();
            var items = dto.ConsultantEvaluation.EvaluationItems;
            dto.ConsultantEvaluationItems = Mapper.Map<List<ConsultantEvaluationModel>>(items);
            return dto.ConsultantEvaluation;

        }

        //public List<ConsultantEvaluationModel> GetEvaluationItems()
        //{
        //    ConsultationCompletionDTO dto = new ConsultationCompletionDTO();
        //     var questionsItems = _consultationQuestions.GetAll();
        //     dto.ConsultantEvaluationItems = Mapper.Map<List<ConsultantEvaluationModel>>(questionsItems);

        //    return dto.ConsultantEvaluationItems;

        //}

        public async Task AddEvaluation(ConsultationCompletionDTO dto)
        {
            var EvaluationItems = new List<ConsultantEvaluationItems>();

            foreach (var item in dto.ConsultantEvaluationItems)
            {
               // item.ConsultantEmail = dto.ConsultantEmail;
               
                var tobeAdded = Mapper.Map<ConsultantEvaluationItems>(item);
                EvaluationItems.Add(tobeAdded);
            }

            dto.ConsultantEvaluation.EvaluationItems = EvaluationItems;
           // await _consultantEvaluationItemsService.AddMultiple(dto.ConsultantEvaluation.EvaluationItems.ToList());
        }

        public async Task UpdateAvailability(ConsultationCompletionDTO dto)
        {

          //  var entity = _availabilityservice.Find(x => x.ConsultationRequestId == dto.DomainModel.ConsultationRequestId);
            var entity = _availabilityrepository.GetOneByExpression($"ConsultationRequestId==\"{dto.DomainModel.ConsultationRequestId}\"");
            if (dto.DomainModel.ConsultationRequestId == entity.ConsultationRequestId)
            {
                entity.Days = dto.DomainModel.ActualDuration;
             
            }
            await _availabilityservice.Update(entity);

        }


    }
}
