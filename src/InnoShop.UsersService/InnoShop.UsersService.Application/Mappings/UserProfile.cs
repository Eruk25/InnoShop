using AutoMapper;
using InnoShop.UsersService.Application.Users;
using InnoShop.UsersService.Application.Users.Register;
using InnoShop.UsersService.Application.Users.Results;
using InnoShop.UsersService.Domain.Entities;

namespace InnoShop.UsersService.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, RegisterUserResult>().ReverseMap();
        CreateMap<User, UpdateUserByAdminResult>().ReverseMap();
        CreateMap<User, UpdateUserProfileResult>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}