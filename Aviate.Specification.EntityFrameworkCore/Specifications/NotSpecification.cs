using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aviate.Specification.EntityFrameworkCore.Specifications
{
    public sealed class NotSpecification<TEntity> : BaseSpecification<TEntity>
    {
        private readonly ISpecification<TEntity> _left;

        public override Expression<Func<TEntity, bool>> Predicate => Not(_left.Predicate);

        public NotSpecification(ISpecification<TEntity> left)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));
        }

        private static Expression<Func<TEntity, bool>> Not(Expression<Func<TEntity, bool>> left)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            var notExpression = Expression.Not(left.Body);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(notExpression, left.Parameters.Single());
            
            return lambda;
        }
    }
}