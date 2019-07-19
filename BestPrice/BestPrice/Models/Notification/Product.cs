using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace BestPrice.Models.Notification
{
    public class Product
    {
        public int Id { get; set; }
        public long ItemId { get; set; }
        public string Title { get; set; }
        public float CurrentPrice { get; set; }
        public string ViewItemURL { get; set; }

    }
}
