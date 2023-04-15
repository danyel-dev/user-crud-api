using AutoMapper;
using user_crud_api.Domain.Dto;
using user_crud_api.Domain.Model;

namespace user_crud_api.Domain.Profiles;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<UserRegisterDto, User>();
        CreateMap<User, UserProfileDto>();
    }
}
