using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _5.Problem
{
    public class Country
    {
        private ICollection<User> users;

        public Country()
        {
            this.users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
