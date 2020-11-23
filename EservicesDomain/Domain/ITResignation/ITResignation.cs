using EservicesDomain.Attributes;
using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EservicesDomain.Domain
{
    public class ITResignation : IKtaEntity<int>
    {
        public ITResignation()
        {
            this.ITResignationItemStatus = new List<ITResignationItemStatus>();
        }
        [Required]
        public string EmployeeEmail { get; set; }

        public string EmployeeName { get; set; }

        [Execlude]
        public virtual ICollection<ITResignationItemStatus> ITResignationItemStatus { get; set; }


    }
}
