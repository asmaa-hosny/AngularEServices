

namespace EServicesApplication.Services.Resignation
{
    public class ITResignationStatusModel
    {
     
        public int RequestId { get; set; }

        public int ItemId { get; set; }

        public string Status { get; set; }

        public string UpdatedBy { get; set; }

        public string Notes { get; set; }

        public string ItemNameAr { get; set; }

        public string ItemNameEn { get; set; }
    }
}
