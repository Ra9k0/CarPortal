using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarPortal.Data.Models;
using static CarPortal.Common.EntityValidationConstants.Model;

namespace CarPortal.Web.ViewModels.Offer
{
    public class ModelViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }

        public Make Make { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
