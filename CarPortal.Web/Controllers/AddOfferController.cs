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

		public IActionResult Index()
		{
			ViewBag.Makes = addOfferService.GetAllModelsAsync().Result.DistinctBy(m=>m.MakeId);
			ViewBag.Models = addOfferService.GetAllModelsAsync().Result;

			return View();
			}

		public async Task<JsonResult> GetModelsList(int id)
		{
			var MakesList = await addOfferService.GetModelsByMakeAsync(id);
				
            return Json(MakesList.ToList());
		}
	}
}
