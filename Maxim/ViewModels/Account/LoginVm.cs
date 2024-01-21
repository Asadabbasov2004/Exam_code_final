using System.ComponentModel.DataAnnotations;

namespace Maxim.ViewModels.Account
{
    public class LoginVm
    {
        [Required]
        [MinLength(3, ErrorMessage = "Min length-3 letter")]
        [MaxLength(20, ErrorMessage = "Max length-20 letter")]
        public string UserNameOrEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
