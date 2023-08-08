using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Offer;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarPortal.UnitTests
{
	public class OfferServiceTests
	{
		private DbContextOptions<CarPortalDbContext> dbOptions;
		private CarPortalDbContext dbContext;

		private IOfferService offerService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<CarPortalDbContext>()
				.UseInMemoryDatabase("CarPortalInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new CarPortalDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();
			DatabaseSeeder.SeedDatabase(this.dbContext);

			this.offerService = new OfferService(this.dbContext);
		}

		[Test]
		public async Task GetOfferByIdAsync_ShouldReturnOfferDetailsViewModel()
		{
			// Arrange
			var offerId = Guid.Parse("dc82d5e5-7c8d-4536-adc9-47536525bc87");

			// Act
			var result = await offerService.GetOfferByIdAsync(offerId.ToString());

			// Assert
			Assert.NotNull(result);
			Assert.AreEqual(offerId, result.Id);
		}
		[Test]
		public async Task EditOfferAsync_ShouldEditOffer()
		{
			// Arrange
			var offerId = Guid.Parse("8c2b627e-c0ad-4287-ad1c-63a7fc3b5726");
			var updatedTitle = "Updated Title";
			var updatedDescription = "Updated Description";
			var updatedPrice = 25000.00m;
			var updatedEngineTypeId = 2;
			var updatedConditionId = 2;
			var updatedColorId = 2;
			var updatedModelId = 2;
			var updatedManufactureYear = 2022;

			var offerForEdit = new Offer
			{
				Id = offerId,
				Title = "Old Title",
				Description = "Old Description",
				Price = 20000.00m,
				Car = new Car
				{
					EngineTypeId = 1,
					ConditionId = 1,
					ColorId = 1,
					ModelId = 1,
					ManufactureYear = 2021
				}
			};

			dbContext.Offers.Add(offerForEdit);
			await dbContext.SaveChangesAsync();

			var updatedOffer = new OfferEditViewModel
			{
				Id = offerId,
				Title = updatedTitle,
				Description = updatedDescription,
				Price = updatedPrice,
				Car = new CarViewModel
				{
					EngineTypeId = updatedEngineTypeId,
					ConditionId = updatedConditionId,
					ColorId = updatedColorId,
					ModelId = updatedModelId,
					ManufactureYear = updatedManufactureYear
				}
			};

			// Act
			await offerService.EditOfferAsync(updatedOffer);
			var editedOffer = await dbContext.Offers.FindAsync(offerId);

			// Assert
			Assert.NotNull(editedOffer);
			Assert.AreEqual(updatedTitle, editedOffer.Title);
			Assert.AreEqual(updatedDescription, editedOffer.Description);
			Assert.AreEqual(updatedPrice, editedOffer.Price);
			Assert.AreEqual(updatedEngineTypeId, editedOffer.Car.EngineTypeId);
			Assert.AreEqual(updatedConditionId, editedOffer.Car.ConditionId);
			Assert.AreEqual(updatedColorId, editedOffer.Car.ColorId);
			Assert.AreEqual(updatedModelId, editedOffer.Car.ModelId);
			Assert.AreEqual(updatedManufactureYear, editedOffer.Car.ManufactureYear);
		}

		[Test]
		public void CreateOffer_ShouldAddOfferAndCar()
		{
			// Arrange
			var offer = new AddOfferViewModel
			{
				Title = "Test Offer",
				Description = "Test Description",
				Price = 20000,
				Car = new CarViewModel
				{
					ColorId = 1,
					ConditionId = 1,
					EngineTypeId = 1,
					ManufactureYear = 2023,
					ModelId = 1
				}
			};
			var userId = Guid.NewGuid();

			// Act
			Assert.DoesNotThrow(() => offerService.CreateOffer(offer, userId));

			// Assert
			var addedOffer = dbContext.Offers.FirstOrDefault(o => o.Title == offer.Title);
			var addedCar = dbContext.Cars.FirstOrDefault(c =>
				c.ColorId == offer.Car.ColorId &&
				c.ConditionId == offer.Car.ConditionId &&
				c.EngineTypeId == offer.Car.EngineTypeId &&
				c.ManufactureYear == offer.Car.ManufactureYear &&
				c.ModelId == offer.Car.ModelId);

			Assert.NotNull(addedOffer);
			Assert.NotNull(addedCar);
			Assert.AreEqual(offer.Title, addedOffer.Title);
		}
	}
}