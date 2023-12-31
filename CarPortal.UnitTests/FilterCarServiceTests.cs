﻿using CarPortal.Data;
using CarPortal.Services;
using CarPortal.Web.ViewModels.FilterCar;
using CarPortal.Web.ViewModels.Offer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data.Models;
using CarPortal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarPortal.UnitTests
{
	public class FilterCarServiceTests
	{
		private DbContextOptions<CarPortalDbContext> dbOptions;
		private CarPortalDbContext dbContext;

		private IFilterCarService filterCarService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<CarPortalDbContext>()
				.UseInMemoryDatabase("CarPortalInMemory" + Guid.NewGuid().ToString())
				.Options;
			this.dbContext = new CarPortalDbContext(this.dbOptions);

			this.dbContext.Database.EnsureCreated();
			DatabaseSeeder.SeedDatabase(this.dbContext);

			this.filterCarService = new FilterCarService(this.dbContext);
		}


		[Test]
		public async Task FilteredOffers_ShouldReturnFilteredAndOrderedOffers()
		{
			// Arrange

			var filterCarViewModel = new FilterCarViewModel
			{
				Car = new FilterCarCarViewModel()
				{
					ConditionId = 1,
					ColorId = 1,
					EngineTypeId = 1,
					ManufactureYear = 2000,
					Model = new ModelViewModel()
					{
						Id = 1,
						Name = "Giulia Quadrifoglio",
						CategoryId = 1,
						MakeId = 2
					}
				},
				Price = 1,
				RegionId = 2,
			};

			// Act
			var result =await filterCarService.FilteredOffers(filterCarViewModel, "PriceAscending");

			// Assert
			Assert.NotNull(result);
			Assert.AreEqual(1, result.Count());
			Assert.LessOrEqual(1, result.First().Price);
		}
	}
}
