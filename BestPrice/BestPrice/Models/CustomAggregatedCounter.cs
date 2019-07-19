using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class CustomAggregatedCounter
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
