using Microsoft.AspNetCore.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class UserController : Controller
    {
        private readonly StoreContext _context;

        public UserController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index(string username, string password)
        {
            var getUser = _context.UserTable.FirstOrDefault(x => x.Username == username);
            if (getUser != null && getUser.Password == password)
            {
                var cookie = new CookieOptions
                {
                    Secure = true,
                };
                Response.Cookies.Append("UserID", getUser.UserID.ToString(), cookie);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserTable user, string confirmPassword)
        {
            if (user.Password.Equals(confirmPassword))
            {
                _context.UserTable.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
