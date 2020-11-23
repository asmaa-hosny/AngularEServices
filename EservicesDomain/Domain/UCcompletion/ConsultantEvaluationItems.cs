

using System.Text.Json.Serialization;

namespace EservicesDomain.Domain.UCcompletion
{
   public class ConsultantEvaluationItems
    {
        public int Id { get; set; }
        
        public int ConsultantEvaluationId { get; set; }
        public string Question { get; set; }
        public int QuestionId { get; set; }
        public int Answer { get; set; }
        public string AnswerText { get; set; }
        
       // public virtual ConsultantEvaluation ConsultantEvaluation { get; set; }
        
      //  public virtual ConsultationQuestions ConsultationQuestions { get; set; }


    }
}
