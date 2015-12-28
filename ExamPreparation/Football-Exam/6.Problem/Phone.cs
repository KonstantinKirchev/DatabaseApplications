using System.ComponentModel.DataAnnotations;

namespace _6.Problem
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
