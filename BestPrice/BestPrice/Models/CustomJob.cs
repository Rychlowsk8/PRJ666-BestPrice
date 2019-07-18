using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class CustomJob
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public string InvocationData { get; set; }
        public string Arguments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
