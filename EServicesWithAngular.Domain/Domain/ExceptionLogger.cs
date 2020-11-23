using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    public class ExceptionLogger
    {
        public int Id { get; private set; }
        [StringLength(1000)]
        public string Title { get; private set; }
        public string ExceptionDetails { get; private set; }
        [StringLength(100)]
        public string UserGotTheException { get; private set; }
        [StringLength(500)]
        public string StepsToReproduce { get; private set; }
    }
}
