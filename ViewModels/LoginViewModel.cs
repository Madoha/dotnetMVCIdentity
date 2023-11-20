using System.ComponentModel.DataAnnotations;

namespace dotnetMVCIdentity.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
