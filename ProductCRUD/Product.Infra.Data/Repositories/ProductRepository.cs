using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ProductEntity> GetById(int productId, CancellationToken cancellationToken)
        {
            ProductEntity? product = await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);

            return product;
        }

        public async Task<List<ProductEntity>> GetAll(CancellationToken cancellationToken)
        {
            List<ProductEntity>? products = await _applicationDbContext.Products.AsNoTracking().ToListAsync(cancellationToken);

            return products;
        }

        public async Task Add(ProductEntity product, CancellationToken cancellationToken)
        {
            await _applicationDbContext.Products.AddAsync(product, cancellationToken);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(ProductEntity product, CancellationToken cancellationToken)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _applicationDbContext.Products.Update(product);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(int productId, CancellationToken cancellationToken)
        {
            ProductEntity? product = await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _applicationDbContext.Products.Remove(product);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
