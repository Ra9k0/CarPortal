using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services;
using CarPortal.Services.Interfaces;
using CarPortal.Web.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CarPortal.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddAuthentication().AddGoogle(googleOptions =>
            {
	            googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
	            googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
            });

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<CarPortalDbContext>(options =>
                options.UseSqlServer(connectionString),ServiceLifetime.Scoped);
           
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
	            .AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<CarPortalDbContext>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped<IFilterCarService, FilterCarService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IOfferService, OfferService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.EnableOnlineUsersCheck();

            app.UseEndpoints(config =>
			{
				config.MapControllerRoute(
					name: "areas",
					pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);

				config.MapControllerRoute(
					name: "ProtectingUrlRoute",
					pattern: "/{controller}/{action}/{id}/{information}",
					defaults: new { Controller = "Home", Action = "Index" });

				config.MapDefaultControllerRoute();

				config.MapRazorPages();
			});

			using (var scope = app.Services.CreateScope())
            {
	            var roleManager =
		            scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

	            var roles = new[] { "Admin", "User" };

	            foreach (var role in roles)
	            {
		            if (!await roleManager.RoleExistsAsync(role))
		            {
			            await roleManager.CreateAsync(new IdentityRole<Guid>(role));
		            }
	            }
            }

            using (var scope = app.Services.CreateScope())
            {
	            var userManager =
		            scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

	            const string firstName = "Admin";
	            const string lastName = "Adminov";
	            const string email = "admin@admin.com";
	            const string password = "Admin1337!";
	            const int regionId = 21;

                if (await userManager.FindByEmailAsync(email) == null)
                {
	                var user = new ApplicationUser();
                    user.UserName = email;
                    user.Email = email;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.RegionId = regionId;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

			app.Run();
        }
    }
}