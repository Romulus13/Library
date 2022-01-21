using AutoMapper;
using Library_BL;
using Library_BL.Model;
using Library_Web_API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Web_API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, UserModel>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => $"{src.FirstName}")
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => $"{src.LastName}")
                )
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                )
                .ForMember(
                    dest => dest.BirthDate,
                    opt => opt.MapFrom(src => $"{src.BirthDate}")
                );

            
        }
    }
}
