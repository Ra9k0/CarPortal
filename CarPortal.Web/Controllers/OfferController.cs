using CarPortal.Services;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Offer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPortal.Web.Controllers
{
    public class OfferController : BaseController
	{
		private readonly IOfferService offerService;

		public OfferController(IOfferService offerService)
		{
			this.offerService = offerService;
		}

		public async Task<IActionResult> Details(string offerId)
		{
			ViewBag.Offer =await offerService.GetOfferByIdAsync(offerId);
			return View();
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			ViewBag.Categories = await offerService.GetAllCategoriesAsync();
			ViewBag.Offer = await offerService.GetOfferForEditByIdAsync(id);
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Edit(OfferEditViewModel offer)
		{
			await offerService.EditOfferAsync(offer);
			return RedirectToAction("Index","FilterCar");
		}

		[HttpPost]
		public IActionResult Index(AddOfferViewModel offer)
		{
			offerService.CreateOffer(offer, Guid.Parse(GetUserId()));
			return Redirect("Home");
		}

		public async Task<JsonResult> GetModelsList(int id, int categoryId)
		{
			var modelsList = await offerService.GetModelsByMakeAsync(id, categoryId);
			return Json(modelsList.ToList());
		}

		[HttpGet]
		public async Task<JsonResult> GetMakesList(int id)
		{
			var makesList = await offerService.GetMakesByCategoryAsync(id);
			return Json(makesList.ToList().DistinctBy(m => m.Id));
		}
	}
}
