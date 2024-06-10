using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Helper
{
    public class UserRegistrationDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
