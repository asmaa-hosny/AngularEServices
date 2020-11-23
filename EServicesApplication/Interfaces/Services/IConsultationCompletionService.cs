using EServicesApplication.Service.UCcompletion;
using EservicesDomain.Domain.UCcompletion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Services
{
    public interface IConsultationCompletionService : IService<ConsultationCompletionDTO>
    {
      //  List<ConsultationModel> GetConsultationRequests(string employeeEmail);
        Task AddEvaluation(ConsultationCompletionDTO dto);
        //  List<ConsultantEvaluationModel> GetEvaluationItems();
        (List<ConsultationModel> ConsultationList, List<ConsultantEvaluationModel> ConsultantEvaluationList) GetLists(string employeeEmail);
        Task<ConsultantEvaluation> GetConsultantEvaluation(ConsultationCompletionDTO dto);
        Task UpdateAvailability(ConsultationCompletionDTO dto);
    }
}
