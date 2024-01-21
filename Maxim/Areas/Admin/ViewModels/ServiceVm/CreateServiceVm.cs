using System.ComponentModel.DataAnnotations;

namespace Maxim.Areas.Admin.ViewModels.ServiceVm
{
    public class CreateServiceVm
    {
        public IFormFile? Image { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min length 3 letter")]
        [MaxLength(30, ErrorMessage = "Max length 30 letter")]
        public string Title { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min length 3 letter")]
        [MaxLength(30, ErrorMessage = "Max length 30 letter")]
        public string Description { get; set; }

    }
}
