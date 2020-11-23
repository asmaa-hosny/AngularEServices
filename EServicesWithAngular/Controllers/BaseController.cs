using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using AutoMapper;
using EServicesCommon.Paging;
using EServicesCommon.DI;
using EServicesCommon.Common;
using EServicesWithAngular.Extensions;
using EServicesWithAngular.Helpers;
using EServicesWithAngular.Models;
using KTA_ActivityServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Services;
using EservicesDomain.Domain;
using System.Threading.Tasks;
using CommonLibrary.Logging;
using CommonLibrary.Configuaration;
using EServicesApplication.Services.WorkFlow.Services;
using EServicesApplication.Interfaces.Services;
using EservicesDomain.Attributes;
using EServicesApplication.Interfaces.Common;


namespace EServicesWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        #region Properties
        protected IUrlHelper UrlHelper
        {
            get
            {
                return FactoryManager.Instance.Resolve<IUrlHelper>();
            }
        }

        protected string BaseUrl
        {
            get
            {
                return HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value;
            }
        }

        protected IHttpClientFactory HttpClientFactory
        {
            get
            {

                return (IHttpClientFactory)HttpContext?.RequestServices.GetService(typeof(IHttpClientFactory));
            }
        }

        protected ILoggerManager Logger
        {
            get
            {
                return FactoryManager.Instance.Resolve<ILoggerManager>();
            }
        }

        protected IBaseService<ITStatus, string> StatusService
        {
            get
            {
                return FactoryManager.Instance.Resolve<IBaseService<ITStatus, string>>();
            }
        }

        protected IDecisionService DecisionService
        {
            get
            {
                return FactoryManager.Instance.Resolve<IDecisionService>();
            }
        }

        protected IWebHostEnvironment HostingEnvironment
        {
            get
            {
                return FactoryManager.Instance.Resolve<IWebHostEnvironment>();
            }
        }

        protected IKTAService KtaService
        {
            get
            {
                return FactoryManager.Instance.Resolve<IKTAService>();
            }
        }


        protected IEmployeeService EmployeeService
        {
            get
            {
                return FactoryManager.Instance.Resolve<IEmployeeService>();
            }
        }

        protected IADServiceD ADService
        {
            get
            {
                return FactoryManager.Instance.Resolve<IADServiceD>();
            }
        }


        protected ICoreConfigurations AppConfiguaraton
        {
            get
            {
                return FactoryManager.Instance.Resolve<ICoreConfigurations>(); ;

            }
        }

        protected IConfiguration Configuaraton
        {
            get
            {
                return (IConfiguration)HttpContext?.RequestServices.GetService(typeof(IConfiguration));

            }
        }

        protected IMapper Mapper
        {
            get
            {
                return (IMapper)HttpContext?.RequestServices.GetService(typeof(IMapper)); ;
            }
        }

        protected IHttpContextAccessor _httpContextAccessor
        {
            get
            {
                return FactoryManager.Instance.Resolve<IHttpContextAccessor>(); ;
            }
        }

        protected ICoreApprovalService ApprovalService
        {
            get
            {

                return FactoryManager.Instance.Resolve<ICoreApprovalService>();
            }
        }

        protected IFileService FileService
        {
            get
            {

                return FactoryManager.Instance.Resolve<IFileService>();
            }
        }
        protected ISPFacade FacadeService
        {
            get
            {

                return FactoryManager.Instance.Resolve<ISPFacade>();
            }
        }


        protected bool IsReviewMode { get; set; }

        protected string CurrentUser
        {
            get
            {
                return "energy\\m.bukhari";
                //return _httpContextAccessor.HttpContext.User.Identity.Name ;
            }
        }

        protected string CurrentUserEmail
        {
            get
            {
                Logger.LogDebug($"User Email : {CurrentUser}");
                return CurrentUser.ToLower().Replace(AppConfiguaraton.DomainName, "") + AppConfiguaraton.DomainEmail;
            }
        }

        protected virtual string AttachementListName { get; set; }

        protected virtual string KTAProcessId { get; set; }

        protected virtual List<JsonFieldsDTO> fields { get; set; }

        #endregion

        [NonAction]
        public async Task<string> getUserSession(bool enforceRefresh = false)
        {
            if (enforceRefresh)
                return await renewUserSession();

            string session = CookiesHandler.GetKTASession(HttpContext);
            if (session != null)
            {
                return await KtaService.ValidateSessionAsync(session) ?
                    session : await renewUserSession();
            }
            else
            {
                return await renewUserSession();
            }
        }

        [NonAction]
        public async Task<string> renewUserSession()
        {
            await KtaService.AsureResourceExistenceAsync(CurrentUser);
            string session = await KtaService.LogonUsingWindowsAsync(CurrentUser);
            CookiesHandler.UpdateKTASession(HttpContext, session);
            return session;
        }



        protected void Upload(string jobId, string requestType, List<IFormFile> files, string listName, string activityName, string uploaderName, bool uploadToSharepoint = true, string type = "")
        {
            var path = Path.Combine(this.HostingEnvironment.WebRootPath, requestType, jobId, type);
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {

                    var filesx = HttpContext.Request.Form.Files;


                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    if (file.Length > 0)
                    {
                        string fileName = file.FileName.Substring(0, file.FileName.LastIndexOf("."));
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
                if (folder.Exists)
                {
                    FacadeService.UploadAttachments(path, listName, jobId, activityName, uploaderName, type);
                    Directory.Delete(path, true);
                }
            }
        }


        protected void UploadRequestFiles<T>(Type dtoClass, T requestObject, string requestType, string jobId, string listName, string activityName, string uploaderName, bool uploadToSharepoint = true, bool multiTypes = false, bool multi = false)
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

        protected List<AttachementModel> GetAttachaments(string jobId, string requestType)
        {
            var path = Path.Combine(this.HostingEnvironment.WebRootPath, requestType, jobId);
            DirectoryInfo[] directories = new DirectoryInfo(path).GetDirectories();
            int i = 1;
            List<AttachementModel> fileList = new List<AttachementModel>();
            foreach (var d in directories)
            {
                fileList.AddRange(
               (from file in d.GetFiles()
                select new AttachementModel
                {
                    Id = i++,
                    Name = file.Name,
                    Path = BaseUrl + "/" + requestType + "/" + jobId + "/" + d.Name + "/" + file.Name,
                    Type = d.Name

                }).ToList());

            }

            return fileList;
        }

        [HttpGet("getWorkflowHistory/{jobId}")]
        public IActionResult GetWorkflowHistory(string jobId)
        {
            // if(!string.IsNullOrEmpty(jobId))  
            return Ok(ApprovalService.GetApprovalHistory(jobId));
            // return Ok();

        }

        [HttpPost]
        [Route("Cancel/{jobId}")]
        public async Task<IActionResult> Cancel([FromBody] JobActivity activity, string jobID, short NodeID, short EPC)
        {
            if (activity == null)
                activity = await KtaService.TakeActivityAsync(await getUserSession(), jobID, NodeID, EPC);

            await KtaService.CancelActivityAsync(await getUserSession(), activity.Identity);

            return Ok();
        }


        public void CreatePagingMetadata<T>(PagedList<T> list, string actionName, QueryParameters parameters)
        {
            Logger.LogDebug($"Create paging Metadata");
            var previousLink = list.HasPreviousPage ? CreateResourceURI(actionName, parameters, EnumResourceUriType.PreviousPage) : null;
            var nextLink = list.HasNextPage ? CreateResourceURI(actionName, parameters, EnumResourceUriType.NextPage) : null;
            var pagingMetadata = new
            {
                previousPage = previousLink,
                nextPage = nextLink,
                totalpages = list.TotalPages,
                pageNumber = list.CurrentPage,
                pageSize = list.PageSize,
                count = list.TotalCount,

            };
            Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(pagingMetadata));
        }

        [NonAction]
        public string CreateResourceURI(string actionName, QueryParameters parameters, EnumResourceUriType type)
        {
            switch (type)
            {
                case EnumResourceUriType.NextPage:

                    return UrlHelper.Link(actionName, new
                    {
                        pageNumber = parameters.PageNumber + 1,
                        pageSize = parameters.PageSize
                    });

                case EnumResourceUriType.PreviousPage:
                    return UrlHelper.Link(actionName, new
                    {
                        pageNumber = parameters.PageNumber - 1,
                        pageSize = parameters.PageSize
                    });

                default:
                    return UrlHelper.Link(actionName, new
                    {
                        pageNumber = parameters.PageNumber - 1,
                        pageSize = parameters.PageSize
                    });

            }
        }

        [HttpGet("DownloadAttachment")]
        public IActionResult DownloadAttachment(string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest("NO sharepoint file url send");

            var tulip = FileService.Download(url);

            return File(tulip.bytes, tulip.contentType, tulip.filename);
        }

        protected List<JsonFieldsDTO> getObjectPropertiesWithMetadata(Type dtoClass, short nodeId, bool recursive = true, bool isfirstLevel = true, string parentName = null)
        {

            var fields = new List<JsonFieldsDTO>();
            foreach (var property in dtoClass.GetProperties())
            {
                Type t = property.PropertyType;

                var execludeattribute = (ExecludeAttribute)Attribute.GetCustomAttribute(property, typeof(ExecludeAttribute));
                if (execludeattribute != null && execludeattribute.IsExecluded())
                    continue;

                if (t.IsCustomComplex())
                {
                    var complexTypefields = getObjectPropertiesWithMetadata(t.GetCustomElementType(), nodeId, recursive, false, property.Name);
                    fields = fields.Concat(complexTypefields).ToList();
                }

                var requiredattribute = (RequiredAttribute)Attribute
                            .GetCustomAttribute(property, typeof(RequiredAttribute));
                var requiredIfattribute = (RequiredIfAttribute)Attribute
                          .GetCustomAttribute(property, typeof(EservicesDomain.Attributes.RequiredIfAttribute));
                var regularExpressionsAttribute = (RegularExpressionAttribute)Attribute
                           .GetCustomAttribute(property, typeof(RegularExpressionAttribute));
                var requiredAttachementAttribute = (RequiredAttachmentAttribute)Attribute
                          .GetCustomAttribute(property, typeof(RequiredAttachmentAttribute));
                var checkNodeID = dtoClass.GetTypeInfo().GetProperty(property.Name).GetCustomAttribute<EditWhenNodeIDAttribute>();
                var checkvisibleNodeID = dtoClass.GetTypeInfo().GetProperty(property.Name).GetCustomAttribute<StaticDisplayRuleAttribute>();
                var required = false;

                var isFile = t.IsFile();
                if (isFile)
                {
                    required = (requiredAttachementAttribute != null && requiredAttachementAttribute.requiredForNodeIDs != null && requiredAttachementAttribute.requiredForNodeIDs.Contains(nodeId));
                }
                else
                {
                    required = requiredIfattribute != null && requiredIfattribute.PropertyName == "NodeID" && (short[])requiredIfattribute.DesiredValue != null && ((short[])requiredIfattribute.DesiredValue).Contains(nodeId);

                }
                var condition = string.Empty;
                if (requiredIfattribute != null && !string.IsNullOrEmpty(requiredIfattribute.Condition)) condition = requiredIfattribute.Condition;
                fields.Add(new JsonFieldsDTO()
                {
                    //FieldName = char.ToLower(property.Name[0]) + property.Name.Substring(1),

                    FieldName = !isfirstLevel && parentName != "DomainModel" ? char.ToLower(parentName[0]) + parentName.Substring(1) + "." + char.ToLower(property.Name[0]) + property.Name.Substring(1) : char.ToLower(property.Name[0]) + property.Name.Substring(1),
                    Editable = IsReviewMode ? false : checkNodeID != null ? checkNodeID.IsEditable(nodeId) : nodeId == 0 ? true : false,
                    Required = requiredIfattribute != null || requiredAttachementAttribute != null ? required : ((requiredattribute != null) ? requiredattribute.AllowEmptyStrings == false : false),
                    Visible = checkvisibleNodeID != null ? checkvisibleNodeID.IsVisible(nodeId) : true,
                    IsAttachement = isFile,
                    Condition = condition,
                    Pattern = regularExpressionsAttribute != null ? regularExpressionsAttribute.Pattern : string.Empty

                });

            }

            return fields;
        }


    }
}