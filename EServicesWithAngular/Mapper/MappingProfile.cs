using AutoMapper;
using CommonLibrary.Configuaration;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Service.UCcompletion;
using EServicesApplication.Service.UCconsultation;
using EServicesApplication.Service.ITEmailGroup;
using EServicesApplication.Service.ITSoftware;
using EServicesApplication.Services.AdminTranslation;
using EServicesApplication.Services.Common;
using EServicesApplication.Services.Resignation;
using EServicesApplication.Services.WorkFlow;
using EServicesCommon.Common;
using EServicesCommon.DI;
using EservicesDomain.Domain;
using EservicesDomain.Domain.AdTranslation;
using EservicesDomain.Domain.DomainAgility;
using EservicesDomain.Domain.UCcompletion;
using EservicesDomain.Domain.ITGroupEmail;
using EservicesDomain.Domain.ITServerAccess;
using EservicesDomain.Domain.SiteCreation;
using EservicesDomain.Domain.ITSoftware;
using EservicesDomain.Domain.Workflow;
using EservicesDomain.ExternalDomain.ERB;
using EservicesDomain.ExternalDomain.KTA;
using EServicesWithAngular.Models;
using System;
using EservicesDomain.Domain.UC;
using EservicesDomain.ExternalDomain.UAC;

namespace EServicesWithAngular.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

        //CreateMap<EmpTransModel, Event>().
        //    ForMember(d => d.Title, opt => opt.MapFrom(s => s.RequestType)).
        //    ForMember(d => d.Start, opt => opt.MapFrom(s => s.From)).
        //    ForMember(d => d.End, opt => opt.MapFrom(s => s.To));

        CreateMap<DecisionChoices, DecisionItemModel>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Lookup_Item_ID))
                .ForMember(d => d.CommentsAreMandatory, opt => opt.MapFrom(s => s.CommentsMandatory));


            CreateMap<CompletedTasks, PassedItems>()
                .ForMember(d => d.ProcessName, opt => opt.MapFrom(s => s.PROCESS_NAME))
                .ForMember(d => d.CurrentLocation, opt => opt.MapFrom(s => s.currentLocation))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.CREATION_TIME))
                .ForMember(d => d.Requestor, opt => opt.MapFrom(s => s.requestor))
                .ForMember(d => d.JOB_ID, opt => opt.MapFrom(s => BitConverter.ToString(s.JOB_ID).Replace("-", "")))
                .ForMember(d => d.AssociatedFile, opt => opt.MapFrom(s => s.ASSOCIATED_FILE));

            CreateMap<ITResignationItemStatus, ITResignationStatusModel>()
              .ForMember(d => d.ItemId, opt => opt.MapFrom(s => s.ItemId))
              .ForMember(d => d.RequestId, opt => opt.MapFrom(s => s.RequestId))
              .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
              .ForMember(d => d.ItemId, opt => opt.MapFrom(s => s.ItemId))
              .ForMember(d => d.ItemNameAr, opt => opt.MapFrom(s => s.ITResignationItem.ItemAR))
              .ForMember(d => d.ItemNameEn, opt => opt.MapFrom(s => s.ITResignationItem.ItemEN));

            CreateMap<ITResignationStatusModel, ITResignationItemStatus>()
           .ForMember(d => d.ItemId, opt => opt.MapFrom(s => s.ItemId))
           .ForMember(d => d.RequestId, opt => opt.MapFrom(s => s.RequestId))
           .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
           .ForMember(d => d.ItemId, opt => opt.MapFrom(s => s.ItemId));

            CreateMap<AllRequests, AllRequestPassedItem>()

            .ForMember(d => d.JOB_ID, opt => opt.MapFrom(s => BitConverter.ToString(s.JOB_ID).Replace("-", "")));
            CreateMap<ITResignationItem, ITResignationStatusModel>()
           .ForMember(d => d.ItemNameAr, opt => opt.MapFrom(s => s.ItemAR))
           .ForMember(d => d.ItemNameEn, opt => opt.MapFrom(s => s.ItemEN));


            CreateMap<ADService.ADReturned, EmployeeModel>()
            .ForMember(d => d.EmployeeEmail, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.FullName));

            CreateMap<ADService.ADReturned, EservicesDomain.ExternalModel.ERB.Employee>()
             .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
             .ForMember(d => d.EmployeeNameEn, opt => opt.MapFrom(s => s.FullName))
             .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => s.FullName))
             .ForMember(d => d.EmployeeNameAr, opt => opt.MapFrom(s => s.FullName))
             .ForMember(d => d.OfficeLocation, opt => opt.MapFrom(s => s.OfficeNum.GetLast(3)));



            CreateMap<EmployeeRest, EservicesDomain.ExternalModel.ERB.Employee>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.EmployeeNameEn, opt => opt.MapFrom(s => s.EnglishName))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.HireDate, opt => opt.MapFrom(s => s.HireDate.ToShortDateString()));


            CreateMap<EservicesDomain.ExternalDomain.ERB.Department, EservicesDomain.ExternalModel.ERB.Employee>()
            .ForMember(d => d.DepartmentEn, opt => opt.MapFrom(s => s.EnglishName))
            .ForMember(d => d.EmployeeDepartment, opt => opt.MapFrom(s => s.EnglishName))
            .ForMember(d => d.DepartmentAr, opt => opt.MapFrom(s => s.ArabicName));


            CreateMap<ITStatus, ListItemModel<string>>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.NameAr, opt => opt.MapFrom(s => s.StatusTextAr));

            CreateMap<CoreApproval, HistoricalRecord>()
            .ForMember(d => d.ActivityName, opt => opt.MapFrom(s => s.Role))
            .ForMember(d => d.Comment, opt => opt.MapFrom(s => s.Notes))
            .ForMember(d => d.DecisionId, opt => opt.MapFrom(s => s.Comment));

            CreateMap<ITResignationItem, ITResignationStatusModel>()
            .ForMember(d => d.ItemId, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.ItemNameAr, opt => opt.MapFrom(s => s.ItemAR))
            .ForMember(d => d.ItemNameEn, opt => opt.MapFrom(s => s.ItemEN));

            CreateMap<ITResignationItemStatus, ITResignationStatusModel>()
            .ForMember(d => d.ItemId, opt => opt.MapFrom(s => s.ItemId))
            .ForMember(d => d.RequestId, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
            .ForMember(d => d.UpdatedBy, opt => opt.MapFrom(s => s.UpdatedBy))
            .ForMember(d => d.Notes, opt => opt.MapFrom(s => s.Notes))
            .ForMember(d => d.ItemNameAr, opt => opt.MapFrom(s => s.ITResignationItem.ItemAR))
            .ForMember(d => d.ItemNameEn, opt => opt.MapFrom(s => s.ITResignationItem.ItemEN));

            CreateMap<ConsultationRequest, ConsultationRequest>();
            CreateMap<ConsultationCompletionRequest, ConsultationCompletionRequest>();
            CreateMap<ConsultationRequest, ConsultationModel>();
           
            CreateMap<AdminTranslator, TranslatorsModel>()
             .ForMember(d => d.TransEmail, opt => opt.MapFrom(s => s.TranslatorEmail));

            CreateMap<EmailGroupMember, GroupMembersModel>()
             .ForMember(d => d.MemberEmail, opt => opt.MapFrom(s => s.MemberEmail));

            CreateMap<GroupMembersModel, EmailGroupMember>()
            .ForMember(d => d.MemberEmail, opt => opt.MapFrom(s => s.MemberEmail));
            
            CreateMap<EmailGroupMember, EmailGroupMember>();
            CreateMap<EmailGroup, EmailGroup>();

            CreateMap<ITAccount, ITAccount>();

            CreateMap<SoftwareRequestItems, SoftwareRequestItemsModel>()
              .ForMember(d => d.CurrentStatus_En, opt => opt.MapFrom(s => s.ITStatuses.StatusTextEn))
              .ForMember(d => d.CurrentStatus_Ar, opt => opt.MapFrom(s => s.ITStatuses.StatusTextAr))
              .ForMember(d => d.CategoryName_En, opt => opt.MapFrom(s => s.ITSoftwareApps.ITSoftwareCategory.CategoryNameEN));

            CreateMap<SoftwareRequestItemsModel, SoftwareRequestItems>();
              
            CreateMap<Software, Software>();

            CreateMap<SoftwareApps, SoftwareApps>();

            CreateMap<SoftwareCategory, SoftwareCategory>();

            CreateMap<SoftwareRequestItems, SoftwareRequestItems>(); 

            CreateMap<SoftwareContractor, SoftwareContractor>();

            CreateMap<SPSiteCreation, SPSiteCreation>();

            CreateMap<SPSiteListsAndLibraries, SPSiteListsAndLibraries>();

            CreateMap<SPSiteMember, SPSiteMember>();

            CreateMap<ServerDetails, ServerDetails>();

            CreateMap<ServerAccess, ServerAccess>();

            CreateMap<ConsultationRequest, NewConsultationViewModel>();
            CreateMap<ConsultationRequest, ConsultationRequestsHistory>()
            .ForMember(d => d.EmployeeEmail, opt => opt.MapFrom(s => s.EmployeeEmail))
            .ForMember(d => d.RefId, opt => opt.MapFrom(s => s.RefId))
            .ForMember(d => d.ConsultantName, opt => opt.MapFrom(s => s.ConsultantName))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
             .ForMember(d => d.ResearchTitle, opt => opt.MapFrom(s => s.ResearchTitle))
              .ForMember(d => d.ResearchType, opt => opt.MapFrom(s => s.ResearchType));

            CreateMap<ConsultationCompletionRequest, EditConsultationDataViewModel>();
            CreateMap<ConsultationRequest, EditConsultationDataViewModel>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status));

            CreateMap<ConsultationQuestions, ConsultantEvaluationModel>()
           .ForMember(d => d.Question, opt => opt.MapFrom(s => s.Question))
            .ForMember(d => d.QuestionId, opt => opt.MapFrom(s => s.Id));


            CreateMap<ConsultantEvaluationItems, ConsultantEvaluationModel>()
            
            .ForMember(d => d.Question, opt => opt.MapFrom(s => s.Question))
            .ForMember(d => d.QuestionId, opt => opt.MapFrom(s => s.QuestionId))
            .ForMember(d => d.Answer, opt => opt.MapFrom(s => s.Answer))
            .ForMember(d => d.AnswerText, opt => opt.MapFrom(s => s.AnswerText));


            CreateMap< ConsultantEvaluationModel , ConsultantEvaluationItems>()

            .ForMember(d => d.Question, opt => opt.MapFrom(s => s.Question))
            .ForMember(d => d.QuestionId, opt => opt.MapFrom(s => s.QuestionId))
            .ForMember(d => d.Answer, opt => opt.MapFrom(s => s.Answer))
            .ForMember(d => d.AnswerText, opt => opt.MapFrom(s => s.AnswerText));

            CreateMap<ConsultantEvaluation, RatingModel>()

           .ForMember(d => d.Rating, opt => opt.MapFrom(s => s.Rating));

        }
    }
}
