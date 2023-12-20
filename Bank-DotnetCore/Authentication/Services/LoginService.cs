using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Models;

namespace Bank_DotnetCore.Services
{
    public class LoginService : ILoginService, ILoginsRepo
    {
        private ILoginsRepo _loginsRepo;
        public LoginService(ILoginsRepo loginsRepo)
        {

            _loginsRepo = loginsRepo;

        }
        public async Task<LoginResponse> Login(LoginUserDto user)
        {
            var loginSuccss = await _loginsRepo.LoginUser(user.UserName, user.Password);
            return loginSuccss;
        }

        public Task<string> LoginUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUser(UserModel user, string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string userName)
        {
            throw new NotImplementedException();
        }

        Task<LoginResponse> ILoginsRepo.LoginUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}

public interface ILoginService
{
    Task<LoginResponse> Login(LoginUserDto user);
}