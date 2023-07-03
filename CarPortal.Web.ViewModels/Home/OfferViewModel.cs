
using CarPortal.Data.Models;

namespace CarPortal.Web.ViewModels.Home
{
	public class OfferViewModel
	{

		public Guid Id { get; set; }
		
		public string Title { get; set; } = null!;
		
		public decimal Price { get; set; }
		public string Description { get; set; } = null!;
		
		public int CarId { get; set; }
		
		public Guid OwnerId { get; set; }

		public DateTime CreatedOn { get; set; }

		public ICollection<Image> Images { get; set; }

	}
}
