using System.ComponentModel.DataAnnotations;

namespace Bank_DotnetCore.Models
{
    public class AddUserLogin
    {
        public string UserName { get; set; } = string.Empty;
        [Required]
        public byte[] PasswordHash { get; set; } = new byte[32];
        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[32];
    }
}
