using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EservicesDomain.Attributes
{
    public class StaticDisplayRuleAttribute : Attribute
    {
        private bool showForIDs;

        public StaticDisplayRuleAttribute()
        { }

        public StaticDisplayRuleAttribute(short[] ShowForIDs)
        {
            IDs = ShowForIDs;
            showForIDs = true;
        }

        public StaticDisplayRuleAttribute(short[] ids, bool showForIDs)
        {
            IDs = ids;
            this.showForIDs = showForIDs;
        }

        public short[] IDs { get; set; }

        public bool IsVisible(short value)
        {
            bool isIdInTheList = IDs.Contains(value);
            return showForIDs ? isIdInTheList : !isIdInTheList;
        }
    }
}
