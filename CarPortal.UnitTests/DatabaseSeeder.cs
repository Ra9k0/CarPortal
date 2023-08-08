using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Web.ViewModels.Offer;
using NUnit.Framework.Internal.Execution;

namespace CarPortal.UnitTests
{
	public static class DatabaseSeeder
	{
		public static Offer Offer;
		public static void SeedDatabase(CarPortalDbContext dbContext)
		{
			var regionId = 2;
			var userId = Guid.Parse("aae803d7-217e-4f51-a676-51d631e8a643");

			ApplicationUser user = new ApplicationUser()
			{
				FirstName = "Test",
				LastName = "Testov",
				Id = userId,
				RegionId = regionId
			};
			dbContext.Users.Add(user);
			dbContext.SaveChanges();

			Offer = new Offer()
			{
				Id = Guid.Parse("dc82d5e5-7c8d-4536-adc9-47536525bc87"),
				Car = new Car()
				{
					ColorId = 1,
					ConditionId = 1,
					EngineTypeId = 1,
					ManufactureYear = 2000,
					ModelId = 1
				},
				Price = 1,
				Description = "Experience the epitome of automotive innovation with our brand new car. With its captivating design, advanced technology, " +
				              "and unparalleled performance, this vehicle sets new standards in the world of automobiles. Get ready to embark on a thrilling " +
				              "journey like never before.",
				OwnerId = Guid.Parse("aae803d7-217e-4f51-a676-51d631e8a643"),
				Title = "Test1",
			};

			var offerData = new List<Offer>
			{
				new Offer
				{
					Id = Guid.NewGuid(),
					CarId = 1,
					Price = 20000,
					Description = "Offer Description",
					OwnerId = userId,
					CreatedOn = DateTime.UtcNow,
					Title = "Offer 1 Title",
					Images = new List<Image>()
					{
						new Image()
						{
							PhotoPath = "/OfferImage/test1.jpeg"
						}
					},
					Car = new Car(),
					Owner = user
				},
				new Offer
				{
					Id = Guid.NewGuid(),
					CarId = 2,
					Price = 25000,
					Description = "Offer Description",
					OwnerId =userId,
					CreatedOn = DateTime.UtcNow,
					Title = "Offer 2 Title",
					Car = new Car(),
					Owner = user,
					Images = new List<Image>()
					{
					new Image()
					{
					PhotoPath = "/OfferImage/test1.jpeg"
				}
			},
				},
				new Offer
				{
					Id = Guid.NewGuid(),
					CarId = 2,
					Price = 25000,
					Description = "Offer Description",
					OwnerId = userId,
					CreatedOn = DateTime.UtcNow,
					Title = "Offer 3 Title",
					Car = new Car(),
					Owner = user,
					Images = new List<Image>()
					{
						new Image()
						{
							PhotoPath = "/OfferImage/test1.jpeg"
						}
					},
				},
			};
			dbContext.AddRange(offerData);
			dbContext.Offers.Add(Offer);
			dbContext.SaveChanges();
		}
	}
}
