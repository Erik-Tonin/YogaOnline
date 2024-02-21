namespace Application.DTOs
{
    public class UserDTO
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
