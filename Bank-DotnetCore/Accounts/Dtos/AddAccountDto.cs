using System.ComponentModel.DataAnnotations;
using Accounts.Models;

namespace Bank_DotnetCore.Dtos
{
    public class AddAccountDto
    {
        public int UserProfileId { get; set; } = 0;
        public AccountTypes AccountType { get; set; }
    }
}
