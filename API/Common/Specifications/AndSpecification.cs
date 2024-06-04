using System.Linq.Expressions;
using API.Common.Entities;

namespace API.Common.Specifications;

/// <summary>
///     The specification for the AND operation.
/// </summary>
/// <param name="left"></param>
/// <param name="right"></param>
/// <typeparam name="TEntity"></typeparam>
public class AndSpecification<TEntity>(Specification<TEntity> left, Specification<TEntity> right)
    : Specification<TEntity>
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
            var body = Expression.AndAlso(
                Expression.Invoke(left.Criteria, param),
                Expression.Invoke(right.Criteria, param)
            );
            return Expression.Lambda<Func<TEntity, bool>>(body, param);
        }
    }
}