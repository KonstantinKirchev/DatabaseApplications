using System.ComponentModel.DataAnnotations;

namespace _6.Problem
{
    public class Peak
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Elevation { get; set; }

        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; }

    }
}
