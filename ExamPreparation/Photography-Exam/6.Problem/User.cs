using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _6.Problem
{
    public class User
    {
        private ICollection<Channel> channels;
        private ICollection<UserMessage> recipientUsers;
        private ICollection<UserMessage> senderUsers;

        public User()
        {
            this.channels = new HashSet<Channel>();
            this.recipientUsers = new HashSet<UserMessage>();
            this.senderUsers = new HashSet<UserMessage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Fullname { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Channel> Channels
        {
            get { return this.channels; }
            set { this.channels = value; }
        }

        [InverseProperty("Recipient")]
        public virtual ICollection<UserMessage> RecipientUsers
        {
            get { return this.recipientUsers; }
            set { this.recipientUsers = value; }
        }

        [InverseProperty("Sender")]
        public virtual ICollection<UserMessage> SenderUsers
        {
            get { return this.senderUsers; }
            set { this.senderUsers = value; }
        }
    }
}
