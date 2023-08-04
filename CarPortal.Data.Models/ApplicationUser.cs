using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static CarPortal.Common.EntityValidationConstants.ApplicationUser;

namespace CarPortal.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            Likes = new List<Like>();
        }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
		public string? LastName { get; set; }

        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }

        public Region? Region { get; set; } = null!;

        public ICollection<Like> Likes { get; set; }
    }
}
