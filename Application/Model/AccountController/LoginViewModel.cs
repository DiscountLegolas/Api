using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Model.AccountController
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="E-Mail adı zorunludur.")]
        public string EMail { get; set; }

        [Required(ErrorMessage ="Şifre zorunludur.")]
        public string Password { get; set; }
    }
}