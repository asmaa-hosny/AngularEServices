using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EServicesWithAngular.Domain
{
    [Table("HR_Training_Survey")]
    public class HrTrainingSurvey
    {
        [Column("id")]
        public int Id { get; private set; }
        [StringLength(50)]
        public string Username { get; private set; }
        [Column("name")]
        [StringLength(100)]
        public string Name { get; private set; }
        [StringLength(50)]
        public string Q1 { get; private set; }
        [StringLength(50)]
        public string Q2 { get; private set; }
        [StringLength(50)]
        public string Q3 { get; private set; }
        [StringLength(50)]
        public string Q4 { get; private set; }
        [StringLength(50)]
        public string Q5 { get; private set; }
        [StringLength(50)]
        public string Q6 { get; private set; }
        [StringLength(50)]
        public string Q7 { get; private set; }
        [StringLength(50)]
        public string Q8 { get; private set; }
        [StringLength(50)]
        public string Q9 { get; private set; }
        [StringLength(50)]
        public string Q10 { get; private set; }
        [StringLength(50)]
        public string Q11 { get; private set; }
        [StringLength(50)]
        public string Q12 { get; private set; }
        [StringLength(50)]
        public string Q13 { get; private set; }
        [StringLength(50)]
        public string Q14 { get; private set; }
        [StringLength(50)]
        public string Q15 { get; private set; }
        [StringLength(50)]
        public string Q16 { get; private set; }
        [StringLength(50)]
        public string Q17 { get; private set; }
        [StringLength(50)]
        public string Q18 { get; private set; }
        [StringLength(50)]
        public string Q19 { get; private set; }
        [StringLength(50)]
        public string Q20 { get; private set; }
        [StringLength(50)]
        public string Q21 { get; private set; }
        [StringLength(50)]
        public string Q22 { get; private set; }
        [StringLength(50)]
        public string Q23 { get; private set; }
        [StringLength(50)]
        public string Q24 { get; private set; }
        [StringLength(50)]
        public string Q25 { get; private set; }
        [StringLength(50)]
        public string Q26 { get; private set; }
        [StringLength(50)]
        public string Q27 { get; private set; }
        [StringLength(50)]
        public string Q28 { get; private set; }
        [StringLength(50)]
        public string Q29 { get; private set; }
        [StringLength(50)]
        public string Q30 { get; private set; }
        [StringLength(50)]
        public string Q31 { get; private set; }
        [StringLength(50)]
        public string Q32 { get; private set; }
        [StringLength(50)]
        public string Q33 { get; private set; }
        [StringLength(50)]
        public string Q34 { get; private set; }
        [StringLength(50)]
        public string Q35 { get; private set; }
        [StringLength(50)]
        public string Q36 { get; private set; }
        [StringLength(1000)]
        public string Q37 { get; private set; }
        [StringLength(1000)]
        public string Q38 { get; private set; }
        [StringLength(1000)]
        public string Q39 { get; private set; }
    }
}
