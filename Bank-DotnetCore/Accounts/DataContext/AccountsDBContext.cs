using Accounts.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounts.DataContext
{
    public class AccountsDBContext : DbContext
    {
        public AccountsDBContext(DbContextOptions<AccountsDBContext> options) : base(options) { }
        public DbSet<AccountModel> Accounts { get; set; }
    }
}
