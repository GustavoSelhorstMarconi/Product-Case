using ProductMvc.Models;

namespace ProductMvc.Interfaces
{
    public interface IProductService
    {
        Task<ProductModel> Find(int productId);

        Task<List<ProductModel>> FindAll();

        Task Create(ProductModel productModel);

        Task Update(ProductModel productModel);

        Task Delete(int productId);
    }
}
