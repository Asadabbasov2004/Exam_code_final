using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Maxim.ViewModels.Account
{
    public class RegisterVm
    {
        [Required]
        [MinLength(3,ErrorMessage ="Min length-3 letter")]
        [MaxLength(20,ErrorMessage ="Max length-20 letter")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min length-3 letter")]
        [MaxLength(20, ErrorMessage = "Max length-20 letter")]
        public string Surname { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min length-3 letter")]
        [MaxLength(20, ErrorMessage = "Max length-20 letter")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Min length-6 letter")]
        [MaxLength(20, ErrorMessage = "Max length-20 letter")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="This is not same password")]
        public string ConfirmPassword { get; set; }

    }
}
