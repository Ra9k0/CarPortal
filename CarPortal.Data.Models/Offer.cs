using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarPortal.Common.EntityValidationConstants.Offer;

namespace CarPortal.Data.Models
{
    public class Offer
    {
        public Offer()
        {
            Id = Guid.NewGuid();
            Images = new HashSet<Image>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(PriceMinLength,PriceMaxLength)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public Car Car { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        public ApplicationUser Owner { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
