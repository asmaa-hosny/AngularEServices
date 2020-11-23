using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using EServicesApplication.Helpers;
using System.Reflection;
using EServicesCommon.DI;
using EServicesCommon.Common;
using System.IO;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Interfaces.Common;
using CommonLibrary.Logging;
using Microsoft.AspNetCore.StaticFiles;
using EServicesCommon.Configuaration;
using CommonLibrary.Configuaration;

namespace EServicesApplication.Service.Common
{
    public class FileService : IFileService
    {
        private ISPFacade _spfacade;
        private ILoggerManager _logger;
        private ICoreConfigurations _config;

        public FileService(ISPFacade spfacade, ILoggerManager logger, ICoreConfigurations config)
        {
            _spfacade = spfacade;
            _logger = logger;
            _config = config;

        }

        public void UploadRequestFiles<T>(Type dtoClass, T requestObject, string requestType, string jobId, string listName, string activityName, string uploaderName, bool uploadToSharepoint = true, bool multiTypes = false, bool multi = false)
        {
            foreach (var property in dtoClass.GetProperties())
            {
                Type t = property.PropertyType;
                if (t.IsFile())
                {
                    PropertyInfo prop = requestObject.GetType().GetProperty(property.Name);
                    var value = prop.GetValue(requestObject);
                    if (value != null && (List<IFormFile>)value != null && ((List<IFormFile>)value).Count > 0)
                    {
                        if (multiTypes)
                            Upload(jobId, requestType, (List<IFormFile>)value, listName, activityName, uploaderName, uploadToSharepoint, property.Name);
                        else
                            Upload(jobId, requestType, (List<IFormFile>)value, listName, activityName, uploaderName, uploadToSharepoint, string.Empty);
                    }

                }
            }
        }

        public void Upload(string jobId, string requestType, List<IFormFile> files, string listName, string activityName, string uploaderName, bool uploadToSharepoint = true, string type = "")
        {
            var hostingEnvironemnt = FactoryManager.Instance.Resolve<Microsoft.AspNetCore.Hosting.IWebHostEnvironment>();
            var path = Path.Combine(hostingEnvironemnt.WebRootPath, requestType, jobId, type);
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    if (file.Length > 0)
                    {
                        string fileName = file.FileName.Substring(0, file.FileName.LastIndexOf(".")).ValidateName();
                        fileName = fileName + DateTime.Now.ToLongTimeString().ValidateName() + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                }
            }
            if (uploadToSharepoint)
            {
                var folder = new DirectoryInfo(path);
                _logger.LogDebug($" Calling sharepoint service for uploading job Id : {jobId} and activity : {activityName}");
                if (folder.Exists)
                {
                    _spfacade.UploadAttachments(path, listName, jobId, activityName, uploaderName, type);
                    Directory.Delete(path, true);
                }
            }


        }

        public (byte[] bytes, string contentType, string filename) Download(string url)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            var filename = Path.GetFileName(url);
            if (!provider.TryGetContentType(filename, out contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = _spfacade.downloadFile(url, _config.AttachmentsSiteName);
            return (bytes: bytes, contentType: contentType, filename: filename);
        }


    }
}
