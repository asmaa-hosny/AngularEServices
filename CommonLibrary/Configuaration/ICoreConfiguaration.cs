

namespace CommonLibrary.Configuaration
{
    public interface ICoreConfigurations
    {
        string EserviceConnection { get; }

        string TotalAgilityDBConnection { get; }

        string ServiceEmail { get; }

        int MaxPageSize { get; }

        bool EnableCaching { get; }

        bool EnableLogging { get; }

        bool ShowExceptionDetails { get; }

        string KTA_SYSTEM_SESSION { get; }

        string SkeletonFolder { get; }

        string AddNewAccountFileName { get; }

        string AddNewEmailGroupFileName { get; }

        string AddNewAccountFormat { get; }

        string AddNewAccountPassword { get; }

        string DomainName { get; }

        string DomainEmail { get; }

        string TraineeCompany { get; }

        string TraineeJobTitle { get; }

        string TraineeProject { get; }

        string KTAActivityService { get; }

        string KTAJobService { get; }

        string KTAProcessService { get; }

        string KTAResourceService { get; }

        string KTAUserService { get; }

        string ERBAccountsService { get; }

        string ERBCountryService { get; }

        string ERBCurrencyService { get; }

        string ERBEmployeeService { get; }

        string EmployeeRestService { get; }

        public string UACApiName { get; }

        public string UACServiceURL { get; }

        public string ADServiceURL { get; }

        public string PostConsultation { get; }

        public string PatchConsultation { get; }

        public string UACFellows { get; }

        public string UACUniversity { get; }

        public string UACFellowResearchArea { get; }

        public string UACToken { get; }

        public string UACUserName { get; }

        public string Password { get; }

        public string UCPCaptchaID { get; }

        string EmployeeRestServiceName { get; }

        string HadirAPI { get; }

        string HadirAPIName { get; }

        string ERBRefListService { get; }

        string KTACookieName { get; }

        string SpSiteRoot { get; }

        string WebPartLocation { get; }

        string AttachmentsSiteName { get; }

        string ITResignationProcessID { get; }

        string ITAttachementListName { get; }

        string TranslationProcessID { get; }

        string ITSoftwareProcessID { get; }

        public string TranslationAttachementListName { get; }

        public string TranslationAttachementPath { get; }

        public string ConsultaionAttachementListName { get; }

        public string ConsultaionAttachementPath { get; }

        public string JsonFormat { get; }

        public string ITCareAPI { get; }

        public string ITCareAdminAPI { get; }

        public string ITCareTechnicianKey { get; }

        public string ITCareTechnicianValue { get; }

        public string ITCareCategory { get; }

        public string ITCareRequest { get; }

        public string ITCareGetRequest { get; }


        public string ITCareAttachement { get; }

        public string ITCareSubcategory { get; }

        public string ITCareSubcategoryItem { get; }

        public string ITCareService { get; }

        public string ITCareRefIdPrefix { get; }

        public string ITCareCreate { get; }

        public string ITCareFieldName { get; }

        public string ITCareSortOrder { get; }

        public string ITCareSortField { get; }

        public string ITCareAPIName { get; }

        public string ITCareAdminAPIName { get; }

        public string KTAProcessIdITAccount { get; }

        public string KTAProcessIdConsultation { get; }

        public string KTAProcessIdConsultationCompletion { get; }

        public string ConsultantMaxDays { get; }

        public string KTAProcessIdEmailGroup { get; }

        public string KTAProcessIdITResignation { get; }

        string SPSiteCreationProcessIdID { get; }

        public string RequestsUserEmail { get; }

        public string ERBWebApiName { get; }

        public string ITServerAccessProcessID { get; }



}
}
