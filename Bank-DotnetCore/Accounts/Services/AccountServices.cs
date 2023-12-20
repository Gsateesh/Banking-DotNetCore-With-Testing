using Accounts.Models;
using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Repos;

namespace Bank_DotnetCore.Services
{
    public class AccountServices: IAccountServices
    {
        private IAccountRepo _accountRepo;
        public AccountServices(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public async Task<AccountModel> AddAccount(AddAccountDto user)
        {
            return await _accountRepo.AddAccount(user);
        }
    }
}
