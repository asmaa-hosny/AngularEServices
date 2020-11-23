using CommonLibrary.Configuaration;
using Microsoft.Extensions.Configuration;
using System;


namespace EServicesCommon.Configuaration
{
    public class AppConfiguaration : ICoreConfigurations
    {
        #region Variables

        IConfiguration _config;

        #endregion

        #region Constructor

        public AppConfiguaration(IConfiguration config)
        {
            _config = config;
        }

        #endregion

        public string EserviceConnection => this._config["ConnectionStrings:DefaultConnection"];

        public int MaxPageSize => int.Parse(this._config["Core:MaxPageSize"]);

        public bool EnableCaching => Convert.ToBoolean(this._config["Core:EnableCaching"]);

        public bool EnableLogging => Convert.ToBoolean(this._config["Core:EnableLogging"]);

        public string KTA_SYSTEM_SESSION => Convert.ToString(this._config["KTASetting:KTA_SYSTEM_SESSION"]);

        public string KTAActivityService => Convert.ToString(this._config["ServiceURL:KTAActivityService"]);

        public bool ShowExceptionDetails => Convert.ToBoolean(this._config["Core:ShowExceptionDetails"]);

        public string SkeletonFolder => Convert.ToString(this._config["Core:SkeletonFolder"]);

        public string DomainName => Convert.ToString(this._config["Core:DomainName"]);

        public string DomainEmail => Convert.ToString(this._config["Core:DomainEmail"]);

        public string AddNewAccountFileName => Convert.ToString(this._config["KTAProcesses:ITAccount:AddNewAccountFileName"]);

        public string AddNewAccountFormat => Convert.ToString(this._config["KTAProcesses:ITAccount:AddNewAccountFormat"]);

       public string AddNewEmailGroupFileName => Convert.ToString(this._config["KTAProcesses:EmailGroup:AddNewEmailGroupFileName"]);

        public string KTAProcessIdITAccount => Convert.ToString(this._config["KTAProcesses:ITAccount:KTA_PROCESS_ID"]);
        public string KTAProcessIdConsultation => Convert.ToString(this._config["KTAProcesses:Consultation:KTA_PROCESS_ID"]);
        public string KTAProcessIdConsultationCompletion => Convert.ToString(this._config["KTAProcesses:ConsultationCompletion:KTA_PROCESS_ID"]);
        public string ConsultantMaxDays => Convert.ToString(this._config["KTAProcesses:Consultation:ConsultantMaxDays"]);

        
        public string KTAProcessIdEmailGroup => Convert.ToString(this._config["KTAProcesses:EmailGroup:KTA_PROCESS_ID"]);

        public string KTAProcessIdITResignation => Convert.ToString(this._config["KTAProcesses:ITResignation:KTA_PROCESS_ID"]);

        public string AddNewAccountPassword => Convert.ToString(this._config["KTAProcesses:ITAccount:AddNewAccountPassword"]);

        public string TraineeCompany => Convert.ToString(this._config["KTAProcesses:ITAccount:TraineeCompany"]);

        public string TraineeJobTitle => Convert.ToString(this._config["KTAProcesses:ITAccount:TraineeJobTitle"]);

        public string TraineeProject => Convert.ToString(this._config["KTAProcesses:ITAccount:TraineeProject"]);

        public string KTAJobService => Convert.ToString(this._config["ServiceURL:KTAJobService"]);

        public string KTAProcessService => Convert.ToString(this._config["ServiceURL:KTAProcessService"]);

        public string KTAResourceService => Convert.ToString(this._config["ServiceURL:KTAResourceService"]);

        public string KTAUserService => Convert.ToString(this._config["ServiceURL:KTAUserService"]);

        public string KTACookieName => Convert.ToString(this._config["KTASetting:KTACookieName"]);

        public string ITResignationProcessID => Convert.ToString(this._config["KTAProcesses:ITResignation:KTA_PROCESS_ID"]);
        public string SPSiteCreationProcessIdID => Convert.ToString(this._config["KTAProcesses:SiteCreation:KTA_PROCESS_ID"]);

        public string TranslationProcessID => Convert.ToString(this._config["KTAProcesses:AdminTranslation:KTA_PROCESS_ID"]);

        public string ITAttachementListName => Convert.ToString(this._config["KTAProcesses:ITResignation:ATTACHMENTS_LIST_NAME"]);

        public string TranslationAttachementListName => Convert.ToString(this._config["KTAProcesses:AdminTranslation:ATTACHMENTS_LIST_NAME"]);

        public string TranslationAttachementPath => Convert.ToString(this._config["Path:AdminTranslationAttachments"]);
        public string ConsultaionAttachementPath => Convert.ToString(this._config["Path:ConsultationAttachments"]);
        public string ConsultaionAttachementListName => Convert.ToString(this._config["KTAProcesses:Consultation:ATTACHMENTS_LIST_NAME"]);




        public string ITServerAccessProcessID  => Convert.ToString(this._config["KTAProcesses:ITServerAccess:KTA_PROCESS_ID"]);
        public string ITSoftwareProcessID => Convert.ToString(this._config["KTAProcesses:ITSoftware:KTA_PROCESS_ID"]);

        public string JsonFormat => Convert.ToString(this._config["Core:JSONFORMAT"]);

        #region ITCare
        public string ITCareAPI => Convert.ToString(this._config["ServiceURL:ITCare"]);

        public string ITCareService => Convert.ToString(this._config["ITCare:ITCareService"]);

        public string ITCareRefIdPrefix => Convert.ToString(this._config["ITCare:ItCareRefIdPrefix"]);

        public string ITCareAdminAPI => Convert.ToString(this._config["ServiceURL:ITCareAdmin"]);

        public string ITCareTechnicianKey => Convert.ToString(this._config["ITCare:TechnicianKey"]);

        public string ITCareCreate => Convert.ToString(this._config["ITCare:ITCareCreate"]);

        public string ITCareSortField => Convert.ToString(this._config["ITCare:ITCareSortField"]);

        public string ITCareFieldName => Convert.ToString(this._config["ITCare:ITCareFieldName"]);

        public string ITCareSortOrder => Convert.ToString(this._config["ITCare:ITCareSortOrder"]);

        public string ITCareTechnicianValue => Convert.ToString(this._config["ITCare:TechnicianValue"]);

        public string ITCareCategory => Convert.ToString(this._config["ITCare:ITCareCategory"]);

        public string ITCareRequest =>   Convert.ToString(this._config["ITCare:ITCareRequest"]);

        public string ITCareGetRequest =>  Convert.ToString(this._config["ITCare:ITCareGetRequest"]);

        public string ITCareAttachement =>  Convert.ToString(this._config["ITCare:ITCareAttachement"]);

        public string ITCareSubcategory =>  Convert.ToString(this._config["ITCare:ITCareSubcategory"]);

        public string ITCareSubcategoryItem =>  Convert.ToString(this._config["ITCare:ITCareItem"]);

        public string ITCareAPIName => Convert.ToString(this._config["ServiceName:ITCare"]);

        public string ITCareAdminAPIName => Convert.ToString(this._config["ServiceName:ITCareAdmin"]);

        #endregion

        #region UAC

        public string UACApiName => Convert.ToString(this._config["ServiceName:UACServiceName"]);

        public string UACServiceURL => Convert.ToString(this._config["ServiceURL:UACService"]);

        public string UACFellows => Convert.ToString(this._config["UAC:UACFellows"]);
        public string PostConsultation => Convert.ToString(this._config["UAC:PostConsultation"]);
        public string PatchConsultation => Convert.ToString(this._config["UAC:PatchConsultation"]);
        public string UACUniversity => Convert.ToString(this._config["UAC:UACUniversity"]);

        public string UACFellowResearchArea => Convert.ToString(this._config["UAC:UACFellowResearchArea"]);

        public string UACToken => Convert.ToString(this._config["UAC:UACToken"]);

        public string UACUserName => Convert.ToString(this._config["UAC:UACUserName"]);

        public string Password => Convert.ToString(this._config["UAC:Password"]);

        public string UCPCaptchaID => Convert.ToString(this._config["UAC:UCPCaptchaID"]);

        #endregion

        public string ERBAccountsService => throw new NotImplementedException();

        public string ERBCountryService => throw new NotImplementedException();

        public string ERBCurrencyService => throw new NotImplementedException();

      

        public string ERBEmployeeService => Convert.ToString(this._config["ServiceURL:ERBEmployee"]);

        public string ADServiceURL => Convert.ToString(this._config["ServiceURL:ADService"]);

        public string HadirAPI => Convert.ToString(this._config["ServiceURL:HadirAPI"]);

        public string HadirAPIName => Convert.ToString(this._config["ServiceName:HadirAPIName"]);

        public string ERBWebApiName => Convert.ToString(this._config["ServiceName:ERPWebAPIName"]);

        public string ERBRefListService => throw new NotImplementedException();

        public string SpSiteRoot => Convert.ToString(this._config["SharepointSetting:spSiteRoot"]);

        public string WebPartLocation => Convert.ToString(this._config["SharepointSetting:webPartLocation"]);

        public string AttachmentsSiteName => Convert.ToString(this._config["SharepointSetting:AttachmentsSiteName"]);

        public string ServiceEmail => Convert.ToString(this._config["Core:ServiceEmail"]);

        public string EmployeeRestService => Convert.ToString(this._config["ServiceURL:RestAPIEmployee"]);

        public string EmployeeRestServiceName => Convert.ToString(this._config["ServiceName:RestAPIEmployeeName"]);

        public string RequestsUserEmail => Convert.ToString(this._config["SearchFields:RequestsEmpEmail"]);

        public string TotalAgilityDBConnection => throw new NotImplementedException();

     
    }
}
