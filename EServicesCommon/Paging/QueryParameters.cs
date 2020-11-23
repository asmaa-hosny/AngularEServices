using CommonLibrary.Configuaration;
using EServicesCommon.Configuaration;
using EServicesCommon.DI;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesCommon.Paging
{
    public class QueryParameters
    {
        ICoreConfigurations _config = FactoryManager.Instance.Resolve<ICoreConfigurations>();

        public int PageNumber { get; set; } = 1;

        private int _pagesize;

        public int PageSize
        {
            get
            {
                if (_pagesize == 0 && _config != null && _config.MaxPageSize > 0)
                    return _config.MaxPageSize;
                else
                    return _pagesize;
            }

            set
            {

                if (_config != null && _config.MaxPageSize > 0)
                    _pagesize = value > _config.MaxPageSize ? _config.MaxPageSize : value;
                else
                    _pagesize = value;

            }

        }

        public string Fields { get; set; }

        public string SearchQuery { get; set; }

        //someColumnName descending or someColumnName
        public string OrderBy { get; set; }

        public string OrderBySort { get; set; }

        public string UserEmail { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }


    }
}
