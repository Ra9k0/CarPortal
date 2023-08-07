using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.EngineType;
namespace CarPortal.Web.ViewModels.Offer
{
    public class EngineTypeViewModel
    {
        [Key]
        public int Id { get; set; }

        [MinLength(TypeMinLength)]
        [MaxLength(TypeMaxLength)]
        [Required]
        public string Type { get; set; } = null!;
    }
}
