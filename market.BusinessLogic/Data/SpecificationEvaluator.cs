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

            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

            return inputQuery;
        }
    }
}
