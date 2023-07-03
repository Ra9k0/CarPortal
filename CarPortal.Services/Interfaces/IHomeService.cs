
using CarPortal.Data.Models;
using CarPortal.Web.ViewModels.Home;

namespace CarPortal.Services.Interfaces
{
	public interface IHomeService
	{
		Task<IEnumerable<OfferViewModel>> GetOffersAsync(Guid id);
	}
}
