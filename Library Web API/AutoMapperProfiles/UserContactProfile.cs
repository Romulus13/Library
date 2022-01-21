using AutoMapper;
using Library_BL.Model;
using Library_Web_API.Requests;

namespace Library_Web_API.AutoMapperProfiles
{
    public class UserContactProfile : Profile
    {
        public UserContactProfile() 
        {

            CreateMap<UserContactRequestModel, UserContactModel>()
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => $"{src.Value}")
                )
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => $"{src.Type}")
                );
               
        }
    }
}
