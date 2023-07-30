using CarPortal.Services;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.FilterCar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CarPortal.Web.Controllers
{
	public class FilterCarController : BaseController
	{
		private readonly IFilterCarService filterCarService;

		public FilterCarController(IFilterCarService filterCarService)
		{
			this.filterCarService = filterCarService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			ViewBag.CarsToShow = await filterCarService.GetAllOffersAsync();
			ViewBag.Categories = await filterCarService.GetCategoriesAsync();
			ViewBag.EngineTypes = await filterCarService.GetAllEngineTypesAsync();
			ViewBag.Colors = await filterCarService.GetAllColorsAsync();
			ViewBag.Conditions = await filterCarService.GetAllConditionsAsync();
			ViewBag.Regions = await filterCarService.GetAllRegionsAsync();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(FilterCarViewModel filter, string orderer)
		{
			ViewBag.CarsToShow = await filterCarService.FilteredOffers(filter,orderer);
			return View();
		}

		public async Task<JsonResult> GetModelsList(int id, int categoryId)
		{
			var modelsList = await filterCarService.GetModelsByMakeAsync(id, categoryId);
			return Json(modelsList.ToList());
		}

		[HttpGet]
		public async Task<JsonResult> GetMakesList(int id)
		{
			var makesList = await filterCarService.GetMakesByCategoryAsync(id);
			return Json(makesList.ToList().DistinctBy(m => m.Id));
		}
	}
}
