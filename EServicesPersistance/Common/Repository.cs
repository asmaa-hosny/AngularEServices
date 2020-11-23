using EServicesApplication.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using EServicesCommon.Paging;
using System.Linq.Expressions;

namespace EServicesPersistance.Common
{
    public class Repository<T, Tid> : IRepository<T, Tid> , IDisposable where T : class 
    {
        private readonly IDatabaseContext _dbContext;

        public Repository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> GetDbSet()
        {
            return _dbContext.Set<T>();

        }

        public List<T> GetALL()
        {
            return _dbContext.Set<T>().ToList();
        }

        public async Task<List<T>> GetALLAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }



        public IQueryable<T> GetQurable()
        {
            var dbset = _dbContext.Set<T>().AsQueryable().AsNoTracking();
            return dbset;
        }

        public async Task<T> GetByIdAsync(Tid id)
        {
            var entity = await GetDbSet().FindAsync(id).ConfigureAwait(false);

            return entity;
        }

        public T GetById(Tid id)
        {
            var entity = GetDbSet().Find(id);

            return entity;
        }

        public async Task<T> GetOneByExpressionAsync(Expression<Func<T, bool>> func)
        {
            return await GetDbSet().AsNoTracking().Where(func).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public T GetOneByExpression(Expression<Func<T, bool>> func)
        {
            return GetDbSet().AsNoTracking().Where(func).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> func)
        {
            return await GetDbSet().AsNoTracking().Where(func).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<T> GetAllByExpression(Expression<Func<T, bool>> func)
        {
            return GetDbSet().AsNoTracking().Where(func).ToList();
        }

        public async Task<IEnumerable<T>> GetAllByExpressionAsync(string expression, string orderBy = null)
        {
            if (!string.IsNullOrEmpty(orderBy))
                return await GetDbSet().AsNoTracking().Where(expression).OrderBy(orderBy).ToListAsync().ConfigureAwait(false);
            else
                return await GetDbSet().Where(expression).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<T> GetAllByExpression(string expression, string orderBy = null)
        {
            //myDataSource.OrderBy("someColumnName descending")
            //myDataSource.where("categoryId=2 And unitprice>3")
            if (!string.IsNullOrEmpty(orderBy))
                return GetDbSet().AsNoTracking().Where(expression).OrderBy(orderBy).ToList();
            else
                return GetDbSet().Where(expression).ToList();
        }


        public async Task<T> GetOneByExpressionAsync(string expression)
        {
            return await GetDbSet().Where(expression).AsNoTracking().FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public T GetOneByExpression(string expression)
        {
            return GetDbSet().Where(expression).AsNoTracking().FirstOrDefault();
        }

        public void Remove(T enitty)
        {
            GetDbSet().Remove(enitty);

        }

        public void Add(T entity)
        {
            GetDbSet().Add(entity);
        }

        public void Add(List<T> list)
        {
            GetDbSet().AddRange(list);
        }


        public void Update(T entity)
        {

            GetDbSet().Update(entity);

        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async virtual Task<PagedList<T>> GetListByQueryParameter(QueryParameters parameters)
        {
            var orderedList = GetDbSet().OrderBy(parameters.OrderBy).AsQueryable();

            string[] fieldstofilter = parameters.Fields.Split(',');

            if (fieldstofilter != null && fieldstofilter.Count() > 0)
                foreach (var field in fieldstofilter)
                    if (!string.IsNullOrEmpty(parameters.SearchQuery))
                        orderedList = orderedList.Where($"{field}.Contains(\"{parameters.SearchQuery}\")");

            var pagedList = await PagedList<T>.Create(orderedList, parameters.PageNumber, parameters.PageSize);
            return pagedList;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }


    }
}
