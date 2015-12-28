using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _6.Problem
{
    public class Mountain
    {
        private ICollection<Peak> peaks;

        public Mountain()
        {
            this.peaks = new HashSet<Peak>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Country")]
        public string CountryCode { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Peak> Peaks
        {
            get { return this.peaks; }
            set { this.peaks = value; }
        }
    }
}
