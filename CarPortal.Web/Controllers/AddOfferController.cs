using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.AddOffer;
using CarPortal.Web.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarPortal.Web.Controllers
{
	public class AddOfferController : BaseController
	{
		private readonly IAddOfferService addOfferService;

		public AddOfferController(IAddOfferService addOfferService)
		{
			this.addOfferService = addOfferService;
		}

		public IActionResult Index()
		{
			ViewBag.Categories = addOfferService.GetAllCategoriesAsync().Result;

			return View();
		}

		[HttpPost]
		public IActionResult Index(AddOfferViewModel offer)
		{
			addOfferService.CreateOffer(offer,Guid.Parse(GetUserId()));
			return Redirect("Home");
		}

		public async Task<JsonResult> GetModelsList(int id, int categoryId)
		{
			var modelsList = await addOfferService.GetModelsByMakeAsync(id,categoryId);
            return Json(modelsList.ToList());
		}

		[HttpGet]
		public async Task<JsonResult> GetMakesList(int id)
		{
			var makesList = await addOfferService.GetMakesByCategoryAsync(id);
			return Json(makesList.ToList().DistinctBy(m=>m.Id));
		}
	}
}
