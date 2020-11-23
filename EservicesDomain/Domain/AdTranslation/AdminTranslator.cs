using EservicesDomain.Attributes;
using EservicesDomain.Common;


namespace EservicesDomain.Domain.AdTranslation
{
   public class AdminTranslator : IEntity<int>
    {
        [StaticDisplayRule(new short[] { ConstantNodes.NodeId_TransManager })]
        [EditWhenNodeID(new short[] { ConstantNodes.NodeId_TransManager })]
        public string TranslatorEmail { get; set; }

    }
}
