using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarPortal.Data.Models;
using static CarPortal.Common.EntityValidationConstants.Offer;
using static CarPortal.Common.EntityValidationConstants.Car;
using CarPortal.Web.ViewModels.Offer;

namespace CarPortal.Web.ViewModels.FilterCar
{
    public class FilterCarCarViewModel
	{
        [ForeignKey(nameof(Model))]
		public int? ModelId { get; set; }
		public ModelViewModel? Model { get; set; }

		[Range(MinYearManufacture, MaxYearManufacture, ErrorMessage = "Enter a valid year of manufacture.")]
		public int? ManufactureYear { get; set; }

		public int? ColorId { get; set; }

		public int? EngineTypeId { get; set; }

		public int? ConditionId { get; set; }
	}
}
