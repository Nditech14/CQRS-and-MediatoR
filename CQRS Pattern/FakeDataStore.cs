namespace CQRS_Pattern.Product
{
    public class FakeDataStore
    {
        private static List<Product> _Products;//created a private list
        public FakeDataStore()
        {
            _Products = new List<Product>()//initialise products list
            {
                new Product { Id = 1, Name = "Test Product 1" },
                new Product { Id = 2, Name = "Test Product 2" },
                new Product { Id = 3, Name = "Test Product 3" }
            };
        }

        public async Task AddProduct(Product product)// a method that return Task take product as the parameter
        {
           _Products.Add(product);//use product list inside the method // since product return no values we will await task 
            await Task.CompletedTask;
        }

          public async Task<IEnumerable<Product>> GetAllProducts()=> await Task.FromResult(_Products);
    }
}
