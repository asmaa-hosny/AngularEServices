
using System.ComponentModel.DataAnnotations;

namespace EservicesDomain.ExternalDomain.ITCare
{
    public partial class ITCareRequest : ExModel
    {
        private ITCareBase _status;

        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        public ITCareRequester Requester { get; set; }

        public ITCareBase Status
        {
            get
            {
                _status = new ITCareBase() { Id = 1 };
                return _status;
            }
            set { this._status = value; }
        }

        public ITCareBase Template { get { return new ITCareBase() { Id = 4, Name = "Default Request" }; } }

       
        public ITCareBase Category { get; set; }

        public ITCareBase Subcategory { get; set; }

        [Required]
        public ITCareBase Item { get; set; }

        [Required]
        public Udf_fields Udf_fields { get; set; }
     
    }

    public class ITCareRequester
    {
        public string email_id { get; set; }
    }
}
