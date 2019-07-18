using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class HangfireJobParameter
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
