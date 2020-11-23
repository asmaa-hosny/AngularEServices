using EservicesDomain.Domain.Workflow;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EServicesApplication.Interfaces.Services;

namespace EServicesApplication.Services.WorkFlow
{
    public class DecisionService : BaseService<DecisionChoices, int> , IDecisionService
    {

      
        private string RetriveDecisionGroupFromActivityHelpText(string helpText)
        {
            if (helpText == null)
                return "";
            JToken data = JObject.Parse(helpText)["DecisionGroup"];
            return data != null ? data.ToString() : "";
        }

        public List<DecisionItemModel> GetDecisionList(string helpText)
        {
            string decisionGroup = RetriveDecisionGroupFromActivityHelpText(helpText);
            List<DecisionItemModel> returned = new List<DecisionItemModel>();

            var list = this.Find(x => x.LookupGroup == decisionGroup);
            var mappedList = this.Mapper.Map<List<DecisionItemModel>>(list);

            return mappedList;
        }


    }
}
