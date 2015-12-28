using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace _6.CodeFirstPhonebook
{
    public class Contact
    {
        private ICollection<Email> emails;
        private ICollection<Phone> phones;

        public Contact()
        {
            this.emails = new HashSet<Email>();
            this.phones = new HashSet<Phone>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        [DataType(DataType.Url)]
        public string SiteUrl { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        public virtual ICollection<Email> Emails
        {
            get { return this.emails; }
            set { this.emails = value; }
        }

        public virtual ICollection<Phone> Phones
        {
            get { return this.phones; }
            set { this.phones = value; }
        }
    }
}
