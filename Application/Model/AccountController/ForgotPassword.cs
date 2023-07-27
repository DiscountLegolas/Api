using System.ComponentModel.DataAnnotations;

namespace Application.Model.AccountController
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
