using ContosoCrafts.Webapp.Models;
using ContosoCrafts.Webapp.Services;
using System.Linq;
using System.Text.Json;

namespace ContosoCrafts.Webapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<ProductsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapGet("/products",context =>
            {
                var products = builder.Services.BuildServiceProvider().GetService<ProductsService>().GetProducts();
                var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
                return context.Response.WriteAsync(json);
            });

            app.Run();
        }
    }
}