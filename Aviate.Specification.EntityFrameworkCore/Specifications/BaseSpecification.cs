using System;
using System.Linq.Expressions;

namespace Aviate.Specification.EntityFrameworkCore.Specifications
{
    public abstract class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        /// <inheritdoc />
        public abstract Expression<Func<TEntity, bool>> Predicate { get; }
        
        /// <inheritdoc />
        public ISpecification<TEntity> And(ISpecification<TEntity> specification) => 
            new AndSpecification<TEntity>(this, specification);
        
        /// <inheritdoc />
        public ISpecification<TEntity> And(Expression<Func<TEntity, bool>> right)
        {
            if (right == null)
                throw new ArgumentNullException(nameof(right));
            
            return new AndSpecification<TEntity>(this, new ExpressionSpecification<TEntity>(right));
        }
        
        /// <inheritdoc />
        public ISpecification<TEntity> Or(ISpecification<TEntity> specification) =>
            new OrSpecification<TEntity>(this, specification);
        
        /// <inheritdoc />
        public ISpecification<TEntity> Or(Expression<Func<TEntity, bool>> right)
        {
            if (right == null)
                throw new ArgumentNullException(nameof(right));
            
            return new OrSpecification<TEntity>(this, new ExpressionSpecification<TEntity>(right));
        }
        
        /// <inheritdoc />
        public ISpecification<TEntity> Not() => new NotSpecification<TEntity>(this);
    }
}