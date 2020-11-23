using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Domain
{
   public  class BaseEntity<T>
    {
        public T Id { get; set; }

        public string JobID { get; set; }

        public string REF_ID { get; set; }


        public short NodeID { get; set; }
    }

}
