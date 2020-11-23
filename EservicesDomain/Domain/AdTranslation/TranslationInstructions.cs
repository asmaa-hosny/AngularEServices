using EservicesDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EservicesDomain.Domain.AdTranslation
{
    public class TranslationInstructions : IEntity<int>
    {
        public string ProcessName { get; set; }
        public string InstructionsAR { get; set; }
        public string InstructionsEN { get; set; }
    }
}
