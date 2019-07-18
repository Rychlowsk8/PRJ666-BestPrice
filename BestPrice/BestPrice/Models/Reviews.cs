using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }
        public string ProductName { get; set; }
        public string SellerName { get; set; }
    }
}
