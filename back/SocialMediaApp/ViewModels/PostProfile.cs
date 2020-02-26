using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Api.ViewModels
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostModel>()
                .ForMember(d => d.userName, o => o.MapFrom(s => s.User.Name))
                .ForMember(d => d.userUserName, o => o.MapFrom(s => s.User.UserName))
                .ReverseMap()
                .ForMember(p => p.User, o => o.Ignore());
        }
    }
}
