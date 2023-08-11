using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        
        //Количество товаров на странице
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        
        public ViewResult List(string category, int productPage = 1) =>
            View(new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => p.Category == category || category == null)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                        repository.Products.Count() : 
                        repository.Products.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
