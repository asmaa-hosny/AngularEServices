using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesApplication.Services.Common
{
    public class ListItemModel <T> 
    {
        public T Id { get; private set; }

        public string NameAr { get; private set; }

        public string NameEn { get; private set; }
    }
}
