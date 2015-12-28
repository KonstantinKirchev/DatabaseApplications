using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _6.Problem
{
    public class Country
    {
        private ICollection<Mountain> mountains;

        public Country()
        {
            this.mountains = new HashSet<Mountain>();
        }
        
        [Key]
        [MinLength(2)]
        [MaxLength(2)]
        public string CountryCode { get; set; }

        [Required]
        public string CountryName { get; set; }

        public virtual ICollection<Mountain> Mountains
        {
            get { return this.mountains; }
            set { this.mountains = value; }
        }

    }
}
