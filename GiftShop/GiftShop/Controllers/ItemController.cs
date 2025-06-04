using GiftShop.Data;
using GiftShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _userManager;

        public ItemController(ApplicationDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Select()
        {
            var Items = new List<Item>
            {
                new Item{ ItemName="Gift Card",ImgUrl="/images/Gift Card.jpg",Price="₹200"},
                new Item{ ItemName="Chocolate Cake",ImgUrl="/images/Chocolate Cake.jpg",Price="₹400"},
                new Item{ ItemName="Ferrero Rocher",ImgUrl="/images/Ferero Rocher.jpg",Price="₹300"},
                new Item{ ItemName="Roses",ImgUrl="/images/Roses.jpg",Price="₹250"},

            };
            return View(Items);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string itemName, string imgUrl, string price)
        {
            var user = await _userManager.GetUserAsync(User);

            var item = new Item
            {
                ItemName = itemName,
                ImgUrl = imgUrl,
                Price = price,
                CustomerId = user.Id
            };

            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Select");
        }

    }
}
