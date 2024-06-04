using System.Linq.Expressions;
using API.Common.Entities;

namespace API.Common.Specifications;

/// <summary>
///     Represents a specification.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class Specification<TEntity> : ISpecification<TEntity>
    where TEntity : IEntityBase
{
    
    /// <summary>
    ///     Gets the criteria of the specification.
    /// </summary>
    public abstract Expression<Func<TEntity, bool>> Criteria { get; }
 
    /// <summary>
    ///     Checks if the specification is satisfied by the entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public bool IsSatisfiedBy(TEntity entity)
    {
        return Criteria
            .Compile()
            .Invoke(entity);
    }
    
    /// <summary>
    ///     Combines two specifications using the AND operator.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Specification<TEntity> operator &(Specification<TEntity> left, Specification<TEntity> right)
    {
        return new AndSpecification<TEntity>(left, right);
    }
    
    /// <summary>
    ///     Combines two specifications using the OR operator.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Specification<TEntity> operator |(Specification<TEntity> left, Specification<TEntity> right)
    {
        return new OrSpecification<TEntity>(left, right);
    }
    
    
    /// <summary>
    ///     Negates the specification.
    /// </summary>
    /// <param name="specification"></param>
    /// <returns></returns>
    public static Specification<TEntity> operator !(Specification<TEntity> specification)
    {
        return new NotSpecification<TEntity>(specification);
    }
    
    /// <summary>
    ///     Implicitly converts the specification to a lambda expression.
    /// </summary>
    /// <param name="specification"></param>
    /// <returns></returns>
    public static implicit operator Expression<Func<TEntity, bool>>(Specification<TEntity> specification)
    {
        return specification.Criteria;
    }
    
}