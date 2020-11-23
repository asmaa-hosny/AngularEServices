using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EServicesApplication.Extensions
{
    //public static class Extensions
    //{
    //    public static IQueryable<TSource> ObjectFilter<TSource>(this TSource SearchObject, List<Predicate<TSource>> andCriteria, List<Predicate<TSource>> orCriteria) where TSource : IQueryable<TSource>
    //    {
    //        Expression<Func<TSource, bool>> ObjectWhere = null;
    //        if (andCriteria != null)
    //            ObjectWhere = O => andCriteria.All(pred => pred(O))
    //        else if (orCriteria != null)

    //            Expression<Func<TSource, bool>> ObjectWhere = O => andCriteria.All(pred => pred(O)) && orCriteria.Any(pred => pred(O));
    //        return SearchObject.Where<TSource>(ObjectWhere);
    //    }


    //}
}
