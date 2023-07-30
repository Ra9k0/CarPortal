using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CarPortal.Data.Models;
using System.Security.Cryptography;
using Microsoft.Extensions.Hosting;

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
	        IEnumerable<OfferViewModel> offers = new List<OfferViewModel>();
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser? user = await homeService.GetApplicationUserAsync(Guid.Parse(GetUserId()));
                offers = await homeService.GetOffersAsyncByRegion(Guid.Parse(GetUserId()));
                if (user != null)
				{
                    ViewBag.InfoMessage = $"The most recent offers in {homeService.GetRegionAsync(user.RegionId).Result.Name}!";
                }
			}
            else
            {
	            ViewBag.InfoMessage = $"The most recent offers!";
	            offers = await homeService.GetOffersAsync();
            }
            return View(offers);
		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}