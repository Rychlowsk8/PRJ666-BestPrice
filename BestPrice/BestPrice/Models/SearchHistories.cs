using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestPrice.Models
{
    public partial class SearchHistories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SellerName { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public float Price { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCondition { get; set; }
        public short SoldOut { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
