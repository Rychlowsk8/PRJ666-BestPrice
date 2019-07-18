﻿using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class CustomJobQueue
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Queue { get; set; }
        public DateTime? FetchedAt { get; set; }
        public string FetchToken { get; set; }
    }
}
