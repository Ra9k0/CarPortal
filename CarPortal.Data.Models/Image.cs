using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarPortal.Common.EntityValidationConstants.Image;

namespace CarPortal.Data.Models
{
    public class Image
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PathMaxLength)]
        public string PhotoPath { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Offer))]
        public Guid OfferId { get; set; }

        public Offer Offer { get; set; } = null!;
    }
}
