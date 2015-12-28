using System.ComponentModel.DataAnnotations;

namespace _6.CodeFirstPhonebook
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
