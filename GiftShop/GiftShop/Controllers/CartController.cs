
using GiftShop.Data;
using GiftShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _userManager;

        public CartController(ApplicationDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItems = await _context.Item
                .Where(i => i.CustomerId == user.Id)
                .ToListAsync();
            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int itemId)
        {
            var user = await _userManager.GetUserAsync(User);

            var item = await _context.Item
                .Where(i => i.ItemID == itemId && i.CustomerId == user.Id)
                .FirstOrDefaultAsync();
            if (item != null)
            {
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
