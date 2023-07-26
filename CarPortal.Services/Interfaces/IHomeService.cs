
using CarPortal.Data.Models;
using CarPortal.Web.ViewModels.Home;

namespace CarPortal.Services.Interfaces
{
	public interface IHomeService
	{
		Task<IEnumerable<OfferViewModel>> GetOffersAsyncByRegion(Guid id);

		Task<IEnumerable<OfferViewModel>> GetOffersAsync();

		Task<ApplicationUser?> GetApplicationUserAsync(Guid id);

		Task<Region?> GetRegionAsync(int id);
    }
}
