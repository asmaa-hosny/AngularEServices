using EservicesDomain.Common;


namespace EservicesDomain.Domain
{
    public class ITResignationItemStatus : IEntity<int>
    {

        public int? ItemId { get; set; }

        public int? RequestId { get; set; }

        public string Status { get; set; }

        public string UpdatedBy { get; set; }

        public string Notes { get; set; }

        public virtual ITResignation IT_Resignation { get; set; }

        public virtual ITResignationItem ITResignationItem { get; set; }

        public virtual ITStatus ITStatus { get; set; }


    }
}
