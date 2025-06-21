using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using Store.Models.ViewModels;
using System.Diagnostics;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StoreContext _context;
        private General general = new General();
        private List<ProductTable> products = new List<ProductTable>();

        public HomeController(ILogger<HomeController> logger, StoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            products = _context.ProductTable.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            products = _context.ProductTable.Where(x => x.Name.Contains(search) || x.Category == search).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Cart(CartViewModel cartModel)
        {
            int getID = Convert.ToInt32(Request.Cookies["UserID"]);
            ViewBag.ID = getID;
            if (getID > 0)
            {
                cartModel = general.Model(_context, getID);
            }

            return View(cartModel);
        }

        [HttpPost]
        public IActionResult Cart(int productID, CartTable cart)
        {
            int getID = Convert.ToInt32(Request.Cookies["UserID"]);
            if (getID > 0)
            {
                general.AddToCart(_context, cart, productID, getID);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Product(int productID)
        {
            var getProduct = _context.ProductTable.FirstOrDefault(x => x.ProductID == productID);
            return View(getProduct);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
