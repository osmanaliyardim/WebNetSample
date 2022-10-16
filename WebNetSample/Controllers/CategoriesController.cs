using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.WebNetMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //List<Category> categories = (from category in _context.Categories.Take(10)
            //select category).ToList();

            List<Category> categories = (from category in _categoryService.GetList().Take(10)
                                         select category).ToList();

            return View(categories);
        }
    }
}