﻿using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class CustomServer
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public DateTime? LastHeartbeat { get; set; }
    }
}
