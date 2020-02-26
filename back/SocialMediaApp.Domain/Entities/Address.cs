using System;
using System.Collections.Generic;

namespace SocialMediaApp.Domain.Entities
{
    public partial class Address
    {
        public Address()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
