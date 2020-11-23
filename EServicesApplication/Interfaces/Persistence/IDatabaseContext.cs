
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;


namespace EServicesApplication.Interfaces.Persistence
{
    public interface IDatabaseContext
    {
        void Dispose();

        void Save();

        Task SaveChangesAsync();

        DbSet<T> Set<T>() where T : class;

        EntityEntry Entry([NotNullAttribute] object entity);


    }
}
