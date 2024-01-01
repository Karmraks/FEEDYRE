using AutoMapper;
using FEEDYRE.Core.Models;
using FEEDYRE.Web.Dtos;

namespace FEEDYRE.Web.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
