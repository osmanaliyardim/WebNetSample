using Microsoft.AspNetCore.Mvc;
using WebNetSample.Contexts;
using WebNetSample.Models.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebNetSample.Controllers
{
    public class ProductsController : Controller
    {
        private BaseDbContext _context { get; }

        public ProductsController(BaseDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = (from product in _context.Products
                                      join category in _context.Categories on product.CategoryId equals category.Id 
                                      join supplier in _context.Suppliers on product.SupplierId equals supplier.Id
                                         select new {
                                            Id = product.Id,
                                            Name = product.Name,
                                            Price = product.Price,
                                            ImageUrl = product.ImageUrl,
                                            CategoryName = category.Name,
                                            SupplierName = supplier.Name
                                         }).Take(10).ToList();

            List<ProductDto> productList = new List<ProductDto>();

            for (int i = 0; i < products.Count; i++)
            {
                ProductDto product = new ProductDto
                {
                    Id = products[i].Id,
                    Name = products[i].Name,
                    Price = products[i].Price,
                    ImageUrl = products[i].ImageUrl,
                    CategoryName = products[i].CategoryName,
                    SupplierName = products[i].SupplierName
                };

                productList.Add(product);
            }

            return View(productList);
        }
    }
}

