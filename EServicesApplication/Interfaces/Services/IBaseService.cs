using EservicesDomain.ExternalModel.ERB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesApplication.Services
{
    public interface IBaseService<T,Tid>
    {
        Task AddNewRequest(T entity);

        Task UpdateRequest();
        Task<T> Update(T item);

        Task UpdateKtaJobID(Tid id, string jobId);

        T FindOneById(Tid id);

        T FindOneByJobId(string jobId);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(string condition);

        IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> func);

        IQueryable<T> GetQuerable();

        Task AddMultiple(List<T> listEntity);

        Task DeleteRequest(T entity);



    }
}
