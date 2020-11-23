
using EservicesDomain.ExternalDomain.UAC;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Infrastructure
{
    public interface IUACService
    {
        Task<IList<UniversityModel>> GetAllUniversity();

        Task<IList<FellowModel>> GetFellows(FellowQueryModel querymodel);

        Task<IList<FellowModel>> GetFellowsByUniversity(int universityId);

        Task<IList<ListModel>> GetFellowResearchAreas(string email);

        Task<ConsultationViewModel> PostConsultationData(NewConsultationViewModel model);

        Task<ConsultationViewModel> PatchConsultationData(JsonPatchDocument<EditConsultationDataViewModel> jsonPatch, string jobId);
    }
}
