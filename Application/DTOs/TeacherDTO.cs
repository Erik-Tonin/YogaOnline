using YogaOnline.Domain.Entities;

namespace Application.DTOs
{
    public class TeacherDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? NumberRegister { get; set; }
        public virtual Segmentation Segmentation { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}
