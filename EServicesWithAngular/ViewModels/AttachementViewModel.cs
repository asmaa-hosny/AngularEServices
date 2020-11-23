using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Models
{
    public class AttachementModel
    {

        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Path { get; set; }

        public string Type { get; set; }

        public DateTime ExpiryDate { get; set; }

       
    }
}
