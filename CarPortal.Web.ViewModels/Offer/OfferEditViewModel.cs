using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using CarPortal.Data.Models;
using static CarPortal.Common.EntityValidationConstants.Offer;

namespace CarPortal.Web.ViewModels.Offer
{
    public class OfferEditViewModel
	{

		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = $"The Title must be between 10 and 100 characters.")]
		public string Title { get; set; } = null!;

		[Required]
		[Range(PriceMinLength, PriceMaxLength, ErrorMessage = "The Price must valid.")]
		public decimal Price { get; set; }

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "The Description must be between 100 and 1000 characters.")]
		public string Description { get; set; } = null!;

		public CarViewModel Car { get; set; } = null!;
		public Model Model { get; set; } = null!;

		public string CategoryName { get; set; } = null!;

		public string MakeName { get; set; } = null!;

		public string EngineTypeName { get; set; } = null!;

		public string ColorName { get; set; } = null!;

		public string ConditionName { get; set; } = null!;
	}
}
