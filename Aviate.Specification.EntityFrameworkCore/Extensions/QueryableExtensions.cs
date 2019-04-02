using System.Linq;
using Aviate.Specification.EntityFrameworkCore.Specifications;

namespace Aviate.Specification.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IQueryable{T}"/>.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="queryable">Provides functionality to evaluate queries against a specific data source wherein the type of the data is known.</param>
        /// <param name="specification"></param>
        /// <typeparam name="TEntity">The type of the data in the data source.</typeparam>
        /// <returns></returns>
        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> queryable,
            ISpecification<TEntity> specification) => queryable.Where(specification.Predicate);
    }
}