using CommonLibrary.Configuaration;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesCommon.DI;
using EservicesDomain.ExternalDomain.ITCare;
using EservicesDomain.ExternalDomain.KTA;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesInfrustructure.Network
{
    public class ITCareService : IITCareService
    {
        private IRestWrapper RestService => FactoryManager.Instance.Resolve<IRestWrapper>();
        private ICoreConfigurations Configuaration => FactoryManager.Instance.Resolve<ICoreConfigurations>();
       

        public async Task<ITCareRequestResponse> AddNewRequestAsync(ITCareRequest request,string currentuser)
        {
            request.Requester = new ITCareRequester { email_id = currentuser };
            var result = await RestService.Post<ITCareRequestResponse, ITCareRequestResponse>(Configuaration.ITCareAPIName, $"{Configuaration.ITCareRequest}", new ITCareRequestResponse() { Request = request });
            return result;
        }

        public async Task<dynamic> PostFilesAsync(int requestId, IEnumerable<IFormFile> files)
        {
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddHeader("Content-Type", "multipart/form-data;");
            request.AddHeader(Configuaration.ITCareTechnicianKey, Configuaration.ITCareTechnicianValue);
            foreach (var file in files)
            {
                byte[] Bytes = new byte[file.Length];
                file.OpenReadStream().Read(Bytes, 0, Bytes.Length);
                request.AddFile("file", Bytes, file.FileName);
            }
            var data = new { attachment = new { Request = new { Id = requestId } } };
            var itemSerilized = RestService.SerilizeObject(data,true);
            var client = new RestClient($"{Configuaration.ITCareAPI}{Configuaration.ITCareAttachement}{itemSerilized}");
            var response= await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return result;
        }

        public async Task<ITCareCategoryReponse> GetCategoriesAsync(bool IsJson = true)
        {
            var url = Configuaration.ITCareCategory;
            if (IsJson) url = url + Configuaration.JsonFormat;
            var response = await RestService.Get<ITCareCategoryReponse>(Configuaration.ITCareAdminAPIName, url);
            return response;
        }

        public async Task<ITCareCategoryReponse> GetSubCategoriesAsync(int categoryId, bool IsJson = true)
        {
            var url = string.Format(Configuaration.ITCareSubcategory, categoryId); 
            if (IsJson) url = url + Configuaration.JsonFormat;
            var response = await RestService.Get<ITCareCategoryReponse>(Configuaration.ITCareAdminAPIName, url);
            return response;
        }

        public async Task<ITCareCategoryReponse> GetSubItemsAsync(int subCategoryId, bool IsJson = true)
        {
            var url = string.Format(Configuaration.ITCareSubcategoryItem,subCategoryId);
            if (IsJson) url = url + Configuaration.JsonFormat; ;
            var response = await RestService.Get<ITCareCategoryReponse>(Configuaration.ITCareAdminAPIName, url);
            return response;
        }
        public async Task<RequestsResponse> GetRequestByUserNameAsync(string emp, string sortField = "created_time", string sortOrder = "desc", string empName = null)
        {
            var query = new List_Info()
            {
                Sort_field = sortField,
                Sort_order = sortOrder,
                Search_fields = new Searchfields { name = emp },

            };
            sortField = Configuaration.ITCareSortField;
            sortField = Configuaration.ITCareSortOrder;
            var result = await RestService.Get<dynamic, RequestsResponse>(Configuaration.ITCareAPIName, $"{Configuaration.ITCareRequest}", new { list_info = query });
            return result;
        }

        public async Task<ITCareRequestResponse> GetRequest(int requestId)
        {
            var response = await RestService.Get<ITCareRequestResponse>(Configuaration.ITCareAPIName, $"{Configuaration.ITCareGetRequest} + /{requestId}");

            return response;
        }


        public List<PassedItems> LoadITCareRequests(string emp)
        {
            var itcareRequests = new List<PassedItems>();
            var requestTask = Task.Run(async () => await GetRequestByUserNameAsync(emp));
            var requestresult = requestTask.Result;
            if (requestresult.requests != null && requestresult.requests.Count > 0)
                foreach (var item in requestresult.requests)
                {
                    var passedItems = new PassedItems();
                    passedItems.ProcessName = Configuaration.ITCareService;
                    passedItems.REF_ID = Configuaration.ITCareRefIdPrefix + item?.id;
                    passedItems.CurrentLocation = Convert.ToString(item.site?[Configuaration.ITCareFieldName]);
                    passedItems.Created = Convert.ToDateTime(item.created_time?[Configuaration.ITCareCreate]);
                    passedItems.Requestor = Convert.ToString(item.requester?[Configuaration.ITCareFieldName]);
                    passedItems.Status = Convert.ToString(item.status?[Configuaration.ITCareFieldName]);
                    passedItems.AssociatedFile = Configuaration.ITCareService;
                    passedItems.Short_description = item.short_description;
                    itcareRequests.Add(passedItems);
                }
            return itcareRequests;

        }



    }
}
