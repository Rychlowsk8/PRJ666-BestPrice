using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class Wishlists
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string SellerName { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductCondition { get; set; }
        public short SoldOut { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
