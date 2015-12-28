using System.ComponentModel.DataAnnotations;

namespace _6.CodeFirstPhonebook
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Not valid email supplied")]
        public string EmailAddress { get; set; }
    }
}
