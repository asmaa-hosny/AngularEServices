using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Models
{
    public class ListViewModel :BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class LisItemtViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
