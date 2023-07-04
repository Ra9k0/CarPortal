using CarPortal.Data.Models;
using CarPortal.Web.ViewModels.AddOffer;
using Category = CarPortal.Data.Models.Category;

namespace CarPortal.Services.Interfaces
{
	public interface IAddOfferService
	{
		Task<IEnumerable<MakeViewModel>> GetMakesByCategoryAsync(int categoryId);

		Task<IEnumerable<Category>> GetAllCategoriesAsync();
	}
}
