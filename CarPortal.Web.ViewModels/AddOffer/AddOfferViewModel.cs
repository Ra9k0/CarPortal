
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Offer;
using CarPortal.Data.Models;

namespace CarPortal.Web.ViewModels.AddOffer
{
	public class AddOfferViewModel
	{
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public CarViewModel Car { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        public ApplicationUser Owner { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
