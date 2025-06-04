using Microsoft.AspNetCore.Identity;

namespace GiftShop.Models
{
    public class Customer:IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Item> items { get; set; }
    }
}
