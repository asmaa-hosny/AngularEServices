using EservicesDomain.Attributes;


namespace EservicesDomain.Common
{
    public class IKtaEntity<Tid> : IEntity<Tid>
    {

        public string JobId { get; set; }

        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_RequestInitiation }, false)]
        public string RefId { get;  set; }

        public short NodeID { get; set; }
    }
}
