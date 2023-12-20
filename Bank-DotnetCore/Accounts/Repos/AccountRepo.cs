using Accounts.DataContext;
using Accounts.Models;
using AutoMapper;
using Bank_DotnetCore.Dtos;

namespace Bank_DotnetCore.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private AccountsDBContext _dbContext;
        private IMapper _mapper;
        public AccountRepo(AccountsDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AccountModel> AddAccount(AddAccountDto user)
        {
            var accountToAddToDB = _mapper.Map<AccountModel>(user);
            _dbContext.Accounts.Add(accountToAddToDB);
            var addStatus = await _dbContext.SaveChangesAsync();
            if (addStatus != 0)
            {

                return accountToAddToDB;
            }
            else
            {
                return null;
            }
        }
    }
}
