using System;
using System.Dynamic;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    protected BaseSpecification() : this(null) { }
    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDesc { get; private set; }

    public bool isDistinct { get; private set; }

    protected void AddOrderBy(Expression<Func<T, object>> orderByEx)
    {
        OrderBy = orderByEx;
    }
    protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescEx)
    {
        OrderByDesc = orderByDescEx;
    }

    protected void ApplyDistinct()
    {
        isDistinct = true;
    }
}

public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> criteria)
: BaseSpecification<T>(criteria), ISpecification<T, TResult>
{
    protected BaseSpecification() : this(null!) { }
    public Expression<Func<T, TResult>>? Select { get; private set; }

    protected void AddSelect(Expression<Func<T, TResult>> selectEx)
    {
        Select = selectEx;
    }
}

