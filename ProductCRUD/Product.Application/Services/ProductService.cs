using AutoMapper;
using Product.Application.DTOs;
using Product.Application.Interfaces;
using Product.Domain.Entities;
using Product.Domain.Interfaces;

namespace Product.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProductDto>> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            try
            {
                ProductEntity? product = await _productRepository.GetById(productId, cancellationToken);

                if (product == null)
                {
                    throw new Exception("There is no product with this id.");
                }

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                return ResponseDto<ProductDto>.Success(productDto);
            }
            catch
            {
                return ResponseDto<ProductDto>.Failure(500, "Error when getting product.");
            }
        }

        public async Task<ResponseDto<List<ProductDto>>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            try
            {
                List<ProductEntity>? products = await _productRepository.GetAll(cancellationToken);

                List<ProductDto> productsDto = _mapper.Map<List<ProductDto>>(products);

                return ResponseDto<List<ProductDto>>.Success(productsDto);
            }
            catch
            {
                return ResponseDto<List<ProductDto>>.Failure(500, "Error when getting products.");
            }
        }

        public async Task<ResponseDto<object>> AddProductAsync(ProductDto productDto, CancellationToken cancellationToken)
        {
            try
            {
                ProductEntity product = _mapper.Map<ProductEntity>(productDto);

                product.ValidateProduct();

                await _productRepository.Add(product, cancellationToken);

                return ResponseDto<object>.Success(true);
            }
            catch (DomainExceptionValidation e)
            {
                return ResponseDto<object>.Failure(500, "Error when registering product: " + e.Message);
            }
            catch
            {
                return ResponseDto<object>.Failure(500, "Error when registering product.");
            }
        }

        public async Task<ResponseDto<object>> UpdateProductAsync(ProductDto productDto, CancellationToken cancellationToken)
        {
            try
            {
                ProductEntity product = await _productRepository.GetById(productDto.Id, cancellationToken);

                product.UpdateProduct(productDto.Title, productDto.Description, productDto.Price, productDto.Stock, productDto.Photos);

                await _productRepository.Update(product, cancellationToken);

                return ResponseDto<object>.Success(true);
            }
            catch (DomainExceptionValidation e)
            {
                return ResponseDto<object>.Failure(500, "Error when updating product: " + e.Message);
            }
            catch
            {
                return ResponseDto<object>.Failure(500,"Error when updating product.");
            }
        }

        public async Task<ResponseDto<object>> DeleteProductAsync(int productId, CancellationToken cancellationToken)
        {
            try
            {
                await _productRepository.Delete(productId, cancellationToken);

                return ResponseDto<object>.Success(true);
            }
            catch
            {
                return ResponseDto<object>.Failure(500,"Error when deleting product.");
            }
        }
    }
}
