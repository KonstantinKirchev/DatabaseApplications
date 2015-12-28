using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace _5.Problem
{
    public class User
    {
        private ICollection<Rating> ratings;
        private ICollection<Movie> movies; 

        public User()
        {
            this.ratings = new HashSet<Rating>();
            this.movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
