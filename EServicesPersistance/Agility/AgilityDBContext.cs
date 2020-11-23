using EServicesApplication.Interfaces.Persistence;
using EservicesDomain.Domain.DomainAgility;
using Microsoft.EntityFrameworkCore;
using System;

using System.Threading.Tasks;

namespace EServicesPersistance.Common
{
    public class AgilityDBContext : DbContext , IAgilityDBContext
    {
        public virtual DbSet<CompletedTasks> CompletedTasksView { get; set; }

        public virtual DbSet<AllRequests> AllRequests { get; set; }

        public virtual DbSet<AllRequests> LiveActivity { get; set; }

        public AgilityDBContext(DbContextOptions<AgilityDBContext> options):base(options)
        {

        }
        public void Save()
        {
            throw new NotImplementedException();
        }

     

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgilityDBContext).Assembly);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
