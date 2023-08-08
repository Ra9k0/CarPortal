using CarPortal.Data;
using CarPortal.Services.Interfaces;
using CarPortal.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data.Models;
using Moq;

namespace CarPortal.UnitTests
{
	public class HomeServiceTests
	{
		private DbContextOptions<CarPortalDbContext> dbOptions;
		private CarPortalDbContext dbContext;

		private IHomeService offerService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<CarPortalDbContext>()
				.UseInMemoryDatabase("CarPortalInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new CarPortalDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();
			DatabaseSeeder.SeedDatabase(this.dbContext);

			this.offerService = new HomeService(this.dbContext);
		}

		[Test]
		public async Task GetOffersAsyncByRegion_ShouldReturnOffersForUserRegion()
		{
			var userId = Guid.Parse("aae803d7-217e-4f51-a676-51d631e8a643");
			var regionId = 2;

			// Act
			var result = await offerService.GetOffersAsyncByRegion(userId);

			// Assert
			Assert.NotNull(result);
			Assert.AreEqual(3, result.Count());
			Assert.AreEqual(userId, result.First().OwnerId);
			Assert.AreEqual(regionId, result.First().Owner.RegionId);
		}
	}
}
