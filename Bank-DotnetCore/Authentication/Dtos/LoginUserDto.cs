using System.ComponentModel.DataAnnotations;

namespace Bank_DotnetCore.Dtos
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
