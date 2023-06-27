using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarPortal.Common.EntityValidationConstants.Model;

namespace CarPortal.Data.Models
{
    public class Model
    {
        public Model()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Make))]
        public int MakeId { get; set; }

        public Make Make { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}
