using CommonLibrary.Configuaration;
using EServicesCommon.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.Helpers
{
    public class AddNewGroupEmail : IMap
    {
        public string GroupName { get; set; }
        public string GroupEmail { get; set; }
        public string DisplayName { get; set; }
        public string MangedBy { get; set; }
        public string Members { get; set; }

        public string getFileName()
        {
            var config = FactoryManager.Instance.Resolve<ICoreConfigurations>();
            return config.AddNewEmailGroupFileName;

        }
    }
}
