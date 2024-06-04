using System.Linq.Expressions;
using API.Common.Specifications;

namespace API.Entities.Specifications.Tasks;

/// <summary>
///     The specification for tasks that contain the specified title.
/// </summary>
/// <param name="title"></param>
public class TitleContainsSpecification(string title) : Specification<Task>
{
    /// <summary>
    ///     The criteria for tasks that contain the specified title.
    /// </summary>
    public override Expression<Func<Task, bool>> Criteria => task => task.Title.Contains(title);
}