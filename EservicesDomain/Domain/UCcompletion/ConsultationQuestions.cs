using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EservicesDomain.Domain.UCcompletion
{
    public class ConsultationQuestions
    {
        //public ConsultationQuestions()
        //{
        //    this.ConsultantEvaluationItems = new List<ConsultantEvaluationItems>();
        //}
        public int Id { get; set; }
        public string Question { get; set; }
      //  [JsonIgnore]
     //   public ICollection<ConsultantEvaluationItems> ConsultantEvaluationItems { get; set; }

    }
}
