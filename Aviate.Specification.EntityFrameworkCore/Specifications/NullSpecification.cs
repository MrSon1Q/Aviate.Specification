using System;
using System.Linq.Expressions;

namespace Aviate.Specification.EntityFrameworkCore.Specifications
{
    public sealed class NullSpecification<TEntity> : BaseSpecification<TEntity> 
    {
        public override Expression<Func<TEntity, bool>> Predicate { get; }
    }
}