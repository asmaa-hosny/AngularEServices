using EServicesApplication.Service.ITSoftware;
using EservicesDomain.Domain.ITSoftware;
using System.Collections.Generic;

namespace EServicesApplication.Interfaces.Services
{
    public interface ISoftwareService : IService<SoftwareDTO>
    {
        List<SoftwareApps> RetreiveSoftwareApps(int SelectedCategoryId);
        List<SoftwareCategory> RetreiveSoftwareCategories();
        List<SoftwareRequestItemsModel> RetriveHistory(string EmpEmail);


    }
}



