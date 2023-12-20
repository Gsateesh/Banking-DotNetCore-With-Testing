using Accounts.Models;
using Bank_DotnetCore.Dtos;

namespace Bank_DotnetCore.Repos
{
    public interface IAccountRepo
    {
        public Task<AccountModel> AddAccount(AddAccountDto user);
    }
}
