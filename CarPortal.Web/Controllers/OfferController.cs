using CarPortal.Services.Interfaces;
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
	}
}
