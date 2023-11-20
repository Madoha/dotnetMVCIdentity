using System.ComponentModel.DataAnnotations;

namespace dotnetMVCIdentity.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
