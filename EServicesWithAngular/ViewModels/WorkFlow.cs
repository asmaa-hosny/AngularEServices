using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Models
{
    public class WorkFlow 
    {
        public string JobId { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Action { get; set; }

        public string Comments { get; set; }
    }
}

