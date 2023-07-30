
using CarPortal.Data.Models;
using CarPortal.Web.ViewModels.AddOffer;

namespace CarPortal.Web.ViewModels.Home
{
	public class OfferViewModel
	{

		public Guid Id { get; set; }
		
		public string Title { get; set; } = null!;
		
		public decimal Price { get; set; }
		public string Description { get; set; } = null!;
		
		public int CarId { get; set; }

		public Car Car { get; set; } = null!;

		public Guid OwnerId { get; set; }

		public ApplicationUser Owner { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		public Image Images { get; set; } = null!;


    }
}
