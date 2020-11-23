using EServicesApplication.Services.WorkFlow;
using EservicesDomain.ExternalModel.ERB;

using KTA_ActivityServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;



namespace EServicesWithAngular.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Requester = new Employee();
            
        }
        public short NodeID { get; set; }
        public short EPC { get; set; }
        public string JobID { get; set; }
        public JobActivity activity { get; set; }
        public List<EServicesApplication.Services.WorkFlow.DecisionItemModel> Decisions { get; set; }
        public bool IsReviewMode { get; set; }
        public ManagerDecisionViewModel ManagerDecision { get; set; }

        public Employee Requester { get; set; }

        //[StaticDisplayRule(new short[] { 0 }, showForIDs: false)]
        //public string CreatedBy { get; set; }

        //public List<SelectListItem> OnBehalfOf { get; set; }

        //[StaticDisplayRule(new short[] { 0 }, showForIDs: true)]
        //public string SelectedOnBehalfOf { get; set; }

    }
}
