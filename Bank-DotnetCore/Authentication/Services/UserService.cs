using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Models;
using Bank_DotnetCore.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Bank_DotnetCore.Services
{
    public class UserService : IUserService, ILoginsRepo
    {
        private IUserRepo _repo;
        private ILoginsRepo _loginsRepo;
        public UserService(IUserRepo repo, ILoginsRepo loginsRepo)
        {
            _loginsRepo = loginsRepo;
            _repo = repo;

        }
        public async Task<UserModel> CreateUser(AddUserDto user)
        {
            var userFromDB = await _repo.CreateUser(user);
            await _loginsRepo.RegisterUser( userFromDB, user.Email, user.Password);

            return userFromDB;

        }

        public string GetNameById(int id)
        {
            return _repo.GetNameById(id);
        }

        public async Task<GetUserDto> GetUserById(int id)
        {
            return await _repo.GetUserById(id);

        }

        public Task<bool> LoginUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        //public Task<User> DeleteUser(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<User> GetUserById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            return await _repo.UpdateUser(user);
        }

        Task<LoginResponse> ILoginsRepo.LoginUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        Task<bool> ILoginsRepo.RegisterUser(UserModel user, string userName, string password)
        {
            throw new NotImplementedException();
        }

        Task<bool> ILoginsRepo.UserExists(string userName)
        {
            throw new NotImplementedException();
        }
    }
}

public interface IUserService
{
    Task<UserModel> CreateUser(AddUserDto user);
    Task<GetUserDto> GetUserById(int id);
    Task<UserModel> UpdateUser(UserModel user);
    //Task<User> DeleteUser(int id);
    string GetNameById(int id);


}