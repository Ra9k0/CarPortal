using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CarPortal.Common.EntityValidationConstants.Car;

namespace CarPortal.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }

        public Model Model { get; set; } = null!;

        [ForeignKey(nameof(Color))]
        public int ColorId { get; set; }

        public Color Color { get; set; } = null!;

        [ForeignKey(nameof(EngineType))]
        public int EngineTypeId { get; set; }

        public EngineType EngineType { get; set; } = null!;

        [ForeignKey(nameof(Condition))]
        public int ConditionId { get; set; }

        public Condition Condition { get; set; } = null!;

        [Required]
        [MaxLength(MaxYearManufacture)]
        public int ManufactureYear { get; set; }

		public Offer Offer { get; set; } = null!;
	}
}
