using System;
using System.Collections.Generic;

namespace SocialMediaApp.Domain.Entities
{
    public partial class ReactionType
    {
        public ReactionType()
        {
            Reaction = new HashSet<Reaction>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Reaction> Reaction { get; set; }
    }
}
