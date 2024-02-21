using YogaOnline.Domain.Core.Models;

namespace YogaOnline.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Name { get; private set; }
        public string? Email { get; private set; }

        public User(string? name, string? email)
        {
            Name = name;
            Email = email;
            DateCreated = DateTime.Now;
        }

        public void UpdateUser(string? name, string? email)
        {
            Name = name;
            Email = email;
            DateUpdated = DateTime.Now;
        }
    }
}
