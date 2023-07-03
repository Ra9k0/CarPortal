using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;

namespace CarPortal.Web.Controllers
{
    public class HomeController : BaseController
    {

		private readonly IHomeService homeService;

		public HomeController(IHomeService homeService)
		{
			this.homeService = homeService;
		}

		[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
	        IEnumerable<OfferViewModel> offer = new List<OfferViewModel>();

			if (User.Identity.IsAuthenticated)
	        {
				offer = await homeService.GetOffersAsync(Guid.Parse(GetUserId()));
			}

	        return View(offer);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}