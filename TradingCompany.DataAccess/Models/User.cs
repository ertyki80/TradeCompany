using System;
using System.ComponentModel.DataAnnotations;

namespace TradingCompany.DataAccess.Models
{
    public class User
    {
        [Required(ErrorMessage = "Id is null", AllowEmptyStrings = true)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Login is empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Login is short(Length>3)")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Password is short(Length>8)")]
        public string Password { get; set; }

        public Role Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public DateTime? TimeOfCreating { get; set; }

    }
}
