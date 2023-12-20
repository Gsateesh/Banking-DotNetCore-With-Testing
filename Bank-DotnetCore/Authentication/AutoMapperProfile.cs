using AutoMapper;
using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Models;

namespace Bank_DotnetCore
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddUserDto, UserModel>();
            CreateMap<UserModel, GetUserDto>();
        }
    }
}
