using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string Seller { get; set; }
        public decimal BeforePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string PriceStatus { get; set; }
        public DateTime LastModified { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCondition { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
