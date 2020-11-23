using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace EservicesDomain.Domain.AdTranslation
{
  public  class AdminTranslation : IKtaEntity<int>
    {
        [Required]
        public int NoOfWords { get; set; }
        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_TransManager , ConstantNodes.NodeId_TransManager , ConstantNodes.NodeId_Translator})]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation })]
        public int EnToAr { get; set; }
     
        [Required]
        public int RequestType { get; set; }
        public string Notes { get; set; }
        // [Required]
        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_TransManager })]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_TransManager })]
       // [RequiredIf("NodeID", new short[] { ConstantNodes.NodeId_TransManager })]
        public string AssignedTo { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_TransManager, ConstantNodes.NodeId_Translator })]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_TransManager })]
        public string ManagerNotes { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public int PendigRequests { get; set; }
        public string Status { get; set; }

        public string EmployeeDepartment { get; set; }
        public string Title { get; set; }
        public int NumberOfAttachment { get; set; }



    }
}
