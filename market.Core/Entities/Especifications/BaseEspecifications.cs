
namespace market.Core.Entities.Especifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class BaseEspecifications<T> : IEspecification<T>
    {
        public BaseEspecifications()
        {

        }
        public BaseEspecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
