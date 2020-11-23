using EServicesApplication.Interfaces.Services;
using EServicesApplication.Services;
using EServicesApplication.Services.Common;
using EServicesApplication.Services.ITEmailGroup;
using EservicesDomain.Common;
using EservicesDomain.Domain;
using EservicesDomain.Domain.ITGroupEmail;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesApplication.Service.ITEmailGroup
{
   public class EmailGroupService : BaseService<EmailGroup, int>, IService<EmailGroupDTO>
    {
        public async Task<EmailGroupDTO> GetRequestData(RequestDataModel data)
        {
           var activity = await KtaService.TakeActivityAsync(data.SessionId, data.JobId, data.NodeId, data.epc);
            var dto = await GetEmailGroup(data);
            dto.AddGroupEmail();
            if (data.NodeId == ConstantNodes.NodeId_ITSystems )
               dto.createEmailGroup = true;
            dto.Decisions =  decisionService.GetDecisionList(activity.HelpText);
            dto.Requester = await employeeService.FindEmployeeWithEmailAsync(dto.DomainModel.EmployeeEmail);
            dto.activity = activity;
            return dto;
            
        }

        public async Task<EmailGroupDTO> ReviewRequestData(RequestDataModel data)
        {
            var activity = KtaService.OpenActivityInReviewMode(data.SessionId, data.JobId, data.NodeId, data.epc);
            var dto = await GetEmailGroup(data);
            dto.activity = activity;
            dto.IsReviewMode = true;
            return dto;
        }


        public async Task<EmailGroupDTO> SaveRequestData(EmailGroupDTO dto)
        {
          await AddGroupMemberItems(dto);
          await AddNewRequest(dto.DomainModel);
            logger.LogDebug($"SessionId {dto.SessionId} , process ID {AppConfiguaraton.KTAProcessIdEmailGroup} , DomainModel.Id {dto.DomainModel.Id} ");
            dto.DomainModel.JobId = await KtaService.CreateJobAsync(dto.SessionId, AppConfiguaraton.KTAProcessIdEmailGroup, dto.DomainModel.Id);
            logger.LogDebug($"Create Job ID fired {dto.DomainModel.JobId}");

            await UpdateKtaJobID(dto.DomainModel.Id, dto.DomainModel.JobId);
            logger.LogDebug($"Update Job ID fired {dto.DomainModel.JobId}");


            return dto;
        }

        public async Task<EmailGroupDTO> ProcessRequest(EmailGroupDTO dto)
        {
            if (dto.activity == null)
                dto.activity = await KtaService.TakeActivityAsync(dto.SessionId, dto.DomainModel.JobId, dto.NodeID, dto.EPC);

            if (dto.activity.Identity.NodeId == dto.NodeID && (dto.activity.Identity.NodeId == ConstantNodes.NodeId_ITSystems || dto.activity.Identity.NodeId == ConstantNodes.NodeId_EmployeeToUpdate))
            {
                 var entity =  FindOneById(dto.DomainModel.Id);

                if (dto.DomainModel.Id == entity.Id)
                {
                    Mapper.Map(dto.GroupMember, dto.DomainModel.GroupMembers);

                    Mapper.Map(dto.DomainModel, entity);
                }
                await UpdateRequest();
            }
            await KtaService.CompleteActivityAsync(dto.SessionId, dto.Requester.Username, dto.ManagerDecision.Id, dto.ManagerDecision.Comment, dto.activity.Identity);
            return dto;

        }

        private async Task<EmailGroupDTO> GetEmailGroup(RequestDataModel data)
        {
            //FindOneByJobId(jobId)
            //Inclufe other items so i need querable .include
            EmailGroupDTO dto = new EmailGroupDTO();
            dto.DomainModel = await GetQuerable().Where(x => x.JobId == data.JobId).Include(x => x.GroupMembers).FirstOrDefaultAsync();
            var items = dto.DomainModel.GroupMembers;
            dto.GroupMember = Mapper.Map<List<EmailGroupMember>>(items);

            return dto;
        }

        private async Task<EmailGroupDTO> AddGroupMemberItems(EmailGroupDTO dto)
        {
            var GroupMembersItems = new List<EmailGroupMember>();

            foreach (var item in dto.GroupMember)
            {
                var tobeAdded =  Mapper.Map<EmailGroupMember>(item);
                GroupMembersItems.Add(tobeAdded);
            }

            dto.DomainModel.GroupMembers = GroupMembersItems;
            return dto;
        }
    }
}
