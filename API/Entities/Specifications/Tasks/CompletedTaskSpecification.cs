using System.Linq.Expressions;
using API.Common.Specifications;

namespace API.Entities.Specifications.Tasks;

/// <summary>
///     The specification for completed tasks.
/// </summary>
public class CompletedTaskSpecification : Specification<Task>
{
    
    /// <summary>
    ///     The criteria for completed tasks.
    /// </summary>
    public override Expression<Func<Task, bool>> Criteria => task => task.IsDone;
}