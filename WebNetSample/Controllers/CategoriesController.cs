using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebNetSample.Contexts;
using WebNetSample.Models.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebNetSample.Controllers
{
    public class CategoriesController : Controller
    {
        private BaseDbContext _context { get; }

        public CategoriesController(BaseDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Category> categories = (from category in _context.Categories.Take(10)
                                         select category).ToList();

            return View(categories);
        }
    }
}

