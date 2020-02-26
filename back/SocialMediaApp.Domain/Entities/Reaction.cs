using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApp.Domain.Entities
{
    public partial class Reaction
    {
        public int Id { get; set; }
        public int ReactionTypeId { get; set; }
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }

        public virtual Post Post { get; set; }
        public virtual ReactionType ReactionType { get; set; }
        public virtual User User { get; set; }
    }
}
