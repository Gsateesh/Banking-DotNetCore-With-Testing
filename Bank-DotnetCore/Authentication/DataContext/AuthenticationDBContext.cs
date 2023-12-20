using Bank_DotnetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataContext
{
    public class AuthenticationDBContext: DbContext
    {
        public AuthenticationDBContext(DbContextOptions<AuthenticationDBContext> options): base(options) { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserLogin> Logins { get; set; }

    }
}
