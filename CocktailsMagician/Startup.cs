using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using CocktailsMagician.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CocktailsMagician.Services.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using CocktailsMagician.Helpers;
using CocktailsMagician.Middlewares;

namespace CocktailsMagician
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<CMContext>(options =>
            options.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<CMContext>();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();


            services.AddScoped<ICocktailService, CocktailService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IIngredientTypeService, IngredientTypeService>();
            services.AddScoped<ICocktailReviewService, CocktailReviewService>();
            services.AddScoped<ICocktailReviewLikeService, CocktailReviewLikeService>();
            services.AddScoped<IBarService, BarService>();
            services.AddScoped<IBarReviewService, BarReviewService>();
            services.AddScoped<IBarReviewLikeService, BarReviewLikeService>();
       
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddMvc().AddNToastNotifyToastr();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseNToastNotify();

            app.UseMiddleware<NotFoundMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
