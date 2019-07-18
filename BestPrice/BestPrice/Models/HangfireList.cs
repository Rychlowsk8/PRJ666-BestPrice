using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class HangfireList
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
