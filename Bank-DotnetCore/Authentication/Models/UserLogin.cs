using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_DotnetCore.Models
{
    public class UserLogin
    {
        [Required]
        public int Id { get; set; }
        public string UserName { get; set;} = string.Empty;
        [Required]
        public byte[] PasswordHash { get; set; } = new byte[32];
        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public UserModel User { get; set; }
        
        

    }
}
