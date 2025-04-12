using Product.Domain.Entities;

namespace Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> GetById(int productId, CancellationToken cancellationToken);

        Task<List<ProductEntity>> GetAll(CancellationToken cancellationToken);

        Task Add(ProductEntity product, CancellationToken cancellationToken);

        Task Update(ProductEntity product, CancellationToken cancellationToken);

        Task Delete(int productId, CancellationToken cancellationToken);
    }
}
