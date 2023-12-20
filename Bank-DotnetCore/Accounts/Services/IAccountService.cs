using Accounts.Models;
using Bank_DotnetCore.Dtos;

namespace Bank_DotnetCore.Services
{
    public interface IAccountServices
    {
        public Task<AccountModel> AddAccount(AddAccountDto user);
    }
}
