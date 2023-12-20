using Authentication.DataContext;
using AutoMapper;
using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Bank_DotnetCore.Repos
{
    public class UserRepo : IUserRepo
    {
        private AuthenticationDBContext _authRepo;
        private IMapper _mapper;
        public UserRepo(AuthenticationDBContext authRepo, IMapper mapper)
        {
            _authRepo = authRepo;
            _mapper = mapper;
        }
        public async Task<UserModel> CreateUser(AddUserDto user)
        {
            var userExists = await UserExists(user.Email);
            if (userExists)
            {
                return null;
            }
            var userToDB = _mapper.Map<UserModel>(user);
            _authRepo.Users.Add(userToDB);
            await _authRepo.SaveChangesAsync();
            return userToDB;
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            var UserRef = await _authRepo.Users.FindAsync(id);
            if (UserRef == null)
            {
                return null;
            }
            else
            {
                _authRepo.Users.Remove(UserRef);
                await _authRepo.SaveChangesAsync();
                return UserRef;
            }
        }

        public string GetNameById(int id)
        {
            if (id == 0)
            {
                return "NotFOund";
            }
            else
            {
                return "Sateesh";
            }
        }

        public async Task<GetUserDto> GetUserById(int id)
        {
            var userFromDB = await _authRepo.Users.FindAsync(id);
            return _mapper.Map<GetUserDto>(userFromDB);
            
        }
        public async Task<UserModel> UpdateUser(UserModel user)
        {
            var UserRef = await _authRepo.Users.FindAsync(user.Id);
            if(UserRef == null)
            {
                return null;
            } else
            {
                UserRef.FirstName = user.FirstName;
                UserRef.LastName = user.LastName;
                UserRef.Email = user.Email;
                UserRef.Address = user.Address;
                _authRepo.Entry(user);
                await _authRepo.SaveChangesAsync();
                return UserRef;
            }
            
        }
        public async Task<bool> UserExists(string userName)
        {
            var userExists = await _authRepo.Users.AnyAsync(u => u.Email.ToLower() == userName);
            return userExists;
        }
    }
}

public interface IUserRepo
{
    Task<UserModel> CreateUser(AddUserDto user);
    Task<UserModel> UpdateUser(UserModel user);
    Task<UserModel> DeleteUser(int id);
    Task<GetUserDto> GetUserById(int id);
    string GetNameById(int id);

}