namespace market.Core.Entities.Especifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IEspecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }
    }
}
