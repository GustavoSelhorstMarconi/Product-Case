using Product.Application.DTOs;

namespace Product.Application.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDto<ProductDto>> GetProductByIdAsync(int productId, CancellationToken cancellationToken);

        Task<ResponseDto<List<ProductDto>>> GetAllProductsAsync(CancellationToken cancellationToken);

        Task<ResponseDto<object>> AddProductAsync(ProductDto product, CancellationToken cancellationToken);

        Task<ResponseDto<object>> UpdateProductAsync(ProductDto product, CancellationToken cancellationToken);

        Task<ResponseDto<object>> DeleteProductAsync(int productId, CancellationToken cancellationToken);
    }
}
