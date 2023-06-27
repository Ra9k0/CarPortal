using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CarPortal.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }

        public Region Region { get; set; } = null!;
    }
}
