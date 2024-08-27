using AuthNote.Api.Controllers.User;
using AuthNote.Domain.Models;
using AutoMapper;

namespace AuthNote.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserResponse>();
        }
    }
}
