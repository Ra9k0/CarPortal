using CarPortal.Data;
using CarPortal.Data.Models;
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

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
	        return await dbContext.Users.Select(u => new ApplicationUser()
	        {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Region = u.Region,
                PhoneNumber = u.PhoneNumber,
	        }).ToListAsync();
        }
    }
}
