using CarPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarPortal.Web.Controllers
{
	public class ProfileController : BaseController
	{
		private readonly IProfileService profileService;

		public ProfileController(IProfileService profileService)
		{
			this.profileService = profileService;
		}
		public async Task<IActionResult> MyOffers()
		{
			ViewBag.MyOffers = await profileService.GetMyOffersAsync(GetUserId());
			return View();
		}

		[HttpPost]
		public IActionResult Like(Guid id,string returnUrl)
		{
			profileService.Like(id,GetUserId());
			if (!string.IsNullOrEmpty(returnUrl))
			{
				return Redirect(returnUrl);
			}
			
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Dislike(Guid id)
		{
			profileService.Dislike(id, GetUserId());

			return RedirectToAction("LikedOffers");
		}

		public async Task<IActionResult> LikedOffers()
		{
			ViewBag.LikedOffers = await profileService.GetLikedOffersAsync(GetUserId());
			return View();
		}
	}
}
