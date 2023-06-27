using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.EngineType;

namespace CarPortal.Data.Models
{
    public class EngineType
    {
        public EngineType()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(TypeMaxLength)]
        [Required]
        public string Type { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}
