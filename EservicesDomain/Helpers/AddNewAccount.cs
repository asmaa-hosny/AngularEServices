using CommonLibrary.Configuaration;
using EServicesCommon.DI;


namespace EservicesDomain.Helpers
{
    public class AddNewAccount : IMap
    {
      
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string SAMAccount { get; set; }
        public string JobTitle { get; set; }
        public string Password { get; set; }
        public string ExpireDate { get; set; }
        public string ManagerUsername { get; set; }
        public string Company { get; set; }
        public string Project { get; set; }
        public string IsTrainee { get; set; }

        public string getFileName()
        {
            var config = FactoryManager.Instance.Resolve<ICoreConfigurations>();
            return config.AddNewAccountFileName;

        }

    }
}
