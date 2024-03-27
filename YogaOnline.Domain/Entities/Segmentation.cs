using YogaOnline.Domain.Core.Models;

namespace YogaOnline.Domain.Entities
{
    public class Segmentation : BaseEntity
    {
        /// <summary>
        /// Object instance.
        /// </summary>
        public Segmentation(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Constructor without parameters to EF.
        /// </summary>

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
