using Aviate.Specification.EntityFrameworkCore.Specifications;

namespace Aviate.Specification.EntityFrameworkCore.Factories
{
    /// <summary>
    /// Interface specification factory.
    /// </summary>
    public interface ISpecificationFactory
    {
        ISpecification<TEntity> Create<TEntity>();
    }
}