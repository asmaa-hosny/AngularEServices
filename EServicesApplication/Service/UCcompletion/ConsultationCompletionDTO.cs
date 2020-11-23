using EServicesApplication.Services;
using EservicesDomain.Domain.UCcompletion;
using System.Collections.Generic;


namespace EServicesApplication.Service.UCcompletion
{
   public class ConsultationCompletionDTO : BaseDTO
    {
        public ConsultationCompletionRequest DomainModel { get; set; }
        public ConsultationModel ConsultationModel { get; set; }
        public ConsultantEvaluation ConsultantEvaluation { get; set; }
        public List<ConsultantEvaluationModel> ConsultantEvaluationItems { get; set; }
        public List<ConsultantEvaluationItems> ConsultantEvaluationList { get; set; }
        public string ConsultationJobId { get; set; }
        public string ConsultantEmail { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public bool IsTerminated { get; set; }
    }
    
}
