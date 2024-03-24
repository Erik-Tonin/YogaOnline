using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IFormFile File { get; set;}
        public string ImageUrl { get; set; }

    }
}
