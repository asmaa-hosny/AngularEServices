using System;


namespace EservicesDomain.Common
{
    public class ConstantNodes
    {

        #region common
        public const short NodeId_RequestInitiation = 0;
        #endregion

        #region ITAccount
        public const short NodeId_ITSystemsHead = 456;
        public const short NodeId_ITSystemsTeam = 467;
        public const short NodeId_ITSystemEmployeeToUpdate = 461;
        #endregion

        #region ITResignation
        public const short NodeId_SharePoint = 352;
        public const short NodeId_VPN = 351;
        public const short NodeId_Email_AD = 350;
        public const short NodeId_Software_Licenses = 353;
        public const short NodeId_SFTP = 372;
        public const short NodeId_ERP = 377;
        public const short NodeId_FAX = 373;
        public const short NodeId_TelePhone = 374;
        public const short NodeId_Port = 375;
        public const short NodeId_Muraslat = 376;

        public enum EnumITStatus
        {
            Executed = 200,
            NotExecuted = 201,
            Approved = 100,
            Rejected = 101,
            ReturnToEmp = 300,
            ForwardToITGov = 402,
        }
        public enum InstructionsProcessName
        {
            Admin_Translation, 
        }
        
        #endregion

        #region AdminTranslation
        public const short NodeId_DBManager = 1;
        public const short NodeId_TransManager = 350;
        public const short NodeId_Translator = 352;

        public enum TranslationRequestType
        {
            Translation = 1,
            Review = 2,
        }

        #endregion

        #region EmailGroup and ITServerAccess
        public const short NodeId_ITSystems = 456;
        public const short NodeId_EmployeeToUpdate = 461;
        #endregion


        #region SiteCreation
        public const short NodeId_SiteOwnerNodeId = 1;
        public const short NodeId_SPAdminNodeId = 226;
        public const short NodeId_SPSupervisor = 231;
        public const short NodeId_SPAdminExecutionNodeId = 241;
        public enum PermissionsList
        {
            Read,
            Readwrite
        }
       
        public enum LibrariesList
        {
            List ,
            Library
        }
        public enum SiteTypesList
        {
            ProjectSite ,
            TeamSite ,
            AppSite
        }
        #endregion

        #region Software
        public const short DirectManager_NodeId = 1;
        public const short DepartmentManager_NodeId = 223;
        public const short NodeId_EmployeeUpdate = 351;
        public const short ITSolutions_NodeId = 359;
        public const short HelpDesk_NodeId = 363;
        public enum SoftwareRequestTypeList
        {
            Requester=1,
            Contractor = 2,
        }
        #endregion

        #region ConsultationCompletion
        public const short DM_NodeID = 1;
        public const short UCP_Admin__NodeId = 350;
        public const short Research_Collaboration_Committee = 352;

        public enum ConsultationStatus
        {
            InProgress = 1,
            Approved = 2,
            Rejected = 3,
            Completed = 4,
            Terminated = 5
        }
        public enum ConsultationDecisions
        {
            Approved = 700,
            Rejected = 701,
            
        }


        #endregion

    }



    public class SMSAccounts
    {
        public const String smsSPUsername = "SP-KACARE";
        public const String smsNCRPUsername = "NCRP";
        public const String smsHadirUsername = "Hadir";
        public const String smsDGPUsername = "NREDC";
        public const String smsKACAREUsername = "KACARE";
        public const String smsHRCAREUsername = "HRCARE";
        public const String smsJobCAREUsername = "JobCARE";
        public const String smsPOfficeUsername = "p-office";
        public const String smsVPNUsername = "VPN";
        public const String smsTest = "Test";
    }
    
}
