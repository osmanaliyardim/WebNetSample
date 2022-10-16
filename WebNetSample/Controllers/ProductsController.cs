using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebNetSample.Entity.Dtos;

namespace WebNetSample.WebNetMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public ProductsController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService; 
        }

        public IActionResult Index()
        {
            //var products = _productService.GetList();

            //var productsWithCategoriesAndSuppliers = (from product in _productService.GetList()
            //                join category in _categoryService.GetList() on product.CategoryId equals category.Id
            //                join supplier in _supplierService.GetList() on product.SupplierId equals supplier.Id
            //                select new
            //                {
            //                    Id = product.Id,
            //                    Name = product.Name,
            //                    Price = product.Price,
            //                    ImageUrl = product.ImageUrl,
            //                    CategoryName = category.Name,
            //                    SupplierName = supplier.Name
            //                }).Take(10).ToList();

            //List<ProductDetailDto> resultList = new List<ProductDetailDto>();

            //for (int i = 0; i < productsWithCategoriesAndSuppliers.Count; i++)
            //{
            //    ProductDetailDto product = new ProductDetailDto
            //    {
            //        Id = productsWithCategoriesAndSuppliers[i].Id,
            //        Name = productsWithCategoriesAndSuppliers[i].Name,
            //        Price = productsWithCategoriesAndSuppliers[i].Price,
            //        ImageUrl = productsWithCategoriesAndSuppliers[i].ImageUrl,
            //        CategoryName = productsWithCategoriesAndSuppliers[i].CategoryName,
            //        SupplierName = productsWithCategoriesAndSuppliers[i].SupplierName
            //    };

            //    resultList.Add(product);
            //}

            List<ProductDetailDto> productsWithDetails = _productService.GetProductDetails();

            return View(productsWithDetails);
        }
    }
}

