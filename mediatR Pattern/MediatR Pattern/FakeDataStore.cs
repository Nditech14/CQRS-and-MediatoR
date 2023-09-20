using MediatR_Pattern.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_Pattern
{
    public class FakeDataStore
    {
        private static List<Product> _Products;

        public FakeDataStore()
        {
            _Products = new List<Product>()
            {
                new Product { Id = 1, Name = "condom" },
                new Product { Id = 2, Name = "Lubricant" },
                new Product { Id = 3, Name = "Vibrator" }
            };
        }

        public async Task AddProduct(Product product)
        {
            _Products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_Products);

        public async Task<Product> GetProductById(int id) => await Task.FromResult(_Products.SingleOrDefault(p => p.Id == id));

        public async Task EventOccurred(Product product, string evt)
        {
            // Fix the typo and update the product's name
            _Products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
