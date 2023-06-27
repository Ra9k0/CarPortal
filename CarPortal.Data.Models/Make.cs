using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Make;

namespace CarPortal.Data.Models
{
    public class Make
    {
        public Make()
        {
            Models = new HashSet<Model>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Model> Models { get; set; }
    }
}
