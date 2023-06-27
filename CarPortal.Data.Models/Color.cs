using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Color;

namespace CarPortal.Data.Models
{
    public class Color
    {
        public Color()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required] 
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}
