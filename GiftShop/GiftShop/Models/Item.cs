using System.ComponentModel.DataAnnotations;

namespace GiftShop.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        public string ItemName { get; set; }
        public string CustomerId { get; set; }

        public string ImgUrl { get; set; }
        public string Price { get; set; }
        public Customer Customer { get; set; }
    }
}
