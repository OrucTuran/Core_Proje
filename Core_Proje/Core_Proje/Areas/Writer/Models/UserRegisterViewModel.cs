using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your surname.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter your Image URL.")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Please enter your username.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please re-enter your password.")]
        [Compare("Password", ErrorMessage = "Passwords are not compatible.")]
        public string ConfrimPassword { get; set; }
        [Required(ErrorMessage = "Please enter your mail.")]
        public string Mail { get; set; }
    }
}
