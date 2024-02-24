using YogaOnline.Domain.Core.Models;

namespace YogaOnline.Domain.Entities
{
    public class Teacher : BaseEntity
    {

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string NumberRegister { get; private set; }
        public string Profession { get; private set; }
        public int SegmentationId { get; private set; }
        //public virtual Segmentation Segmentation { get; private set; }



        public Teacher(string name, string email, string numberRegister, string profession, int segmentationId)
        {
            Name = name;
            Email = email;
            NumberRegister = numberRegister;
            Profession = profession;
            SegmentationId = segmentationId;
            DateCreated = DateTime.Now;
        }

        public void UpdateTeacher(string name, string email, string numberRegister, string profession, int segmentationId)
        {
            Name = name;
            Email = email;
            NumberRegister = numberRegister;
            Profession = profession;
            SegmentationId = segmentationId;
            DateUpdated = DateTime.Now;
        }



    }
}
