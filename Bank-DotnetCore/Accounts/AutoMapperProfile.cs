using Accounts.Models;
using AutoMapper;
using Bank_DotnetCore.Dtos;

namespace Bank_DotnetCore
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddAccountDto, AccountModel>();
        }
    }
}
