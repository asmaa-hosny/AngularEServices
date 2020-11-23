using EServicesApplication.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using SharePointHelpClasses;
using EServicesCommon.DI;
using CommonLibrary.Configuaration;
using SharePointHelpClasses.CAML;
using Microsoft.SharePoint.Client;
using System.Linq;
using CommonLibrary.Logging;
using System.IO;

namespace EServicesInfrustructure.Network
{
    public class SPFacadeService : ISPFacade
    {

        public ICoreConfigurations _configuaration => FactoryManager.Instance.Resolve<ICoreConfigurations>();
        public ILoggerManager _logger => FactoryManager.Instance.Resolve<ILoggerManager>();

        private  SharePointHandler GetInstance(string listName)
        {
            return new SharePointHelpClasses.SharePointHandler(_configuaration.SpSiteRoot, _configuaration.AttachmentsSiteName, listName, null);
        }

        private  SharePointClientHandler GetInstanceOfClientHandler(string listName)
        {
            return new SharePointHelpClasses.SharePointClientHandler(_configuaration.SpSiteRoot, _configuaration.AttachmentsSiteName, listName, null);
        }


        public List<EservicesDomain.ExternalDomain.SP.Attachment> GetAttachments(string listName, string jobID)
        {
            SharePointHandler spClient = GetInstance(listName);
            string viewFieldsCluase = CamlBuilder.buildCamlViewFields(new string[] { "ID", "Name", "upLoaderName", "activityName", "Created" });
            string queryOptions = CamlBuilder.buildCamlQueryOptions(folder: listName + "/" + jobID, recursive: true);

            List<Dictionary<String, Object>> data = spClient.viewRecord(viewFieldsCluase, null, queryOptions);
            List<EservicesDomain.ExternalDomain.SP.Attachment> returnedData = this.getAttachmentsList(data, listName);

            return returnedData;
        }

        public byte[] downloadFile(string url, string listName)
        {
            var spClient = GetInstanceOfClientHandler(listName);
            return spClient.GetDownloadFile(url);
        }

        public List<EservicesDomain.ExternalDomain.SP.Attachment> GetAttachmentsCSOM(string listName, string jobID)
        {
            List<EservicesDomain.ExternalDomain.SP.Attachment> dataReturned = new List<EservicesDomain.ExternalDomain.SP.Attachment>();
            var spClient = GetInstanceOfClientHandler(listName);
            try
            {
                var data = spClient.GetAttachements(listName, jobID);

                foreach (var oneItem in data)
                {
                    EservicesDomain.ExternalDomain.SP.Attachment newAttachment = new EservicesDomain.ExternalDomain.SP.Attachment(
                     oneItem.File != null ? oneItem.File.Name : string.Empty,
                     //oneItem["ows_FileRef"] !=null ? oneItem["ows_FileRef"].ToString().Substring(oneItem["ows_FileRef"].ToString().LastIndexOf("/") + 1) : null,
                     oneItem["ows_ID"] != null ? oneItem["ows_ID"].ToString() : null,
                     oneItem["ows_upLoaderName"] != null ? oneItem["ows_upLoaderName"].ToString() : null,
                     oneItem["ows_Created_x0020_Date"] != null ? Convert.ToDateTime(oneItem["ows_Created_x0020_Date"]) : DateTime.MinValue,
                     oneItem["ows_activityName"] != null ? oneItem["ows_activityName"].ToString() : null,
                     oneItem.File != null ? _configuaration.SpSiteRoot + _configuaration.AttachmentsSiteName + "/" + listName + "/" + jobID + "/" + oneItem.File.Name : string.Empty,
                     oneItem["fileDescription"] != null ? oneItem["fileDescription"].ToString() : string.Empty

                     );

                    dataReturned.Add(newAttachment);
                }
            }

            catch (AggregateException exception)
            {
                _logger.LogDebug("GetAttachmentsCSOM : File Not Found");
                return null;
            }

            return dataReturned;
            
        }

        public List<EservicesDomain.ExternalDomain.SP.Attachment> getAttachmentsList(List<Dictionary<string, object>> data, string listName)
        {
            List<EservicesDomain.ExternalDomain.SP.Attachment> dataReturned = new List<EservicesDomain.ExternalDomain.SP.Attachment>();
            if (data == null)
                return null;

            foreach (Dictionary<String, Object> oneItem in data)
            {
                EservicesDomain.ExternalDomain.SP.Attachment newAttachment = new EservicesDomain.ExternalDomain.SP.Attachment(
                 oneItem.ContainsKey("ows_FileRef") == true ? oneItem["ows_FileRef"].ToString().Substring(oneItem["ows_FileRef"].ToString().LastIndexOf("/") + 1) : null,
                 oneItem.ContainsKey("ows_ID") == true ? oneItem["ows_ID"].ToString() : null,
                 oneItem.ContainsKey("ows_upLoaderName") == true ? oneItem["ows_upLoaderName"].ToString() : null,
                 oneItem.ContainsKey("ows_Created_x0020_Date") == true ? Convert.ToDateTime(oneItem["ows_Created"]) : DateTime.MinValue,
                 oneItem.ContainsKey("ows_activityName") == true ? oneItem["ows_activityName"].ToString() : null,
                 _configuaration.WebPartLocation + "?" + "webName=kta/" + _configuaration.AttachmentsSiteName + "&listN=" + listName + "&fileID=" + oneItem["ows_ID"].ToString()
                 );

                dataReturned.Add(newAttachment);
            }
            return dataReturned;
        }

        public bool GrantPermission(string cuurentUserId, string listName, string fileID)
        {
            var spClient = GetInstance(listName);
            List<CamlQuery_oneField> dataToUpdate = new List<CamlQuery_oneField>();
            dataToUpdate.Add(new CamlQuery_oneField("ID", "Text", fileID, CamlQuery_oneField.EQ_COMP));
            dataToUpdate.Add(new CamlQuery_oneField("permissions", "Text", ";#-1;#i:0#.w|" + cuurentUserId, CamlQuery_oneField.EQ_COMP));
            spClient.updateRecored(CamlBuilder.buildCamlUpdateQuery(dataToUpdate));
            return true;
        }

        public void PrintFoldersAndFiles(string siteUrl, string listName)
        {
            using (var context = new ClientContext(siteUrl))
            {

                var folder = context.Web.GetFolderByServerRelativeUrl(listName);
                var subFolders = folder.Folders;
                var files = folder.Files;

                context.Load(folder);
                context.Load(subFolders);
                context.Load(files);

                if (context.HasPendingRequest)
                {
                    context.ExecuteQueryAsync()
                       .Wait();
                }

                subFolders.ToList().ForEach(x => Console.WriteLine($"-- {x.Name}"));
                files.ToList().ForEach(x => Console.WriteLine($"-- {x.Name}"));
            }
        }

        public string UpdateTempJobIdSharepoint(string ktaJobID, string listName, string tempJobId)
        {
            SharePointHelpClasses.SharePointFilesHandlerMethods spClient = new SharePointHelpClasses.SharePointFilesHandlerMethods();
            var result = spClient.updateAttachmentsFolderNmae(_configuaration.SpSiteRoot, _configuaration.AttachmentsSiteName, listName, tempJobId, ktaJobID);
            return result;
        }

        public bool UploadAttachments(string filesSourcePath, string listName, string jobID, string activityName, string upLoaderName, string type = "")
        {
            _logger.LogDebug($"UploadAttachments attachement for job Id : {jobID} and activity : {activityName}");
            SharePointHelpClasses.SharePointClientHandler spClient = new SharePointHelpClasses.SharePointClientHandler(_configuaration.SpSiteRoot, _configuaration.AttachmentsSiteName, listName, null);
            spClient.uploadMultipleFiles(filesSourcePath, jobID, upLoaderName, activityName, type);
            _logger.LogDebug($"Finish Upload attachement for job Id : {jobID} and activity : {activityName}");
            return true;
        }
    }
}
