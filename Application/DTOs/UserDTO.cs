namespace Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
