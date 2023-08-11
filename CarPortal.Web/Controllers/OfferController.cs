using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Offer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarPortal.Web.Controllers;

public class OfferController : BaseController
{
	private readonly IOfferService offerService;

	public OfferController(IOfferService offerService)
	{
		this.offerService = offerService;
	}

	[AllowAnonymous]
	public async Task<IActionResult> Details(string offerId)
	{
		ViewBag.Offer = await offerService.GetOfferByIdAsync(offerId);
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Delete(string id)
	{
		try
		{

			bool isAdmin = User.IsInRole("Admin");
			await offerService.Delete(id, GetUserId(),isAdmin);
			if (User.IsInRole("Admin"))
			{
				return RedirectToAction("All", "Offer", new { area = "Admin" });
			}
			return RedirectToAction("MyOffers", "Profile");
		}
		catch (Exception ex)
		{
			TempData["ErrorMessage"] = ex.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpGet]
	public async Task<IActionResult> Edit(string id)
	{
		try
		{
			ViewBag.Categories = await offerService.GetAllCategoriesAsync();
			bool isAdmin = User.IsInRole("Admin");
			ViewBag.Offer = await offerService.GetOfferForEditByIdAsync(id, GetUserId(),isAdmin);
			return View();
		}
		catch (Exception ex)
		{
			TempData["ErrorMessage"] = ex.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpPost]
	public async Task<IActionResult> Edit(OfferEditViewModel offer)
	{
		await offerService.EditOfferAsync(offer);
		if (User.IsInRole("Admin"))
		{
			return RedirectToAction("All", "Offer", new { area = "Admin" });
		}
		return RedirectToAction("Index", "FilterCar");
	}

	public IActionResult Add()
	{
		ViewBag.Categories = offerService.GetAllCategoriesAsync().Result;

		return View();
	}

	[HttpPost]
	public IActionResult Add(AddOfferViewModel offer)
	{
		offerService.CreateOffer(offer, Guid.Parse(GetUserId()));
		return RedirectToAction("MyOffers","Profile");
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