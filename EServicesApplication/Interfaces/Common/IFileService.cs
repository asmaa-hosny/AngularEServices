using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EServicesApplication.Interfaces.Common
{
    public interface IFileService
    {
        void UploadRequestFiles<T>(Type dtoClass, T requestObject, string requestType, string jobId, string listName, string activityName, string uploaderName, bool uploadToSharepoint = true, bool multiTypes = false, bool multi = false);

        (byte[] bytes, string contentType, string filename) Download(string url);
        void Upload(string jobId, string requestType, List<IFormFile> files, string listName, string activityName, string uploaderName, bool uploadToSharepoint = true, string type = "");
    }
}
