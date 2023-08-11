namespace SportsStore.Models
{
    public class FakeProductRepository /*: IProductRepository*/
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "SUP", Price = 39999M },
            new Product { Name = "Велосипед горный", Price = 26999M },
            new Product { Name = "Мяч волейбольный", Price = 699M },
        }.AsQueryable<Product>();
    }
}
