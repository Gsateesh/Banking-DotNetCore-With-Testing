using System.ComponentModel.DataAnnotations;
using Bank_DotnetCore.Models;

namespace Bank_DotnetCore.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public UserRoles Role { get; set; } = UserRoles.Manager;
    }
}
