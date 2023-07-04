using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Make;

namespace CarPortal.Web.ViewModels.AddOffer
{
	public class MakeViewModel
	{
		public MakeViewModel()
        {
            Models = new HashSet<ModelViewModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

        public ICollection<ModelViewModel> Models { get; set; }
	}
}
