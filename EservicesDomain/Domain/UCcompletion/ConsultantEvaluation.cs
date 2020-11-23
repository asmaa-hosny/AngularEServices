

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EservicesDomain.Domain.UCcompletion
{
    public class ConsultantEvaluation
    {
        public ConsultantEvaluation ()
        {
            this.EvaluationItems = new List<ConsultantEvaluationItems>();
        }
    public int Id { get; set; }
        public int ConsultationCompletionId { get; set; }
        public int ConsultationId { get; set; }
        public string ConsultantEmail { get; set; }
        public string EmployeeEmail { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    
        public ICollection<ConsultantEvaluationItems> EvaluationItems { get; set; }
      
    }
}
