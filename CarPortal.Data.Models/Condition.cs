using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Condition;

namespace CarPortal.Data.Models
{
    public class Condition
    {
        public Condition()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}
