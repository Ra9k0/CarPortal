using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.AddOffer;
using Microsoft.EntityFrameworkCore;

namespace CarPortal.Services
{
	public class AddOfferService : IAddOfferService
	{
		private readonly CarPortalDbContext dbContext;

		public AddOfferService(CarPortalDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<MakeViewModel>> GetMakesByCategoryAsync(int categoryId)
		{
			return await dbContext.Makes.Where(make=>make.Models.Any(model=>model.CategoryId == categoryId)).Select(m => new MakeViewModel()
			{
				Id = m.Id,
				Name = m.Name
			}).ToListAsync();
		}


		public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await dbContext.Categories.Select(c => new Category()
			{
				Id = c.Id,
				Name = c.Name,
			}).ToListAsync();
		}
	}
}
