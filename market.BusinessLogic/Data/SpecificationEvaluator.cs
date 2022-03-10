namespace market.BusinessLogic.Data
{
    using market.Core.Entities;
    using market.Core.Entities.Especifications;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class SpecificationEvaluator<T> where T : ClaseBase
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IEspecification<T> spec)
        {
            if (spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);
            }

            if(spec.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDescendign != null)
            {
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDescendign);
            }

            if (spec.IsPagingEnabled)
            {
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }

            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

            return inputQuery;
        }
    }
}
