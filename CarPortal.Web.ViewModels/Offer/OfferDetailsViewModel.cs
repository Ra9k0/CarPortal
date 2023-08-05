using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data.Models;

namespace CarPortal.Web.ViewModels.Offer
{
	public class OfferDetailsViewModel
	{
		public OfferDetailsViewModel()
		{
			Images = new List<Image>();
		}

		public Guid Id { get; set; }

		public string Title { get; set; } = null!;

		public decimal Price { get; set; }
		public string Description { get; set; } = null!;

		public int CarId { get; set; }

		public Car Car { get; set; } = null!;

		public Guid OwnerId { get; set; }

		public ApplicationUser Owner { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		public ICollection<Image> Images { get; set; } = null!;
	}
}
