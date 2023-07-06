using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CarPortal.Common.EntityValidationConstants.Car;

namespace CarPortal.Web.ViewModels.AddOffer
{
	public class CarViewModel
	{
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }

        public ModelViewModel Model { get; set; } = null!;

        [ForeignKey(nameof(Color))]
        public int ColorId { get; set; }

        public ColorViewModel Color { get; set; } = null!;

        [ForeignKey(nameof(EngineType))]
        public int EngineTypeId { get; set; }

        public EngineTypeViewModel EngineType { get; set; } = null!;

        [ForeignKey(nameof(Condition))]
        public int ConditionId { get; set; }

        public ConditionViewModel Condition { get; set; } = null!;

        [Required]
        [MinLength(MinYearManufacture)]
        [MaxLength(MaxYearManufacture)]
        public int ManufactureYear { get; set; }
    }
}
