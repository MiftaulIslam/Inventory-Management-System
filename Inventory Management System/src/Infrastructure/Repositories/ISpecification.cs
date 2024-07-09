using System.Linq.Expressions;

namespace Infrastructure.Repositories;
public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> Ascending { get; }
    Expression<Func<T, object>> Descending { get; }
    int Skip { get; }
    int Take { get; }
    bool IsPagingEnabled { get; }
}

public class Specification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
    public Expression<Func<T, object>> Ascending { get; private set; } = x => x!;
    public Expression<Func<T, object>> Descending { get; private set; } = x => x!;
    public int Skip { get; private set; }
    public int Take { get; private set; }
    public bool IsPagingEnabled { get; private set; }

    public Specification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Specification<T> Include(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
        return this;
    }

    public Specification<T> OrderBy(Expression<Func<T, object>> orderByExpression)
    {
        Ascending = orderByExpression;
        return this;
    }

    public Specification<T> OrderByDesc(Expression<Func<T, object>> orderByDescendingExpression)
    {
        Descending = orderByDescendingExpression;
        return this;
    }

    public Specification<T> ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
        return this;
    }
}
