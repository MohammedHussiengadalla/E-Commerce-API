using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Helper
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
