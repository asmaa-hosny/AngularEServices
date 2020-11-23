using CommonLibrary.Configuaration;
using CommonLibrary.Logging;
using EServicesApplication.AgilityService;
using EServicesApplication.Clients;
using EServicesApplication.Interfaces.Common;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Interfaces.Persistence;
using EServicesApplication.Interfaces.Services;
using EServicesApplication.Service.Common;
using EServicesApplication.Service.dashboard;
using EServicesApplication.Service.ITEmailGroup;
using EServicesApplication.Service.ITSoftware;
using EServicesApplication.Service.SiteCreation;
using EServicesApplication.Service.UCcompletion;
using EServicesApplication.Service.UCconsultation;
using EServicesApplication.Services;
using EServicesApplication.Services.AdminTranslation;
using EServicesApplication.Services.ITAccounts;
using EServicesApplication.Services.ITEmailGroup;
using EServicesApplication.Services.ITServerAccess;
using EServicesApplication.Services.Resignation;
using EServicesApplication.Services.SiteCreation;
using EServicesApplication.Services.WorkFlow;
using EServicesApplication.Services.WorkFlow.Services;
using EServicesCommon.HttpMessageHandler;
using EServicesCommon.Logging;
using EservicesDomain.Domain.Workflow;
using EServicesInfrustructure.Network;
using EServicesPersistance.Common;
using EServicesWithAngular.ActionsFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EServicesWithAngular.Helpers
{
    public static class DIConfiguaration
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("MissionCompletionApi", c =>
            {
                c.BaseAddress = new Uri(configuration["ServiceURL:ERBMissionService"]);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient(configuration["ServiceName:HadirAPIName"], c =>
            {
                c.BaseAddress = new Uri(configuration["ServiceURL:HadirAPI"]);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient(configuration["ServiceName:RestAPIEmployeeName"], c =>
            {
                c.BaseAddress = new Uri(configuration["ServiceURL:RestAPIEmployee"]);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient(configuration["ServiceName:ERPWebAPIName"], c =>
            {
                c.BaseAddress = new Uri(configuration["ServiceURL:ERPWebAPI"]);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient(configuration["ServiceName:ERPWebAPIName"], c =>
            {
                c.BaseAddress = new Uri(configuration["ServiceURL:ERPWebAPI"]);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddHttpClient(configuration["ServiceName:ITCare"], c =>
            {
                c.BaseAddress = new Uri(configuration["ServiceURL:ITCare"]);
                c.DefaultRequestHeaders.Add(configuration["ITCare:TechnicianKey"], configuration["ITCare:TechnicianValue"]);
            });
            services.AddHttpClient(configuration["ServiceName:ITCareAdmin"], c =>
            {
                c.BaseAddress = new Uri(configuration["ServiceURL:ITCareAdmin"]);
                c.DefaultRequestHeaders.Add(configuration["ITCare:TechnicianKey"], configuration["ITCare:TechnicianValue"]);
            });
            services.AddHttpClient(configuration["ServiceName:UACServiceName"], c =>
            {
                c.BaseAddress = new Uri(configuration["ServiceURL:UACService"]);
                c.DefaultRequestHeaders.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
                .AddHttpMessageHandler(handler => new RetryPolicyDelegateHandler(3));


            services.AddHttpClient<UACClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["ServiceURL:UACService"]);
                client.DefaultRequestHeaders.Clear();
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
            .AddHttpMessageHandler(handler => new RetryPolicyDelegateHandler(2))
            .ConfigurePrimaryHttpMessageHandler(handler =>
                new HttpClientHandler()
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip,
                    //when windows authintication
                    Credentials = CredentialCache.DefaultNetworkCredentials

                }); ;


            services.AddScoped<ValidateModelAsyncFilter>();

            services.AddDbContext<DBContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<AgilityDBContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("TotalAgilityConnection"));
            });

            services.AddScoped<Func<string, IDatabaseContext>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "TAgility":
                        return serviceProvider.GetService<AgilityDBContext>();
                    case "EService":
                        return serviceProvider.GetService<DBContext>();
                    default:
                        return serviceProvider.GetService<DBContext>(); ;
                }
            });


            services.AddScoped<IDatabaseContext, DBContext>();
            services.AddScoped<IADServiceD, ADServiceDetail>();
            services.AddScoped<IWorkqueueService, WorkQueueService>();
            services.AddScoped<IService<ITAccountDTO>, ITAccountService>();
            services.AddScoped<IService<EmailGroupDTO>, EmailGroupService>();

            services.AddScoped<IUACService, UACService>();
            services.AddScoped<IConsultationService, ConsultationService>();
            services.AddScoped<IConsultationCompletionService, ConsultationCompletionService>();

            services.AddScoped<IITCareService, ITCareService>();

            services.AddScoped<IService<SPSiteCreationDTO>, SPSiteCreationService>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<ISPFacade, SPFacadeService>();

            services.AddScoped<ICoreApprovalService, CoreApprovalService>();

            services.AddScoped<IServiceDBContext, DBContext>();

            services.AddScoped<IAgilityDBContext, AgilityDBContext>();

            services.AddScoped<IAgilityService, AgilityBaseService>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IResignationService, ResignationService>();

            services.AddScoped<IAdminTranslationService, AdminTranslationService>();

            services.AddScoped<IService<ITServerAccessDTO>, ITServerAccessService>();

            services.AddScoped<ISoftwareService, SoftwareService>();

            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddScoped<IRestWrapper, RestWrapper>();

            services.AddScoped(typeof(IRepository<DecisionChoices, int>), typeof(Repository<DecisionChoices, int>));

            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped(typeof(IAgilityRepository<,>), typeof(AgilityRepository<,>));

            services.AddSingleton<ICoreConfigurations, EServicesCommon.Configuaration.AppConfiguaration>();

            services.AddScoped(typeof(IDecisionService), typeof(DecisionService));

            services.AddScoped<IKTAService, EServicesInfrustructure.Network.KTAService>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = implementationFactory.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

        }
    }
}
