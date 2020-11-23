
using EServicesApplication.Services.AdminTranslation;
using EservicesDomain.Domain.AdTranslation;
using System.Collections.Generic;



namespace EServicesApplication.Interfaces.Services
{
    public interface IAdminTranslationService : IService<AdminTranslationDTO>
    {
        List<TranslatorsModel> GetTranslators();

        (int pendingtasks, TranslationInstructions instruction) GetPendingInstructionTasks();
       // List<TranslationInstructions> GetInstructions();
    }

}
