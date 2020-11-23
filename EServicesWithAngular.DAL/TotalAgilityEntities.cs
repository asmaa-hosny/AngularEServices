using Microsoft.EntityFrameworkCore;
using System;

namespace EServicesWithAngular.DAL
{
    //public partial class TotalAgilityEntities : DbContext
    //{
    //    public TotalAgilityEntities()
    //        : base("name=TotalAgilityEntities")
    //    {
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
            
    //    }


    //    public virtual ObjectResult<STATISTICS_GetRequestsReleatedToUser_Result> STATISTICS_GetRequestsReleatedToUser(string eMP_EMAIL, string rEF_ID, string requestor_Email, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
    //    {
    //        var eMP_EMAILParameter = eMP_EMAIL != null ?
    //            new ObjectParameter("EMP_EMAIL", eMP_EMAIL) :
    //            new ObjectParameter("EMP_EMAIL", typeof(string));

    //        var rEF_IDParameter = rEF_ID != null ?
    //            new ObjectParameter("REF_ID", rEF_ID) :
    //            new ObjectParameter("REF_ID", typeof(string));

    //        var requestor_EmailParameter = requestor_Email != null ?
    //            new ObjectParameter("Requestor_Email", requestor_Email) :
    //            new ObjectParameter("Requestor_Email", typeof(string));

    //        var fromDateParameter = fromDate.HasValue ?
    //            new ObjectParameter("FromDate", fromDate) :
    //            new ObjectParameter("FromDate", typeof(System.DateTime));

    //        var toDateParameter = toDate.HasValue ?
    //            new ObjectParameter("ToDate", toDate) :
    //            new ObjectParameter("ToDate", typeof(System.DateTime));

    //        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<STATISTICS_GetRequestsReleatedToUser_Result>("STATISTICS_GetRequestsReleatedToUser", eMP_EMAILParameter, rEF_IDParameter, requestor_EmailParameter, fromDateParameter, toDateParameter);
    //    }
    //}
}
