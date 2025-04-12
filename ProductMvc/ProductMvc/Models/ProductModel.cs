using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMvc.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string[]? Photos { get; set; }

        [NotMapped]
        public string PhotosInput
        {
            get => Photos != null ? string.Join("\n", Photos) : "";
            set => Photos = value?.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
