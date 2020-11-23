using System;
using System.Collections.Generic;
using EservicesDomain.ExternalDomain.SP;

namespace EServicesApplication.Interfaces.Infrastructure
{
    public interface ISPFacade
    {

        List<Attachment> GetAttachments(String listName, String jobID);

        List<Attachment> GetAttachmentsCSOM(String listName, String jobID);

        void PrintFoldersAndFiles(string siteUrl, string listName);

        bool UploadAttachments(String filesSourcePath, String listName, String jobID, String activityName, String upLoaderName, string type = "");

        bool GrantPermission(String cuurentUserId, String listName, String fileID);

        string UpdateTempJobIdSharepoint(String ktaJobID, String listName, String tempJobId);

        List<Attachment> getAttachmentsList(List<Dictionary<String, Object>> data, String listName);

        byte[] downloadFile(string url, string listName);
    }
}
