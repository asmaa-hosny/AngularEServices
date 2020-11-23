using EServicesApplication.Interfaces.Persistence;

using System.Data;
using EServicesCommon.DI;
using Microsoft.Data.SqlClient;
using CommonLibrary.Configuaration;

namespace EServicesPersistance.Common
{
    public class AgilityRepository<T, Tid> : Repository<T, Tid> , IAgilityRepository<T, Tid> where T : class
    {
        private readonly IAgilityDBContext _dbContext;

        public AgilityRepository(IAgilityDBContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }


        public IDbConnection Connection
        {
            get
            {
                ICoreConfigurations _config = FactoryManager.Instance.Resolve<ICoreConfigurations>();

                return new SqlConnection(_config.TotalAgilityDBConnection);
            }
        }


    }
}
