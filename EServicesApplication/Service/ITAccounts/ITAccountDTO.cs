using EservicesDomain.Domain;
using EservicesDomain.Helpers;


namespace EServicesApplication.Services.ITAccounts
{
    public class ITAccountDTO : BaseDTO
    {
        private string _powershellScript;

        public ITAccountDTO()
        {
            DomainModel = new ITAccount();
        }

        public ITAccount DomainModel { get; set; }

        public bool createUser { get; set; }

        public string PowerShellCodeForAddingNewUser { 
            get { return _powershellScript; }
            set { _powershellScript = value; } }

        public string AddNewAccount()
        {

            _powershellScript = SkeletonMapper.MapObjectToSkeleton(
                                                 new AddNewAccount()
                                                 {
                                                     Department = this.Requester.EmployeeDepartment,
                                                     Company = this.DomainModel.ContractorCompany,
                                                     ExpireDate = this.DomainModel.DateTo.ToString(),
                                                     FirstName = this.DomainModel.ContractorFirstName,
                                                     FamilyName = this.DomainModel.ContractorLastName,
                                                     JobTitle = this.DomainModel.ContractorJobTitle,
                                                     ManagerUsername = this.Requester.Email,
                                                     Password = this.DomainModel.Password,
                                                     Project = this.DomainModel.ContractorProject,
                                                     SAMAccount = this.DomainModel.UserName,
                                                     IsTrainee = this.DomainModel.IsForTrainee.ToString()
                                                 }, forJavaScript: false);
            return _powershellScript;
        }



    }
}
