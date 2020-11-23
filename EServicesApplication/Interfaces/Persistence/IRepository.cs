using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EServicesCommon.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace EServicesApplication.Interfaces.Persistence
{
    public interface IRepository<T, Tid> where T : class
    {
        DbSet<T> GetDbSet();

        IQueryable<T> GetQurable();

        Task<T> GetByIdAsync(Tid id);

        T GetById(Tid id);

        void Add(T entity);

        void Add(List<T> list);

        Task<List<T>> GetALLAsync();

        List<T> GetALL();

        void Remove(T enitty);

        void Update(T entity);

        Task<T> GetOneByExpressionAsync(Expression<Func<T, bool>> func);

        T GetOneByExpression(Expression<Func<T, bool>> func);

        Task<IEnumerable<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> func);

         IEnumerable<T> GetAllByExpression(Expression<Func<T, bool>> func);

        Task<IEnumerable<T>> GetAllByExpressionAsync(string expression, string orderBy=null);

        IEnumerable<T> GetAllByExpression(string expression, string orderBy = null);

        Task<T> GetOneByExpressionAsync(string expression);

        T GetOneByExpression(string expression);

        Task SaveChangesAsync();

        Task<PagedList<T>> GetListByQueryParameter(QueryParameters parameters);
    }
}
