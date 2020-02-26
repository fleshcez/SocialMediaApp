using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialMediaApp.Api.ViewModels;
using SocialMediaApp.Data;
using SocialMediaApp.Domain.Entities;

namespace SocialMediaApp.Api.ViewModels
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<User, UserModelWithAddress>()
                .ForMember(c => c.StreetName, o => o.MapFrom(m => m.Address.StreetName))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(m => m.Address.HouseNumber))
                .ForMember(c => c.ApartmentNumber, o => o.MapFrom(m => m.Address.ApartmentNumber))
                .ReverseMap();
        }
    }
}
