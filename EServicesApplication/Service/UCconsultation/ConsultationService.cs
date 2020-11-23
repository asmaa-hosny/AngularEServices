using CommonLibrary.Configuaration;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services;
using EServicesApplication.Services.Common;
using EServicesCommon.DI;
using EservicesDomain.Common;
using EservicesDomain.Domain.UC;
using EservicesDomain.Domain.UCcompletion;
using EservicesDomain.ExternalDomain.UAC;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EServicesApplication.Service.UCconsultation
{
    public class ConsultationService : BaseService<ConsultationRequest, int>, IConsultationService
    {
        
        private IUACService _uacService => FactoryManager.Instance.Resolve<IUACService>();
        private IBaseService<ConsultantAvailability, int> _availabilityservice;
        private IBaseService<ConsultantEvaluation, int> _consultantEvaluationservice;
      
        private ICoreConfigurations _configuaration => FactoryManager.Instance.Resolve<ICoreConfigurations>();

        public ConsultationService(IBaseService<ConsultantAvailability, int> Availabilityservice ,
            IBaseService<ConsultantEvaluation, int> ConsultantEvaluationservice)
        {
            _availabilityservice = Availabilityservice;
            _consultantEvaluationservice = ConsultantEvaluationservice;
         
        }
        public async Task<ConsultationDTO> GetRequestData(RequestDataModel data)
        {
            var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);
            ConsultationDTO dto = new ConsultationDTO();
            dto.DomainModel = FindOneByJobId(data.JobId);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.Decisions = decisionService.GetDecisionList(activity.HelpText);
            dto.activity = activity;
            dto.ConsultationRequestsHistory = await GetConsultationRequestsHistory(dto.DomainModel.EmployeeEmail);
            return dto;

        }

        public async Task<ConsultationDTO> ReviewRequestData(RequestDataModel data)
        {
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);
            ConsultationDTO dto = new ConsultationDTO();
            dto.DomainModel = FindOneByJobId(data.JobId);
            dto.activity = activity;
            dto.IsReviewMode = true;
            return dto;
        }


        public async Task<ConsultationDTO> SaveRequestData(ConsultationDTO dto)
         {
            
             await AddNewRequest(dto.DomainModel);

            dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.KTAProcessIdConsultation, dto.DomainModel.Id);

            await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);

            await AddAvailability(dto);

            var ConsulationViewModel = new NewConsultationViewModel();

            Mapper.Map(dto.DomainModel, ConsulationViewModel);

            var responce =  await _uacService.PostConsultationData(ConsulationViewModel);
            if (dto.Attachement != null)
            {
                FileService.UploadRequestFiles(typeof(ConsultationDTO), dto,
                AppConfiguaraton.ConsultaionAttachementPath,
                dto.DomainModel.JobId, AppConfiguaraton.ConsultaionAttachementListName,
                string.Empty, dto.Requester.Username, multiTypes: true,
                uploadToSharepoint: true, multi: true);
            }
            return dto;
        }



        public async Task<ConsultationDTO> ProcessRequest(ConsultationDTO dto)
        {
            logger.LogDebug("activity", (dto.activity));

            if (dto.activity == null)
               
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);
     

           if (dto.activity.Identity.NodeId == dto.NodeID && dto.activity.Identity.NodeId == ConstantNodes.Research_Collaboration_Committee)
            {
                if (dto.ManagerDecision.Id == ((int)ConstantNodes.ConsultationDecisions.Approved).ToString())
                {
                    dto.DomainModel.Status = "Approved"; ;

                }
                else if(dto.ManagerDecision.Id == ((int)ConstantNodes.ConsultationDecisions.Rejected).ToString())
                {
                    dto.DomainModel.Status = "Rejected";
                }
            }
            else if(dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.UCP_Admin__NodeId  || dto.activity.Identity.NodeId == ConstantNodes.DM_NodeID) && dto.ManagerDecision.Id == ((int)ConstantNodes.EnumITStatus.Rejected).ToString())
            {
                    dto.DomainModel.Status = "Rejected";
            }
            
                var entity = FindOneById(dto.DomainModel.Id);
                if (dto.DomainModel.Id == entity.Id)
                {
                  Mapper.Map(dto.DomainModel, entity);
                }

                await UpdateRequest();

            if(dto.DomainModel.Status == "Rejected")
            {
                await DeleteAvailability(dto);
            }

            var ConsulationCompletionViewModel = new EditConsultationDataViewModel();

            if (dto.DomainModel.Status != null )
            {

                Mapper.Map(dto.DomainModel, ConsulationCompletionViewModel);

                var jsonPatch = new JsonPatchDocument<EditConsultationDataViewModel>();
                jsonPatch.Replace(m => m.Status, ConsulationCompletionViewModel.Status);
                jsonPatch.Replace(m => m.IsConfidential, ConsulationCompletionViewModel.IsConfidential);
                logger.LogDebug("jsonPatch", (jsonPatch));

                var responce = await _uacService.PatchConsultationData(jsonPatch, dto.DomainModel.JobId);
                logger.LogDebug("responce", (responce));
            }
            if (dto.Attachement != null)
            {
                FileService.UploadRequestFiles(typeof(ConsultationDTO), dto,
            AppConfiguaraton.ConsultaionAttachementPath,
            dto.DomainModel.JobId, AppConfiguaraton.ConsultaionAttachementListName,
            string.Empty, dto.Requester.Username, multiTypes: false,
            uploadToSharepoint: true, multi: true);
            }
            await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);

            return dto;
        }

        public async Task<IList<UniversityModel>> GetUniversities()
        {
            var response = await _uacService.GetAllUniversity();
            return response;
        }

        public async Task<IList<FellowModel>> GetFellows(int universityId)
        {
            var response = await _uacService.GetFellowsByUniversity(universityId);
            return response;
        }

        public async Task<(IList<ListModel> Areas , int Rating)> GetAreas(string fellowEmail)
        {
            var response = await _uacService.GetFellowResearchAreas(fellowEmail);
            var rating = GetRating(fellowEmail);

            return (Areas: response, Rating: rating);
        }
        public int GetRating(string ConsultantEmail)
        {
            var consultantRatingItems = _consultantEvaluationservice.GetQuerable().Where(x => x.ConsultantEmail == ConsultantEmail).DefaultIfEmpty();
            var consultantRating = Mapper.Map<List<RatingModel>>(consultantRatingItems);
            int numberOfRatings = consultantRating.Count();
            int rating = 0;

            if (consultantRating[0] != null)
            {
                foreach (var item in consultantRating)
                {
                    rating += item.Rating;
                }
                rating = rating / numberOfRatings;
            }
            return rating;

        }

        public async Task<List<ConsultationRequestsHistory>> GetConsultationRequestsHistory(string employeeEmail)
        {
          
            var items =  GetQuerable().Where(x => x.EmployeeEmail == employeeEmail).DefaultIfEmpty();
            var ConsultationRequestsHistory = Mapper.Map<List<ConsultationRequestsHistory>>(items);
            return ConsultationRequestsHistory;

        }

        //public async Task<ConsultantAvailabilityModel> CheckAvailability(string consultantEmail, DateTime? startDate, DateTime? endDate)
        //{
            
        //    var ConsultantAvailabilityList = new ConsultantAvailabilityModel();
        //    var items = _availabilityservice.GetQuerable().Where(x => x.ConsultantEmail == consultantEmail).DefaultIfEmpty();
        //    var ConsultatntAvailbleitems = Mapper.Map<List<ConsultantAvailability>>(items);

        //    if (ConsultatntAvailbleitems[0] != null)
        //    {
        //        foreach (var item in ConsultatntAvailbleitems)
        //        {
        //            if (item.Year == DateTime.Now.Year)
        //            {
        //                if (item.Days < Convert.ToInt32(AppConfiguaraton.ConsultantMaxDays) && (startDate < item.StartDate || startDate > item.EndDate) && (endDate > item.EndDate || endDate < item.StartDate))
        //                {
        //                    ConsultantAvailabilityList.IsAvailable = true;
        //                    ConsultantAvailabilityList.RemainingDays = Convert.ToInt32(AppConfiguaraton.ConsultantMaxDays) - item.Days;
        //                }
        //                else
        //                {
        //                    ConsultantAvailabilityList.IsAvailable = false;
        //                    ConsultantAvailabilityList.RemainingDays = 0;
        //                }

        //            }
        //            else if (item.Year != DateTime.Now.Year)
        //            {
        //                ConsultantAvailabilityList.IsAvailable = true;
        //                ConsultantAvailabilityList.RemainingDays = Convert.ToInt32(AppConfiguaraton.ConsultantMaxDays);

        //            }
        //        }
        //    }
        //    else
        //    {
        //        ConsultantAvailabilityList.IsAvailable = true;
        //        ConsultantAvailabilityList.RemainingDays = Convert.ToInt32(AppConfiguaraton.ConsultantMaxDays);

        //    }

        //    return ConsultantAvailabilityList;

        //}

        public async Task<ConsultantAvailabilityModel> GetConsultantAvailability(string consultantEmail, DateTime? startDate, DateTime? endDate , int Duaration)
       {

            var ConsultantAvailabilityList = new ConsultantAvailabilityModel();
            var items = _availabilityservice.GetQuerable().Where(x => x.ConsultantEmail == consultantEmail).DefaultIfEmpty().ToList();
            int totalDuration = 0;
            ConsultantAvailabilityList.RemainingDays = 0;


            if (items[0] != null)
            {
                foreach (var item in items)
                {
                    var requestYear = DateTime.Parse(startDate.ToString()).Year;
                    if (item.Year == requestYear)
                    {
                        if ((startDate < item.StartDate || startDate > item.EndDate) && (endDate > item.EndDate || endDate < item.StartDate))
                        {
                            ConsultantAvailabilityList.IsAvailable = true;
                            totalDuration += item.Days;
                        }
                        else
                        {
                            ConsultantAvailabilityList.IsAvailable = false;
                            break;
                        }
                    }
                    else 
                    {
                        ConsultantAvailabilityList.IsAvailable = true;
                        totalDuration = Duaration;

                    }
                }
            }
            else
            {
                ConsultantAvailabilityList.IsAvailable = true;
                totalDuration = Duaration;
            }


            if(ConsultantAvailabilityList.IsAvailable)
            {
                if(totalDuration < (Convert.ToInt32(AppConfiguaraton.ConsultantMaxDays)))
                {
                    ConsultantAvailabilityList.RemainingDays = Convert.ToInt32(AppConfiguaraton.ConsultantMaxDays) - totalDuration;
                }
                else 
                {
                    ConsultantAvailabilityList.IsAvailable = false;
                }
            }

            return ConsultantAvailabilityList;

        }


        public async Task AddAvailability(ConsultationDTO dto)
        {
            var ConsultantAvailability = new ConsultantAvailability();
            ConsultantAvailability.ConsultationRequestId = dto.DomainModel.Id;
            ConsultantAvailability.ConsultantEmail = dto.DomainModel.ConsultantEmail;
            ConsultantAvailability.StartDate = dto.DomainModel.DateFrom;
            ConsultantAvailability.EndDate = dto.DomainModel.DateTo;
            ConsultantAvailability.Days = dto.DomainModel.Duration;
            ConsultantAvailability.Year = DateTime.Parse(ConsultantAvailability.StartDate.ToString()).Year; ;

            await _availabilityservice.AddNewRequest(ConsultantAvailability);

        }

        public async Task DeleteAvailability(ConsultationDTO dto)
        {
            var ConsultantAvailability = new ConsultantAvailability();
            var ConsultantAvailabilityItem = _availabilityservice.Find(x => x.ConsultationRequestId == dto.DomainModel.Id).FirstOrDefault();
            await _availabilityservice.DeleteRequest(ConsultantAvailabilityItem);

        }


    }

  
}
