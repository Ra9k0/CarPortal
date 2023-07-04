using CarPortal.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarPortal.Web.Controllers
{
	public class AddOfferController : Controller
	{
		private readonly IAddOfferService addOfferService;

		public AddOfferController(IAddOfferService addOfferService)
		{
			this.addOfferService = addOfferService;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.Categories = new SelectList(await addOfferService.GetAllCategoriesAsync(), "Id","Name");

			return View();
		}

		public async Task<JsonResult> GetMakes(int categoryId)
		{
			return Json(await addOfferService.GetMakesByCategoryAsync(categoryId));
		}
	}
}
