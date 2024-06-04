using API.Common.Entities;

namespace API.Common.Specifications;

/// <summary>
///     Interface for the Specification pattern
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface ISpecification<in TEntity> 
    where TEntity : IEntityBase
{
    /// <summary>
    ///     The criteria.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    bool IsSatisfiedBy(TEntity entity);

}