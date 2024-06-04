using System.Linq.Expressions;

namespace API.Common.Specifications;

/// <summary>
///     The replace parameter visitor.
/// </summary>
/// <param name="oldParameter"></param>
/// <param name="newParameter"></param>
public class ReplaceParameterVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
    : ExpressionVisitor
{
    /// <summary>
    ///     Visit the parameter.
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected override Expression VisitParameter(ParameterExpression node)
    {
        return node == oldParameter ? newParameter : base.VisitParameter(node);
    }
}