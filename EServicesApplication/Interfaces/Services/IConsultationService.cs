using EServicesApplication.Service.UCconsultation;
using EservicesDomain.Domain.UC;
using EservicesDomain.ExternalDomain.UAC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Services
{
    public interface IConsultationService : IService<ConsultationDTO>
    {
        Task<IList<UniversityModel>> GetUniversities();
        Task<IList<FellowModel>> GetFellows(int universityId);
        Task<(IList<ListModel> Areas, int Rating)> GetAreas(string fellowEmail);
        Task<List<ConsultationRequestsHistory>> GetConsultationRequestsHistory(string employeeEmail);
        //  Task<ConsultantAvailabilityModel> CheckAvailability(string consultantEmail, DateTime? startDate, DateTime? endDate);
        Task AddAvailability(ConsultationDTO dto);
        Task<ConsultantAvailabilityModel> GetConsultantAvailability(string consultantEmail, DateTime? startDate, DateTime? endDate, int Duaration);
        int GetRating(string ConsultantEmail);


    }

}