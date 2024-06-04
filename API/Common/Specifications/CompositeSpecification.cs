using System.Linq.Expressions;
using API.Common.Entities;

namespace API.Common.Specifications;

/// <summary>
///     The composite specification.
/// </summary>
/// <param name="criteria"></param>
/// <typeparam name="TEntity"></typeparam>
public class CompositeSpecification<TEntity>(Expression<Func<TEntity, bool>> criteria) : Specification<TEntity>
    where TEntity : IEntityBase
{
    /// <summary>
    ///     The criteria.
    /// </summary>
    public override Expression<Func<TEntity, bool>> Criteria => criteria;
}