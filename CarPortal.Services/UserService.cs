using CarPortal.Data;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace CarPortal.Services
{
    public class UserService : IUserService
    {
        private readonly CarPortalDbContext dbContext;

        public UserService(CarPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<RegionViewModel>> GetRegionsAsync()
        {
            var regions = await dbContext.Regions.Select(r => new RegionViewModel()
            {
                Id = r.Id,
                Name = r.Name,
            }).ToListAsync();

            return regions;
        }
    }
}
