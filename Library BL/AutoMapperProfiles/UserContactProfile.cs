using AutoMapper;
using Library_BL.Model;
using Library_DAL.Models;

namespace Library_BL.AutoMapperProfiles
{
    public class UserContactProfile : Profile
    {
        public UserContactProfile() 
        {

            CreateMap<UserContactModel, UserContact>();
               
               
        }
    }
}
