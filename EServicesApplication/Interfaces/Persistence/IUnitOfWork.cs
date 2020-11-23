
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
