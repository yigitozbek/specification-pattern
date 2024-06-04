using API.Common.Entities;

namespace API.Common.Specifications;

/// <summary>
///     Specification pattern
/// </summary>
public static class SpecificationExtensions
{
    /// <summary>
    ///     Extension method to apply a specification to a query
    /// </summary>
    /// <param name="query"></param>
    /// <param name="specification"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> query,
        Specification<TEntity> specification)
        where TEntity : IEntityBase
    {
        return query.Where(specification.Criteria);
    }
}