using Aviate.Specification.EntityFrameworkCore.Specifications;

namespace Aviate.Specification.EntityFrameworkCore.Factories
{
    public sealed class SpecificationFactory : ISpecificationFactory
    {
        public ISpecification<TEntity> Create<TEntity>() =>
            new NullSpecification<TEntity>();
    }
}