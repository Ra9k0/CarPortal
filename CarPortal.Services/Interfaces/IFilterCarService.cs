using CarPortal.Data.Models;
using CarPortal.Web.ViewModels.FilterCar;
using CarPortal.Web.ViewModels.Home;
using CarPortal.Web.ViewModels.Offer;
using CarPortal.Web.ViewModels.User;

namespace CarPortal.Services.Interfaces
{
    public interface IFilterCarService
	{
		Task<IEnumerable<OfferViewModel>> GetAllOffersAsync();

		Task<IEnumerable<Category>> GetCategoriesAsync();

		Task<IEnumerable<MakeViewModel>> GetMakesByCategoryAsync(int categoryId);

		Task<IEnumerable<ModelViewModel>> GetModelsByMakeAsync(int makeId, int categoryId);

		Task<IEnumerable<EngineTypeViewModel>> GetAllEngineTypesAsync();
		Task<IEnumerable<ColorViewModel>> GetAllColorsAsync();

		Task<IEnumerable<ConditionViewModel>> GetAllConditionsAsync();

		Task<IEnumerable<RegionViewModel>> GetAllRegionsAsync();

		Task<IEnumerable<OfferViewModel>> FilteredOffers(FilterCarViewModel filter,string orderer);
	}
}
