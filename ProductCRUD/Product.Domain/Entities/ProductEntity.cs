using System.Xml.Linq;

namespace Product.Domain.Entities
{
    public class ProductEntity
    {
        public ProductEntity(string title, string? description, decimal price, int stock, string[]? photos)
        {
            Title = title;
            Description = description;
            Price = price;
            Stock = stock;
            Photos = photos;
        }

        protected ProductEntity()
        {
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string? Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string[]? Photos { get; private set; }

        public void UpdateProduct(string title, string? description, decimal price, int stock, string[]? photos)
        {
            Title = title;
            Description = description;
            Price = price;
            Stock = stock;
            Photos = photos;

            ValidateProduct();
        }

        public void ValidateProduct()
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Title), "The title must not be empty.");
        }
    }
}
