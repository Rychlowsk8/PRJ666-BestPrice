using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class CustomState
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Data { get; set; }
    }
}
