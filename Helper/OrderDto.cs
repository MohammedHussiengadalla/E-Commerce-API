using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Helper
{
    public class OrderDto
    {
        [Required]
        public List<OrderItemDto> Items { get; set; }
    }
}
