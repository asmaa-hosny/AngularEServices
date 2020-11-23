


using EservicesDomain.Attributes;

namespace EServicesWithAngular.Domain
{
    public class IdentificationLetter : NoneIdBaseEntity
    {
        private const short NodeId_RequestInitiation = 0;

        public long EmployeeID { get; set; }

        public long RequestNo { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation })]

        public int RequestType { get; set; }

        [EditWhenNodeID(new short[] { NodeId_RequestInitiation })]
        public int SignatureType { get; set; }




    }
}
