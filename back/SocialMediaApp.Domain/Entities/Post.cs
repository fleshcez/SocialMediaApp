using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApp.Domain.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
            Reaction = new HashSet<Reaction>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Reaction> Reaction { get; set; }
    }
}
