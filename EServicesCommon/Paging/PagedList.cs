using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesCommon.Paging
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public int TotalCount { get; private set; }

        public int PageSize { get; private set; }

        public bool HasPreviousPage
        {
            get
            {

                return (CurrentPage > 1);
            }

        }

        public bool HasNextPage
        {
            get
            {

                return (CurrentPage < TotalPages);
            }

        }
      

        public PagedList(List<T> items, int count ,int pageNumber,int pageSize)
        {
            TotalCount = count;
            CurrentPage=pageNumber;
            PageSize= pageSize;
            TotalPages = (int) Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static async Task<PagedList<T>> Create (IQueryable<T> source,int pageNumber,int pageSize)
        {
            var count = await source.CountAsync().ConfigureAwait(false); ;
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false); ;
                return new PagedList<T>(items, items.Count(), pageNumber, pageSize);
        }

      
    }
}
