using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Code_First
{
    public class Peak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Elevation { get; set; }

        //[ForeignKey("Mountain")]
        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
