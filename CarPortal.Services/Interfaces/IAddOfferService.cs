using CarPortal.Data.Models;
using CarPortal.Web.ViewModels.AddOffer;
using Category = CarPortal.Data.Models.Category;

namespace CarPortal.Services.Interfaces
{
	public interface IAddOfferService
	{
		Task<IEnumerable<MakeViewModel>> GetMakesByCategoryAsync(int categoryId);

		Task<IEnumerable<Category>> GetAllCategoriesAsync();

		Task<IEnumerable<ModelViewModel>> GetAllModelsAsync();

		Task<IEnumerable<ModelViewModel>> GetModelsByMakeAsync(int makeId);

		Task<IEnumerable<EngineTypeViewModel>> GetAllEngineTypes();

        Task<IEnumerable<ColorViewModel>> GetAllColors();

        Task<IEnumerable<ConditionViewModel>> GetAllConditions();
    }
}
