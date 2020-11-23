using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.Common;
using EservicesDomain.Common;
using EservicesDomain.Domain.ITSoftware;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EServicesApplication.Services;
using static EservicesDomain.Common.ConstantNodes;
using System;

namespace EServicesApplication.Service.ITSoftware
{
    public class SoftwareService : BaseService<Software, int>, ISoftwareService
    {

        private IBaseService<SoftwareApps, int> _itSoftwareAppsService;
        private IBaseService<SoftwareCategory, int> _itSoftwareCategoryService;
        private IBaseService<SoftwareContractor, int> _itSoftwareContractorService;
        private IBaseService<SoftwareRequestItems, int> _itSoftwareRequestItemsService;


        public SoftwareService(
            IBaseService<SoftwareApps, int> ItSoftwareAppsService,
            IBaseService<SoftwareCategory, int> ItSoftwareCategoryService,
            IBaseService<SoftwareContractor, int> ItSoftwareContractorService,
            IBaseService<SoftwareRequestItems, int> ItSoftwareRequestItemsService
            )
        {

            _itSoftwareAppsService = ItSoftwareAppsService;
            _itSoftwareCategoryService = ItSoftwareCategoryService;
            _itSoftwareContractorService = ItSoftwareContractorService;
            _itSoftwareRequestItemsService = ItSoftwareRequestItemsService;

        }

        public async Task<SoftwareDTO> GetRequestData(RequestDataModel data)
        {
            logger.LogDebug("GetRequestData method fired with these parameters", data);
            var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);
            var dto = await PrepareDTO(data);
            dto.Requester= await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.Decisions = decisionService.GetDecisionList(activity.HelpText);
            dto.activity = activity;
            return dto;
        }
        public async Task<SoftwareDTO> ReviewRequestData(RequestDataModel data)
        {
            logger.LogDebug("ReviewRequestData method fired with these parameters", data);
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);
            var dto = await PrepareDTO(data);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.activity = activity;
            dto.IsReviewMode = true;
            return dto;
        }

        public async Task<SoftwareDTO> SaveRequestData(SoftwareDTO dto)
        {

            Mapper.Map(dto.ITSoftwareRequestItems, dto.DomainModel.ITSoftwareRequestItems);

            dto.DomainModel.RDate= DateTime.Now;
            await AddNewRequest(dto.DomainModel);
            logger.LogDebug($"SessionId {dto.SessionId} , process ID {AppConfiguaraton.ITSoftwareProcessID} , DomainModel.Id {dto.DomainModel.Id} ");

            dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.ITSoftwareProcessID, dto.DomainModel.Id);
            logger.LogDebug($"Create Job ID fired {dto.DomainModel.JobId}");
            await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);
            logger.LogDebug($"Create Job ID fired {dto.DomainModel.JobId}");
            return dto;
        }

        public async Task<SoftwareDTO> ProcessRequest(SoftwareDTO dto)
        {
            logger.LogDebug($"ProcessRequest method fired {dto.JobID} and {dto.NodeID}");

            logger.LogDebug($"TakeActivity method fired {dto.SessionId} and {dto.DomainModel.JobId} and { dto.NodeID} and {dto.EPC}");

            if (dto.activity == null)
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);
            if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.DirectManager_NodeId|| dto.activity.Identity.NodeId == ConstantNodes.ITSolutions_NodeId|| dto.activity.Identity.NodeId == ConstantNodes.NodeId_EmployeeUpdate|| dto.activity.Identity.NodeId == ConstantNodes.HelpDesk_NodeId
                || dto.activity.Identity.NodeId == ConstantNodes.DepartmentManager_NodeId||dto.activity.Identity.NodeId == ConstantNodes.NodeId_EmployeeUpdate))
            {
                    dto.DomainModel.ITSoftwareRequestItems =  await Task.Run(() => SetSoftwareRequestItems(dto));
                   
                   var entity = FindOneById(dto.DomainModel.Id);
                  if (dto.DomainModel.Id == entity.Id)
                  {
                    Mapper.Map(dto.DomainModel, entity);
                  }

                await UpdateRequest();

            }

            logger.LogDebug($"CompleteActivity method fired SessionId {dto.SessionId} and Username {dto.Requester.Username} and Id { dto.ManagerDecision.Id} and Comment {dto.ManagerDecision.Comment} and Identity {dto.activity.Identity}");

            await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);

            return dto;
        }
        public List<SoftwareApps> RetreiveSoftwareApps(int SelectedCategoryId)
        {
            //Retrive the Other Catogary equal "1"
            var items = _itSoftwareAppsService.Find(x => x.CategoryID == SelectedCategoryId);

            var result = Mapper.Map<List<SoftwareApps>>(items);

            return result;
        }

        public List<SoftwareCategory> RetreiveSoftwareCategories()
        {
            var items = _itSoftwareCategoryService.GetAll();

            var result = Mapper.Map<List<SoftwareCategory>>(items);

            return result;
        }
        #region helpers
        private async Task<SoftwareDTO> PrepareDTO(RequestDataModel data)
        {
            SoftwareDTO dto = new SoftwareDTO();

            
            dto.DomainModel =  await GetQuerable().Where(x => x.JobId == data.JobId).Include(x => x.ITSoftwareContractor).FirstOrDefaultAsync();

            //Get Software items
            var SoftwareItems =  _itSoftwareRequestItemsService.GetQuerable().Where(x => x.RequestID == dto.DomainModel.Id).Include(x => x.ITStatuses).Include(x => x.ITSoftwareApps).Include(x => x.ITSoftwareApps.ITSoftwareCategory);
           
            var itSoftwareRequestItems = new List<SoftwareRequestItemsModel>();

            foreach (var item in SoftwareItems)
            {
                var tobeAdded = Mapper.Map<SoftwareRequestItemsModel>(item);
                tobeAdded.RequestDate = dto.DomainModel.RDate;
                itSoftwareRequestItems.Add(tobeAdded);
            }

            dto.ITSoftwareRequestItems = itSoftwareRequestItems;

            dto.EmployeeRequestsHistory = RetriveHistory(dto.DomainModel.EmployeeEmail);

            return dto;
        }

       
        public List<SoftwareRequestItemsModel> RetriveHistory(string EmpEmail)
        {
            var EmployeeRequestsHistoryitems = new List<SoftwareRequestItemsModel>();
            var requests = _itSoftwareRequestItemsService.GetQuerable().Include(x => x.ITStatuses).Include(x => x.ITSoftware).Where(x => x.ITSoftware.EmployeeEmail==EmpEmail).Include(x => x.ITSoftwareApps).Include(x => x.ITSoftwareApps.ITSoftwareCategory).OrderByDescending(x => x.ITSoftware.RDate);

          
                foreach (var item in requests)
                {
                    var tobeAdded = Mapper.Map<SoftwareRequestItemsModel>(item);
                    tobeAdded.RequestDate = item.ITSoftware.RDate;
                    EmployeeRequestsHistoryitems.Add(tobeAdded);

                }
          
            return EmployeeRequestsHistoryitems;
        }
        #endregion

        private List<SoftwareRequestItems> SetSoftwareRequestItems(SoftwareDTO dto)
        {
            var itSoftwareRequestItems = new List<SoftwareRequestItems>();


            foreach (var item in dto.ITSoftwareRequestItems)
            {

                if (item.Status == null)
                {
                    if (dto.ManagerDecision != null && dto.ManagerDecision.Id == ((int)EnumITStatus.Approved).ToString())
                    {
                        item.Status = EnumITStatus.Approved.ToString();
                    }
                    else if (dto.ManagerDecision != null && dto.ManagerDecision.Id == ((int)EnumITStatus.Rejected).ToString())
                    {
                        item.Status = EnumITStatus.Rejected.ToString();
                    }
                    else if (dto.ManagerDecision != null && dto.ManagerDecision.Id == ((int)EnumITStatus.ReturnToEmp).ToString())
                    {
                        item.Status = EnumITStatus.ReturnToEmp.ToString();
                    }
                    else if (dto.ManagerDecision != null && dto.ManagerDecision.Id == ((int)EnumITStatus.ForwardToITGov).ToString())
                    {
                        item.Status = EnumITStatus.ForwardToITGov.ToString();
                    }
                    else if (dto.ManagerDecision != null && dto.ManagerDecision.Id == ((int)EnumITStatus.Executed).ToString())
                    {
                        if (dto.activity.Identity.NodeId == ConstantNodes.HelpDesk_NodeId|| dto.activity.Identity.NodeId == ConstantNodes.NodeId_EmployeeUpdate)
                            item.Status = EnumITStatus.Executed.ToString();

                    }
                    else if (dto.ManagerDecision != null && dto.ManagerDecision.Id == ((int)EnumITStatus.NotExecuted).ToString())
                    {
                        if (dto.activity.Identity.NodeId == ConstantNodes.HelpDesk_NodeId)
                            item.Status = EnumITStatus.NotExecuted.ToString();
                    }
                  
                }
                else if (item.Status != "Rejected" && item.Status != "ForwardToITGov")
                { item.Status = ((EnumITStatus)int.Parse(item.Status)).ToString(); }

                item.UpdatedBy = dto.Requester.Username;
                item.RequestID = dto.DomainModel.Id;
                var tobeAdded = Mapper.Map<SoftwareRequestItems>(item);
                itSoftwareRequestItems.Add(tobeAdded);
            }

            return itSoftwareRequestItems;

        }

    }
}
