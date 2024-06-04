using System.Linq.Expressions;
using API.Common.Specifications;

namespace API.Entities.Specifications.Tasks;

/// <summary>
///     The specification for not completed tasks.
/// </summary>
public class NotCompletedTaskSpecification : Specification<Task>
{
    /// <summary>
    ///     The criteria for not completed tasks.
    /// </summary>
    public override Expression<Func<Task, bool>> Criteria => task => !task.IsDone;
}