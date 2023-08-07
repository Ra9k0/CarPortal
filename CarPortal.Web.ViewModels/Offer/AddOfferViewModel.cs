using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Offer;
using CarPortal.Data.Models;
using Microsoft.AspNetCore.Http;

namespace CarPortal.Web.ViewModels.Offer
{
    public class AddOfferViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = $"The Title must be between 10 and 100 characters.")]
        public string Title { get; set; } = null!;

        [Required]
        [Range(PriceMinLength, PriceMaxLength, ErrorMessage = "The Price must valid.")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "The Description must be between 100 and 1000 characters.")]
        public string Description { get; set; } = null!;

        public CarViewModel Car { get; set; } = null!;

        public Guid OwnerId { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "Please select at least one image.")]
        public List<IFormFile> ImageFiles { get; set; } = null!;
    }
}
