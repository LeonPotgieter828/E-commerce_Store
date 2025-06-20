using Microsoft.AspNetCore.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category(string category)
        {
           var getCategories = _context.ProductTable.Where(x => x.Category == category).ToList();
            return View(getCategories);
        }
    }
}
