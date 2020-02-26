using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApp.Domain.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public string CommentId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
