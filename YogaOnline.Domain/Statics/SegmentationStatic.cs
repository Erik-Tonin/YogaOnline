using YogaOnline.Domain.Entities;

namespace YogaOnline.Domain.Statics
{
    public class SegmentationStatic
    {
        /// <summary>
        /// Object instance.
        /// </summary>
        public SegmentationStatic(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static SegmentationStatic Lighter = new SegmentationStatic(Guid.Parse("93497a8e-ccf5-4214-a76e-07f2ae45245d"), "Mais leve");
        public static SegmentationStatic MoreAgitated = new SegmentationStatic(Guid.Parse("8aaf42b7-790d-4264-aec3-1c788b045062"), "Mais agitado");
        public static SegmentationStatic Fun = new SegmentationStatic(Guid.Parse("db314610-87f1-42fa-8426-f0607cc30c84"), "Divertido");

        public static List<SegmentationStatic> GetAll()
        {
            return new List<SegmentationStatic>()
            {
                Lighter,
                MoreAgitated,
                Fun
            };
        }

        public static SegmentationStatic GetById(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public static Segmentation[] DataArray()
        {
            return GetAll().Select(x => new Segmentation(x.Id, x.Name)).ToArray();
        }
    }
}
