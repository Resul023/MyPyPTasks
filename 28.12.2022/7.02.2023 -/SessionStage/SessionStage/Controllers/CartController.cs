using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionStage.DATA;
using SessionStage.Models;
using SessionStage.SessionService;

namespace SessionStage.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private const string CART_KEY = "_cart";
        public CartController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return BadRequest();

            var carts = HttpContext.Session.Get<List<Cart>>(CART_KEY) ?? new List<Cart>();

            var existingCart = carts.FirstOrDefault(x => x.Id == id);
            if (existingCart == null)
            {
                var cart = new Cart
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.UnitPrice
                };
                carts.Add(cart);
            }
            else
                existingCart.Count++;
            HttpContext.Session.Set<List<Cart>>(CART_KEY, carts);
            return Content("");
        }

        [HttpGet]
        public async Task<IActionResult> ShowSession()
        {
            var carts = HttpContext.Session.Get<List<Cart>>(CART_KEY) ?? new List<Cart>();
            return Json(data: carts);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carts = HttpContext.Session.Get<List<Cart>>(CART_KEY);
            if (carts == null)
                return BadRequest();

            var card = carts.FirstOrDefault(x => x.Id == id);
            if (card !=null)
                carts.Remove(card);

            HttpContext.Session.Set<List<Cart>>(CART_KEY, carts);
            return Json("");
        }
    }
}
