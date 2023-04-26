using ContosoCrafts.Webapp.Models;
using System.Text.Json;

namespace ContosoCrafts.Webapp.Services
{
    public class ProductsService
    {
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public ProductsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IEnumerable<Product> GetProducts()
        {
            using (var jsonfilereader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonfilereader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
    }
}
