using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EservicesDomain.Attributes
{
    public class EditWhenNodeIDAttribute : Attribute
    {
        public EditWhenNodeIDAttribute(bool always = false)
        {
            this.always = always;
        }
        public EditWhenNodeIDAttribute(short[] editForIDs)
        {
            EditForIDs = editForIDs;
        }

        public short[] EditForIDs { get; set; }
        private bool always;

        public bool IsEditable(short id)
        {
            if (EditForIDs != null)
                return EditForIDs.Contains(id);
            return always;
        }
    }
}
