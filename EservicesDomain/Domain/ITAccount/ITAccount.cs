
using EServicesCommon.DI;
using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using CommonLibrary.Configuaration;
using System.ComponentModel.DataAnnotations;

namespace EservicesDomain.Domain
{
    public partial class ITAccount : IKtaEntity<int>
    {

        private bool _isForTrainee;

        private string _userName;

        private string _password;

        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_RequestInitiation }, false)]
        public string EmployeeEmail { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public bool IsWithEmail { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public bool IsForTrainee
        {
            get { return _isForTrainee; }
            set
            {
                _isForTrainee = value;
                UpdateContractorData();
            }
        }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string ContractorFirstName { get; set; }


        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string ContractorMiddleName { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string ContractorLastName { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string ContractorCompany { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string ContractorProject { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string ContractorEmail { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string ContractorJobTitle { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public DateTime? DateFrom { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public DateTime? DateTo { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string Notes { get; set; }

        [Required]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation, ConstantNodes.NodeId_ITSystemEmployeeToUpdate })]
        public string Justification { get; set; }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_ITSystemsHead, ConstantNodes.NodeId_ITSystemsTeam, ConstantNodes.NodeId_RequestInitiation })]
        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_ITSystemsHead, ConstantNodes.NodeId_ITSystemsTeam, ConstantNodes.NodeId_RequestInitiation })]
        public string UserName
        {
            get { return _userName ?? GetUserName(); }
            set { _userName = value; }
        }

        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_ITSystemsHead, ConstantNodes.NodeId_ITSystemsTeam, ConstantNodes.NodeId_RequestInitiation })]
        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_ITSystemsHead, ConstantNodes.NodeId_ITSystemsTeam, ConstantNodes.NodeId_RequestInitiation })]
        public string Password
        {
            get { return _password ?? GetPassword(); }
            set { _password = value; }
        }


        public string GetUserName()
        {
            var config = FactoryManager.Instance.Resolve<ICoreConfigurations>();
            return String.Format(config.AddNewAccountFormat, ContractorFirstName ?? ContractorFirstName.Substring(0, 1)
                             , !string.IsNullOrEmpty(ContractorLastName) && ContractorLastName.StartsWith("al", StringComparison.InvariantCultureIgnoreCase) ?
                             ContractorLastName.Substring(2).Trim() : ContractorLastName).ToLowerInvariant();
        }


        public void UpdateContractorData()
        {
            var config = FactoryManager.Instance.Resolve<ICoreConfigurations>();
            if (this.IsForTrainee)
            {
                ContractorCompany = config.TraineeCompany;
                ContractorJobTitle = config.TraineeJobTitle;
                ContractorProject = config.TraineeProject;
            }
        }

        public string GetPassword()
        {
            var config = FactoryManager.Instance.Resolve<ICoreConfigurations>();
            return String.Format(config.AddNewAccountPassword, new Random().Next(0, 10000).ToString());

        }

    }
}
