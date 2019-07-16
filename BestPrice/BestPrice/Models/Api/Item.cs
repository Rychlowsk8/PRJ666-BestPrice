using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestPrice.Models.Api
{
    public class Item
    {
        public int Id { get; set; }
        public long ItemId { get; set; }
        public string Title { get; set; }
        public string subtitle { get; set; }
        public string GalleryURL { get; set; }
        public string ViewItemURL { get; set; }
        public float CurrentPrice { get; set; }
        public int ConditionId { get; set; }
        public string ConditionDisplayName { get; set; }
        public string soldBy { get; set; }
    }
}
