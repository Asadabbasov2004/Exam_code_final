using Maxim.Models.Entities.Common;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Maxim.Models.Entities
{
    public class Service:BaseEntity
    {
        [Required]
        [MinLength(3,ErrorMessage ="Min length 3 letter")]
        [MaxLength(30,ErrorMessage ="Max length 30 letter")]
        public string Title { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min length 3 letter")]
        [MaxLength(30, ErrorMessage = "Max length 30 letter")]
        public string Description { get; set; }
        [Required]
        public string ImgUrl { get; set; }
    }
}
