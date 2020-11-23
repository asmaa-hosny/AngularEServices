using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EservicesDomain.Domain
{

    public class ITStatus : IEntity<string>
    {

        [Required]
        public string StatusTextAr { get; private set; }

        [Required]
        public string StatusTextEn { get; private set; }

      
    }
}
