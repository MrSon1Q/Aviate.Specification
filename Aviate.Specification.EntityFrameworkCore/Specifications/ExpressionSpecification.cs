using System;
using System.Linq.Expressions;

namespace Aviate.Specification.EntityFrameworkCore.Specifications
{
    public sealed class ExpressionSpecification<TEntity> : BaseSpecification<TEntity>
    {
        public override Expression<Func<TEntity, bool>> Predicate { get; }

        public ExpressionSpecification(Expression<Func<TEntity, bool>> predicate)
        {
            Predicate = predicate;
        }
    }
}