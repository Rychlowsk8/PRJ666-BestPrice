using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class Products
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? AverageRating { get; set; }
    }
}
