using System;
using System.Collections.Generic;
using System.Linq;
using EServicesWithAngular.Domain.Common;
using Microsoft.SharePoint.Client;
using SharePointHelpClasses;
using SharePointHelpClasses.CAML;

namespace EServicesWithAngular.DAL
{
   public class SPFacade
  {

        public static string spSiteRoot => StaticClass.Configuration["SharepointSetting:spSiteRoot"];
        public static string siteName => StaticClass.Configuration["SharepointSetting:AttachmentsSiteName"];
        public static string webPartLocation => StaticClass.Configuration["SharepointSetting:webPartLocation"];




        public static List<EservicesDomain.ExternalDomain.SP.Attachment> getAttachments(String listName, String jobID)
        {
            SharePointHandler spClient = GetInstance(listName);
            string viewFieldsCluase = CamlBuilder.buildCamlViewFields(new string[] { "ID", "Name", "upLoaderName", "activityName", "Created" });
            string queryOptions = CamlBuilder.buildCamlQueryOptions(folder: listName + "/" + jobID, recursive: true);

            List<Dictionary<String, Object>> data = spClient.viewRecord(viewFieldsCluase, null, queryOptions);
            List<EservicesDomain.ExternalDomain.SP.Attachment> returnedData = SPFacade.getAttachmentsList(data, listName);

            return returnedData;
        }

        public static List<EservicesDomain.ExternalDomain.SP.Attachment> getAttachmentsCSOM(String listName, String jobID)
        {
            List<EservicesDomain.ExternalDomain.SP.Attachment> dataReturned = new List<EservicesDomain.ExternalDomain.SP.Attachment>();
            var spClient = GetInstanceOfClientHandler(listName);

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
                oneItem.File != null ? spSiteRoot + siteName + "/" + listName + "/" + jobID + "/" + oneItem.File.Name : string.Empty,
                oneItem["fileDescription"] != null ? oneItem["fileDescription"].ToString() : string.Empty


                );

                dataReturned.Add(newAttachment);
            }
            return dataReturned;
        }

        public static void PrintFoldersAndFiles(string siteUrl, string listName)
        {
            using (var context = new ClientContext(siteUrl))
            {
                //context.AuthenticationMode = ClientAuthenticationMode.Anonymous;

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

        public static bool uploadAttachments(String filesSourcePath, String listName, String jobID, String activityName, String upLoaderName, string type = "")
        {

            SharePointHelpClasses.SharePointClientHandler spClient = new SharePointHelpClasses.SharePointClientHandler(spSiteRoot, siteName, listName, null);
            spClient.uploadMultipleFiles(filesSourcePath, jobID, upLoaderName, activityName, type);
            return true;

        }

        public static bool grantPermission(String cuurentUserId, String listName, String fileID)
        {
            var spClient = GetInstance(listName);
            List<CamlQuery_oneField> dataToUpdate = new List<CamlQuery_oneField>();
            dataToUpdate.Add(new CamlQuery_oneField("ID", "Text", fileID, CamlQuery_oneField.EQ_COMP));
            dataToUpdate.Add(new CamlQuery_oneField("permissions", "Text", ";#-1;#i:0#.w|" + cuurentUserId, CamlQuery_oneField.EQ_COMP));
            spClient.updateRecored(CamlBuilder.buildCamlUpdateQuery(dataToUpdate));
            return true;
        }

        public static string UpdateTempJobIdSharepoint(String ktaJobID, String listName, String tempJobId)
        {
            SharePointHelpClasses.SharePointFilesHandlerMethods spClient = new SharePointHelpClasses.SharePointFilesHandlerMethods();
            var result = spClient.updateAttachmentsFolderNmae(spSiteRoot, siteName, listName, tempJobId, ktaJobID);
            return result;

        }


        public static List<EservicesDomain.ExternalDomain.SP.Attachment> getAttachmentsList(List<Dictionary<String, Object>> data, String listName)
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
                webPartLocation + "?" + "webName=kta/" + siteName + "&listN=" + listName + "&fileID=" + oneItem["ows_ID"].ToString()
                );

                dataReturned.Add(newAttachment);
            }
            return dataReturned;
        }
        private static SharePointHandler GetInstance(string listName)
        {
            return new SharePointHelpClasses.SharePointHandler(spSiteRoot, siteName, listName, null);
        }

        private static SharePointClientHandler GetInstanceOfClientHandler(string listName)
        {
            return new SharePointHelpClasses.SharePointClientHandler(spSiteRoot, siteName, listName, null);
        }

    }
}
