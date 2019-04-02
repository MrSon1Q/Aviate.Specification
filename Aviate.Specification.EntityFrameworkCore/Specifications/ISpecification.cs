using System;
using System.Linq.Expressions;

namespace Aviate.Specification.EntityFrameworkCore.Specifications
{
    /// <summary>
    /// Interface specification which describes condition as predicate.
    /// </summary>
    /// <typeparam name="TEntity">Entity.</typeparam>
    public interface ISpecification<TEntity>
    {
        /// <summary>
        /// Predicate.
        /// </summary>
        Expression<Func<TEntity, bool>> Predicate { get; }
        
        /// <summary>
        /// Adds new predicate from <see cref="specification"/> to existing specification through condition AND (&&).
        /// </summary>
        /// <param name="specification">Specification with predicate for add to existing specification.</param>
        /// <returns>Return resulting specification.</returns>
        ISpecification<TEntity> And(ISpecification<TEntity> specification);

        /// <summary>
        /// Adds new predicate <see cref="right"/> to existing specification through condition AND (&&).
        /// </summary>
        /// <param name="right">Predicate for add to existing specification.</param>
        /// <returns>Return resulting specification.</returns>
        ISpecification<TEntity> And(Expression<Func<TEntity, bool>> right);

        /// <summary>
        /// Adds new predicate from <see cref="specification"/> to existing specification through condition OR (||).
        /// </summary>
        /// <param name="specification">Specification with predicate for add to existing specification.</param>
        /// <returns>Return resulting specification.</returns>
        ISpecification<TEntity> Or(ISpecification<TEntity> specification);
        
        /// <summary>
        /// Adds new predicate <see cref="right"/> to existing specification through condition OR (||).
        /// </summary>
        /// <param name="right">Predicate for add to existing specification.</param>
        /// <returns>Return resulting specification.</returns>
        ISpecification<TEntity> Or(Expression<Func<TEntity, bool>> right);
        
        /// <summary>
        /// Satisfies the negation condition.
        /// </summary>
        /// <returns>Return resulting specification.</returns>
        ISpecification<TEntity> Not();
    }
}