using EServicesApplication.Services.WorkFlow;
using System.Collections.Generic;


namespace EServicesApplication.Interfaces.Services
{
    public interface IDecisionService
    {
        List<DecisionItemModel> GetDecisionList(string helpText);


    }
}
