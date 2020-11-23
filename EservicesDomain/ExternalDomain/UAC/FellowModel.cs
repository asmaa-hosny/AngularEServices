
using System.Collections.Generic;

namespace EservicesDomain.ExternalDomain.UAC
{
    public class FellowModel
    {
        public string IdentityKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string AwardsHonors { get; set; }
        public string PublishedWork { get; set; }
        public string Publication { get; set; }
        public string ResearchAbstract { get; set; }
        public bool IsActive { get; set; }
        public bool ProvideTatents { get; set; }

        //Fellow Research Area,later we can name it
        public IList<ListModel> UserTags { get; set; }
    }
}
