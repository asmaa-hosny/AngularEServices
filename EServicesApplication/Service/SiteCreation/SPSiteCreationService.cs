
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services;
using EServicesApplication.Services.Common;
using EServicesApplication.Services.SiteCreation;
using EservicesDomain.Common;
using EservicesDomain.Domain.SiteCreation;
using EservicesDomain.ExternalModel.ERB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesApplication.Service.SiteCreation
{
    public class SPSiteCreationService : BaseService<SPSiteCreation, int>, IService<SPSiteCreationDTO>
    {


        public async Task<SPSiteCreationDTO> GetRequestData(RequestDataModel data)
        {
            var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);
            var dto = await GetSPSiteCreation(data);
            dto.Decisions =  decisionService.GetDecisionList(activity.HelpText);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.activity = activity;
            return dto;
        }

        public async Task<SPSiteCreationDTO> ReviewRequestData(RequestDataModel data)
        {
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);
            var dto = await GetSPSiteCreation(data);
            dto.DomainModel =  FindOneByJobId(data.JobId);
            dto.Requester = await GetCreationEmployeeData(dto.DomainModel.EmployeeEmail);
            dto.activity = activity;
            dto.IsReviewMode = true;
            return dto;
        }

        public async Task<SPSiteCreationDTO> SaveRequestData(SPSiteCreationDTO dto)
        {
            Mapper.Map(dto.MembersList, dto.DomainModel.ITSPSiteMember);
            bool IsAdminChecked = false;
            foreach(var item in dto.MembersList)
            {
                if (item.IsAdmin == true)
                {
                    dto.DomainModel.SiteOwnerEmail = item.MemberEmail;
                    IsAdminChecked = true;
                    break;
                }
            }
            if(IsAdminChecked == false)
            {
                dto.DomainModel.SiteOwnerEmail = dto.DomainModel.EmployeeEmail;
            }
            await AddNewRequest(dto.DomainModel);

            dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.SPSiteCreationProcessIdID, dto.DomainModel.Id);
            await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);

            return dto;
        }


        public async Task<SPSiteCreationDTO> ProcessRequest(SPSiteCreationDTO dto)
        {
            if (dto.activity == null)
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);
            if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.NodeId_SPAdminNodeId || dto.activity.Identity.NodeId == ConstantNodes.NodeId_SPAdminExecutionNodeId))
            {
               Mapper.Map(dto.MembersList, dto.DomainModel.ITSPSiteMember);
               Mapper.Map(dto.ListsAndLibraries, dto.DomainModel.ITSPSiteListsAndLibraries);
               var entity = FindOneById(dto.DomainModel.Id);
               Mapper.Map(dto.DomainModel, entity);
                
                await UpdateRequest();
        
            }

            await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);

            return dto;
        }


            
        public async Task<Employee> GetCreationEmployeeData(string email)
        {
            var employeedata = await employeeService.FindEmployeeWithEmailAsync(email);
            Employee employee = null;
            if (employeedata == null)
            {
                var adData = await ADService.GetDataFromAD(email);
                employee = Mapper.Map<Employee>(adData);
            }
            else
            {
                employee = Mapper.Map<Employee>(employeedata);
            }
            return employee;

        }

        public async Task<SPSiteCreationDTO> GetSPSiteCreation(RequestDataModel data)
        {
            //FindOneByJobId(jobId)
            //Inclufe other items so i need querable .include
            SPSiteCreationDTO dto = new SPSiteCreationDTO();
            dto.DomainModel = await GetQuerable().Where(x => x.JobId == data.JobId).DefaultIfEmpty().Include(x => x.ITSPSiteMember).FirstOrDefaultAsync(); 
            var ITSPSiteMembersItems = dto.DomainModel.ITSPSiteMember;
            dto.MembersList = Mapper.Map<List<SPSiteMember>>(ITSPSiteMembersItems);

            return dto;
        }

        


    }
}
