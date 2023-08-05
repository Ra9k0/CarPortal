using CarPortal.Web.ViewModels.Home;
using CarPortal.Web.ViewModels.Offer;

namespace CarPortal.Services.Interfaces
{
	public interface IOfferService
	{
		Task<OfferDetailsViewModel> GetOfferByIdAsync(string offerId);
	}
}
