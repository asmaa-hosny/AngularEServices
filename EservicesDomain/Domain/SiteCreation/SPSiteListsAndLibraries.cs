using EservicesDomain.Attributes;
using EservicesDomain.Common;


namespace EservicesDomain.Domain.SiteCreation
{
    public  class SPSiteListsAndLibraries :IEntity<int>
    {

        public int RequestID { get; set; }

      //  [EditWhenNodeID(new short[] { ConstantNodes.NodeId_RequestInitiation })]
        public string Name { get; set; }
        public string Type { get; set; }
        public int TypeID { get; set; }



    }

}
