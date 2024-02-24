using YogaOnline.Domain.Entities;

namespace YogaOnline.Domain.Statics
{
    public class SegmentationStatic
    {
        /// <summary>
        /// Object instance.
        /// </summary>
        public SegmentationStatic(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public static SegmentationStatic Lighter = new SegmentationStatic(99, "Mais leve");
        public static SegmentationStatic MoreAgitated = new SegmentationStatic(98, "Mais agitado");
        public static SegmentationStatic Fun = new SegmentationStatic(88, "Divertido");

        public static List<SegmentationStatic> GetAll()
        {
            return new List<SegmentationStatic>()
            {
                Lighter,
                MoreAgitated,
                Fun
            };
        }

        public static SegmentationStatic GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public static Segmentation[] DataArray()
        {
            return GetAll().Select(x => new Segmentation(x.Id, x.Name)).ToArray();
        }
    }
}
