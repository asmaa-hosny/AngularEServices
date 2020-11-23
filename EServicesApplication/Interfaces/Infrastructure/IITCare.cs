using EservicesDomain.ExternalDomain.ITCare;
using EservicesDomain.ExternalDomain.KTA;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Infrastructure
{
    public interface IITCareService
    {
        Task<ITCareRequestResponse> AddNewRequestAsync(ITCareRequest request, string currentuser);

        Task<dynamic> PostFilesAsync(int requestId, IEnumerable<IFormFile> files);

        Task<ITCareCategoryReponse> GetCategoriesAsync(bool IsJson = true);

        Task<ITCareCategoryReponse> GetSubCategoriesAsync(int categoryId, bool IsJson = true);

        Task<ITCareCategoryReponse> GetSubItemsAsync(int subCategoryId, bool IsJson = true);

        Task<RequestsResponse> GetRequestByUserNameAsync(string emp, string sortField = "created_time", string sortOrder = "desc", string empName = null);

        List<PassedItems> LoadITCareRequests(string emp);

        Task<ITCareRequestResponse> GetRequest(int requestId);

    }
}
