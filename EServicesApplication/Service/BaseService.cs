using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CommonLibrary.Configuaration;
using EServicesApplication.Interfaces.Infrastructure;
using EServicesApplication.Interfaces.Persistence;
using EServicesApplication.Interfaces.Services;
using EServicesCommon.DI;
using EservicesDomain.Common;
using System.Linq;
using CommonLibrary.Logging;
using EServicesApplication.Interfaces.Common;

namespace EServicesApplication.Services
{
    public class BaseService<T, Tid> : IBaseService<T, Tid> where T : class
    {
        public IRepository<T, Tid> _repository => FactoryManager.Instance.Resolve<IRepository<T, Tid>>();

        public IMapper Mapper => FactoryManager.Instance.Resolve<IMapper>();

        protected IKTAService KtaService => FactoryManager.Instance.Resolve<IKTAService>();

        protected IEmployeeService employeeService => FactoryManager.Instance.Resolve<IEmployeeService>();

        protected ICoreConfigurations AppConfiguaraton => FactoryManager.Instance.Resolve<ICoreConfigurations>();

        public IDecisionService decisionService => FactoryManager.Instance.Resolve<IDecisionService>();

        protected IADServiceD ADService => FactoryManager.Instance.Resolve<IADServiceD>();

        public ILoggerManager logger = FactoryManager.Instance.Resolve<ILoggerManager>();

        public IFileService FileService => FactoryManager.Instance.Resolve<IFileService>();


        public async Task AddNewRequest(T entity)
        {
            _repository.Add(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task AddMultiple(List<T> listEntity)
        {
            _repository.Add(listEntity);
            await _repository.SaveChangesAsync();
        }
        public async Task<T> Update(T item)
        {
            _repository.Update(item);

            await _repository.SaveChangesAsync();

            return item;

        }

        public IQueryable<T> GetQuerable()
        {
            return _repository.GetQurable();
        }


        public async Task UpdateRequest()
        {
            await _repository.SaveChangesAsync();
        }
     
        public T FindOneById(Tid id)
        {
            var result =  _repository.GetById(id);
            return result;
        }



        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> func)
        {
            var result =  _repository.GetAllByExpression(func);
            return result;

        }


        public IEnumerable<T> GetAll()
        {
            var result = _repository.GetALL();
            return result;

        }

        public  IEnumerable<T> Find(string condition)
        {
            var result = _repository.GetAllByExpression(condition);
            return result;

        }


        public  T FindOneByJobId(string jobId)
        {
            var result =  _repository.GetOneByExpression($"JobId==\"{jobId}\"");
            return result;
        }


        public async Task UpdateKtaJobID(Tid id, string jobId)
        {
            var entity =  _repository.GetById(id);

            if (entity is IKtaEntity<Tid>)
            {
                var ktaEntity = entity as IKtaEntity<Tid>;
                ktaEntity.JobId = jobId;
                _repository.Update(entity);
                await _repository.SaveChangesAsync();
            }

        }


        public async Task DeleteRequest(T entity)
        {
            _repository.Remove(entity);
            await _repository.SaveChangesAsync();
        }


    }
}
