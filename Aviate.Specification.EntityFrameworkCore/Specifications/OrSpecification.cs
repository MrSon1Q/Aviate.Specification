using System;
using System.Linq.Expressions;
using Aviate.Specification.EntityFrameworkCore.Utils;

namespace Aviate.Specification.EntityFrameworkCore.Specifications
{
    public sealed class OrSpecification<TEntity> : BaseSpecification<TEntity>
    {
        private readonly ISpecification<TEntity> _left;
        private readonly ISpecification<TEntity> _right;
        
        public override Expression<Func<TEntity, bool>> Predicate => _left.Predicate != null 
            ? Or(_left.Predicate, _right.Predicate) 
            : _right.Predicate;

        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            _left = left;
            _right = right ?? throw new ArgumentNullException(nameof(right));
        }
        
        private static Expression<Func<TEntity, bool>> Or(Expression<Func<TEntity, bool>> left, Expression<Func<TEntity, bool>> right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            var visitor = new SwapVisitor(left.Parameters[0], right.Parameters[0]);
            var binaryExpression = Expression.OrElse(visitor.Visit(left.Body), right.Body);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(binaryExpression, right.Parameters);
            
            return lambda;
        }
    }
}