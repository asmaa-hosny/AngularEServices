using EServicesApplication.Interfaces.Persistence;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services.Common;
using EservicesDomain.Common;
using EservicesDomain.Domain;
using EservicesDomain.ExternalDomain.ERB;
using EservicesDomain.ExternalModel.ERB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EservicesDomain.Common.ConstantNodes;

namespace EServicesApplication.Services.Resignation
{
    public class ResignationService : BaseService<ITResignation, int>, IResignationService
    {
        private IBaseService<ITStatus, int> _itStatusService;
        private IBaseService<ITResignationItem, int> _itResingantionItemService;
        private IBaseService<ITResignationItemStatus, int> _itResignationItemStatusService;


        public ResignationService(
            IBaseService<ITStatus, int> ItStatusService,
            IBaseService<ITResignationItem, int> itResingantionItemService,
            IBaseService<ITResignationItemStatus, int> itResignationItemStatusService)
        {

            _itStatusService = ItStatusService;
            _itResingantionItemService = itResingantionItemService;
            _itResignationItemStatusService = itResignationItemStatusService;
        }

        public async Task<ITResignationDTO> GetRequestData(RequestDataModel data)
        {
            logger.LogDebug("GetRequestData method fired with these parameters", data);

            var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);

            var dto = await PrepareDTO(data);

            dto.Decisions = decisionService.GetDecisionList(activity.HelpText);

            dto.activity = activity;

            return dto;
        }



        public async Task<ITResignationDTO> ReviewRequestData(RequestDataModel data)
        {
            logger.LogDebug("ReviewRequestData method fired with these parameters", data);
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);

            var dto = await PrepareDTO(data,true);

            dto.IsReviewMode = true;

            dto.activity = activity;

            
            return dto;
        }

        public async Task<ITResignationDTO> SaveRequestData(ITResignationDTO dto)
        {
            logger.LogDebug("SaveRequestData method fired with these parameters");

            dto.Requester = await GetResignedEmployeeData(dto.DomainModel.EmployeeEmail);

            if (dto.Requester != null)
            {
                await AddNewRequest(dto.DomainModel);
                logger.LogDebug($"SessionId {dto.SessionId} , process ID {AppConfiguaraton.ITResignationProcessID} , DomainModel.Id {dto.DomainModel.Id} ");

                dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.ITResignationProcessID, dto.DomainModel.Id);

                await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);
            }
            else
            {
                logger.LogDebug($"{dto.DomainModel.EmployeeEmail} Resource Not Exist", dto.Requester);
            }

            return dto;
        }


        public async Task<ITResignationDTO> ProcessRequest(ITResignationDTO dto)
        {
            logger.LogDebug($"ProcessRequest method fired {dto.JobID} and {dto.NodeID}");

            logger.LogDebug($"TakeActivity method fired {dto.SessionId} and {dto.DomainModel.JobId} and { dto.NodeID} and {dto.EPC}");

            if (dto.activity == null)
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);

            if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.NodeId_SharePoint || dto.activity.Identity.NodeId == ConstantNodes.NodeId_VPN || dto.activity.Identity.NodeId == ConstantNodes.NodeId_Email_AD
                || dto.activity.Identity.NodeId == ConstantNodes.NodeId_Software_Licenses || dto.activity.Identity.NodeId == ConstantNodes.NodeId_SFTP || dto.activity.Identity.NodeId == ConstantNodes.NodeId_ERP||
                dto.activity.Identity.NodeId == ConstantNodes.NodeId_FAX || dto.activity.Identity.NodeId == ConstantNodes.NodeId_TelePhone || dto.activity.Identity.NodeId == ConstantNodes.NodeId_Port || dto.activity.Identity.NodeId == ConstantNodes.NodeId_Muraslat))
            {
                await AddResignationItems(dto);
            }
            logger.LogDebug($"CompleteActivity method fired SessionId {dto.SessionId} and Username {dto.Requester.Username} and Id { dto.ManagerDecision.Id} and Comment {dto.ManagerDecision.Comment} and Identity {dto.activity.Identity}");

            await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);

            return dto;
        }




        public List<ITResignationStatusModel> GetItems(short nodeId)
        {
            var items = _itResingantionItemService.Find(x => x.NodeId == nodeId);

            var result = Mapper.Map<List<ITResignationStatusModel>>(items);

            return result;
        }

        #region helpers

        private async Task<ITResignationDTO> AddResignationItems(ITResignationDTO dto)
        {
            var resignatoinItemStatus = new List<ITResignationItemStatus>();

            foreach (var item in dto.ItemStatus)
            {
                if (dto.ManagerDecision != null && dto.ManagerDecision.Id == ((int)EnumITStatus.Executed).ToString())
                {
                    if (item.Status == null)
                        item.Status = ((int)EnumITStatus.Executed).ToString();
                }
                else if (dto.ManagerDecision != null && dto.ManagerDecision.Id == ((int)EnumITStatus.NotExecuted).ToString())
                {
                    if (item.Status == null)
                        item.Status = ((int)EnumITStatus.NotExecuted).ToString();
                }
                item.RequestId = dto.DomainModel.Id;
                item.UpdatedBy = dto.Requester.Username;
                item.Status =((EnumITStatus)int.Parse(item.Status)).ToString();
                var tobeAdded = Mapper.Map<ITResignationItemStatus>(item);
                resignatoinItemStatus.Add(tobeAdded);
               
            }

            dto.DomainModel.ITResignationItemStatus = resignatoinItemStatus;
            await _itResignationItemStatusService.AddMultiple(dto.DomainModel.ITResignationItemStatus.ToList());

            return dto;


        }

        public async Task<Employee> GetResignedEmployeeData(string email)
        {
            var employeedata = await employeeService.GetEmployeeFromREST(email);
            Employee employee = null;
            if (employeedata == null)
            {
                var adData = await ADService.GetDataFromAD(email);
                employee = Mapper.Map<Employee>(adData);
            }
            else
            {
                employee = Mapper.Map<Department, Employee>(employeedata.Department);
                Mapper.Map<EmployeeRest, Employee>(employeedata, employee);
                return employee;
            }
            return employee;
        }

        private async Task<ITResignationDTO> PrepareDTO(RequestDataModel data, bool reviewMode= false)
        {
            ITResignationDTO dto = new ITResignationDTO();

            dto.DomainModel = FindOneByJobId(data.JobId);

            
            if (reviewMode == true)
            {
                var nodeItems = _itResignationItemStatusService.GetQuerable().Where(x => x.RequestId == dto.DomainModel.Id).Include(x => x.ITResignationItem);
                dto.ItemStatus = Mapper.Map<List<ITResignationStatusModel>>(nodeItems);

            }
            else
            {
                var nodeItems = _itResingantionItemService.Find(x => x.NodeId == data.NodeId);
                dto.ItemStatus = Mapper.Map<List<ITResignationStatusModel>>(nodeItems);

            }


            dto.Requester = await GetResignedEmployeeData(dto.DomainModel.EmployeeEmail);

            return dto;

        }

       

        #endregion


    }
}
