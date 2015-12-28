using System.ComponentModel.DataAnnotations;

namespace _6.Problem
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not valid email supplied")]
        public string EmailAddress { get; set; }

        public int ContactId { get; set; }
        
        public virtual Contact Contact { get; set; }
    }
}
