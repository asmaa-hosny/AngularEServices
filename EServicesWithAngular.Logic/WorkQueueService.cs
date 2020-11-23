
using System.Collections.Generic;

using EServicesWithAngular.DAL;
using EServicesWithAngular.Domain.Common;

namespace EServicesWithAngular.Logic
{
    public class WorkQueueService
    {
        public static List<WorkQueueItem> LoadWorkqueue(string sessionID)
        {
            var workQueueItems = KtaConnectService.LoadWorkQueue(sessionID);
            return workQueueItems;
        }

    }
}
