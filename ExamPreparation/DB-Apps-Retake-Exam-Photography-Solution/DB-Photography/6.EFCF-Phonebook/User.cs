using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _6.EFCF_Phonebook
{
    public class User
    {

        private ICollection<Channel> channels;
        private ICollection<ChannelMessage> channelMessages;
        private ICollection<UserMessage> senderUserMessages;
        private ICollection<UserMessage> receiverUserMessages; 

        public User()
        {
            this.channels = new HashSet<Channel>();
            this.channelMessages = new HashSet<ChannelMessage>();
            this.senderUserMessages = new HashSet<UserMessage>();
            this.receiverUserMessages = new HashSet<UserMessage>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Channel> Channels
        {
            get { return this.channels; }
            set { this.channels = value; }
        }

        public virtual ICollection<ChannelMessage> ChannelMessages 
        { 
            get { return this.channelMessages; } 
            set { this.channelMessages = value; } 
        }
        
        [InverseProperty("Sender")]
        public virtual ICollection<UserMessage> SenderUserMessages {
            get { return this.senderUserMessages; }
            set { this.senderUserMessages = value; } }
        
        [InverseProperty("Recipient")]
        public virtual ICollection<UserMessage> ReceiverUserMessages {
            get { return this.receiverUserMessages; }
            set { this.receiverUserMessages = value; } }
    }
}
