using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.DataContext;
using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bank_DotnetCore.Repos
{
    public class LoginsRepo : ILoginsRepo
    {
        private AuthenticationDBContext _dbContext;
        private IConfiguration _iConfiguration;
        public LoginsRepo(AuthenticationDBContext dBContext, IConfiguration iConfiguration)
        {
            _dbContext = dBContext;
            _iConfiguration = iConfiguration;

        }
        public async Task<LoginResponse> LoginUser(string userName, string password)
        {
            var userFromDB = await _dbContext.Logins.Include(uu => uu.User).FirstOrDefaultAsync(u => u.UserName == userName);
            if (userFromDB == null)
            {
                return new LoginResponse() { Token = null };
            }
            else if(!VerifyPassword(password, userFromDB.PasswordHash, userFromDB.PasswordSalt))
            {
                return new LoginResponse() { Token = null };
            }
            else
            {
                return new LoginResponse() { Token = GenerateToken(userFromDB) };
            }
        }

        public async Task<bool> RegisterUser(UserModel user, string userName, string password)
        {
            var userExists = await UserExists(userName);
            if (userExists)
            {
                return false;
            }
            byte[] passwordSalt;
            byte[] passwordHash;
            CreatePasswordHashAndSalt(password, out passwordHash, out passwordSalt);
            _dbContext.Logins.Add(new UserLogin() { UserName = userName, PasswordHash = passwordHash, PasswordSalt = passwordSalt, User = user });
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExists(string userName)
        {
            var userExists = await _dbContext.Logins.AnyAsync(u => u.UserName.ToLower() == userName);
            return userExists;
        }

        private void CreatePasswordHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        private string GenerateToken(UserLogin userFromDB)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userFromDB.User.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromDB.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_iConfiguration.GetSection("AppSettings:Token").Value ));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

public interface ILoginsRepo
{
    Task<bool> RegisterUser(UserModel user, string userName, string password);
    Task<LoginResponse> LoginUser(string userName, string password);
    Task<bool> UserExists(string userName);
}