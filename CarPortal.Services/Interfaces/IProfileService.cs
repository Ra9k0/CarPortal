
using CarPortal.Web.ViewModels.Home;

namespace CarPortal.Services.Interfaces
{
	public interface IProfileService
	{
		Task<IEnumerable<OfferViewModel>> GetMyOffersAsync(string id);
		void Like(Guid offerId, string userId);
		void Dislike(Guid offerId, string userId);
		Task<IEnumerable<OfferViewModel>> GetLikedOffersAsync(string id);
	}
}
