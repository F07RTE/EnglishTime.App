using AutoMapper;

using EnglishTime.ApiRest.Dtos;
using EnglishTime.Data.Model;

public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
    }
}