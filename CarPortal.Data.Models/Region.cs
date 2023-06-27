using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Region;

namespace CarPortal.Data.Models
{
    public class Region
    {
        public Region()
        {
            Users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
