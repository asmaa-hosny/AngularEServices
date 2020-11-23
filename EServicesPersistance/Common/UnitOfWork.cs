using EServicesApplication.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EServicesPersistance.Common
{
    public class UnitOfWork :  IUnitOfWork
    {
        private readonly IDatabaseContext _dbContext;

        public UnitOfWork(IDatabaseContext database)
        {
            _dbContext = database;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
