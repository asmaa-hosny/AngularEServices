using EservicesDomain.Domain.DomainAgility;
using EservicesDomain.Domain.Workflow;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EServicesApplication.Interfaces.Persistence
{
    public interface IAgilityDBContext: IDatabaseContext
    {
        DbSet<CompletedTasks> CompletedTasksView { get; set; }

        DbSet<AllRequests> AllRequests { get; set; }

        DbSet<AllRequests> LiveActivity { get; set; }
    }
}
