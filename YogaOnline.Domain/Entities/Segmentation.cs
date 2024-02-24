using YogaOnline.Domain.Core.Models;

namespace YogaOnline.Domain.Entities
{
    public class Segmentation : BaseEntity
    {
        /// <summary>
        /// Object instance.
        /// </summary>
        public Segmentation(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Constructor without parameters to EF.
        /// </summary>

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
