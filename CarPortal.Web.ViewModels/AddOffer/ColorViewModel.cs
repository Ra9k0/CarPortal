using static CarPortal.Common.EntityValidationConstants.Color;
using System.ComponentModel.DataAnnotations;

namespace CarPortal.Web.ViewModels.AddOffer
{
	public class ColorViewModel
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
