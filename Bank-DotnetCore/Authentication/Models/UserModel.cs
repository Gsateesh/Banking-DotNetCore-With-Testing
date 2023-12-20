using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Bank_DotnetCore.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public UserRoles Role { get; set; } = UserRoles.Manager;
    }
}
