using CarPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarPortal.Web.Areas.Admin.Controllers
{
	public class OfferController : BaseController
	{
		private readonly IOfferService offerService;

		public OfferController(IOfferService offerService)
		{
			this.offerService = offerService;
		}

		public async Task<IActionResult> All()
		{
			ViewBag.CarsToShow = await offerService.GetAllOffersAsync();
			return View();
		}
	}
}
