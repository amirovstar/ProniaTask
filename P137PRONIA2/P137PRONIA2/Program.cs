using Microsoft.EntityFrameworkCore;
using P137PRONIA2.DataAccess.P137Pronia.DataAccess;
using P137PRONIA2.ExtensionServices.Implements;
using P137PRONIA2.ExtensionServices.Interfaces;
using P137PRONIA2.Services.Implements;
using P137PRONIA2.Services.Interfaces;

namespace P137PRONIA2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ISliderService, SliderService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddDbContext<ProniaDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration["ConnectionStrings:MSSQL"]);
                //opt.UseNpgsql();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Slider}/{action=Index}/{id?}"
                );
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
    

            app.Run();
        }
    }
}