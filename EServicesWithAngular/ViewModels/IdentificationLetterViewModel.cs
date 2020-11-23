using EServicesWithAngular.Domain;
using EServicesWithAngular.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Models
{
    public class IdentificationLetterDTO : BaseViewModel
    {
        public IdentificationLetterDTO()
        {
            DomainModel = new IdentificationLetter();
        }
        public IdentificationLetter DomainModel { get; set; }
    }
}
