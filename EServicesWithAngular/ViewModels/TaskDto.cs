using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Models
{
    public class TaskDto : BaseViewModel
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

    }
}
