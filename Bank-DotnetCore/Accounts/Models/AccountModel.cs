using System.ComponentModel.DataAnnotations;
using Bank_DotnetCore.Models;
using Microsoft.VisualBasic;

namespace Accounts.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }
        public long AccountNumber { get; set; } = DateTime.Now.Ticks;
        public AccountTypes AccountType { get; set; }
        public double AvailableBalance { get; set; } = 0.0;
        public int UserProfileId { get; set; } = 0;
        [EmailAddress]
        public string EmailAddress { get; set; } = "defaultemail@default.com";
    }
}
