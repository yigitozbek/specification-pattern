using System.Linq.Expressions;
using API.Common.Entities;

namespace API.Common.Specifications;

/// <summary>
///     The not specification.
/// </summary>
/// <param name="specification"></param>
/// <typeparam name="TEntity"></typeparam>
public class NotSpecification<TEntity>(Specification<TEntity> specification) : Specification<TEntity>
    where TEntity : IEntityBase
{
    /// <summary>
    ///     The criteria.
    /// </summary>
    public override Expression<Func<TEntity, bool>> Criteria
    {
        get
        {
            var param = Expression.Parameter(typeof(TEntity));
            var body = Expression.Not(Expression.Invoke(specification.Criteria, param));
            return Expression.Lambda<Func<TEntity, bool>>(body, param);
        }
    }
}