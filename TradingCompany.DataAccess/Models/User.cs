using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class User
    {
        [Required(ErrorMessage = "Идентификатор пользователя не установлен", AllowEmptyStrings = true)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Login is empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Login is short(Lenght>3)")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Password is short(Lenght>8)")]
        public string Password { get; set; }

        public Role Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public DateTime? TimeOfCreating { get; set; }

    }
}
