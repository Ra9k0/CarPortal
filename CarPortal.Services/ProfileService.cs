using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;
using static CarPortal.Common.EntityValidationConstants;

namespace CarPortal.Services
{
	public class ProfileService : IProfileService
	{
		private readonly CarPortalDbContext dbContext;

		public ProfileService(CarPortalDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<IEnumerable<OfferViewModel>> GetMyOffersAsync(string id)
		{
			return await dbContext.Offers.Where(of=>of.OwnerId.ToString() == id).Select(of => new OfferViewModel
			{
				Id = of.Id,
				CarId = of.CarId,
				Images = of.Images.First(),
				Price = of.Price,
				CreatedOn = of.CreatedOn,
				Description = of.Description,
				Title = of.Title,
				OwnerId = of.OwnerId,
				Car = of.Car,
				Owner = of.Owner
			}).OrderByDescending(of=>of.CreatedOn).ToListAsync();
		}

		public void Like(Guid offerId, string userId)
		{
			bool isLiked = dbContext.Likes.Any(l => l.OfferId == offerId && l.UserId == Guid.Parse(userId));
			if (!isLiked)
			{
				Like like = new Like()
				{
					OfferId = offerId,
					UserId = Guid.Parse(userId),
					LikeDate = DateTime.UtcNow
				};
				dbContext.Likes.Add(like);
				dbContext.SaveChanges();
			}
		}

		public async Task<IEnumerable<OfferViewModel>> GetLikedOffersAsync(string id)
		{
			return await dbContext.Likes.Where(l=>l.UserId.ToString() == id).OrderByDescending(x=>x.LikeDate).Select(of=>new OfferViewModel()
			{
				Id = of.Offer.Id,
				CarId = of.Offer.CarId,
				Images = of.Offer.Images.First(),
				Price = of.Offer.Price,
				CreatedOn = of.Offer.CreatedOn,
				Description = of.Offer.Description,
				Title = of.Offer.Title,
				OwnerId = of.Offer.OwnerId,
				Car = of.Offer.Car,
				Owner = of.Offer.Owner
			}).ToListAsync();
		}
	}
}
