using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Api.ViewModels
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public DateTime TimeStamp { get; set; }

        public string userUserName { get; set; }
        public string userName { get; set; }
    }
}
