using CarPortal.Web.ViewModels.AddOffer;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using CarPortal.Data.Models;
using static CarPortal.Common.EntityValidationConstants.Offer;

namespace CarPortal.Web.ViewModels.FilterCar
{
	public class FilterCarViewModel
	{
		[Range(PriceMinLength, PriceMaxLength, ErrorMessage = "The Price must valid.")]
		public decimal? Price { get; set; }

		public FilterCarCarViewModel? Car { get; set; } = null!;

		public int? RegionId { get; set; }

		public DateTime? CreatedOn { get; set; }
	}
}
