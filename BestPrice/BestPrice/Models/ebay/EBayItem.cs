using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestPrice.Models.ebay
{
    public class EbayItem
    {
        public int Id { get; set; }
        public long ItemId { get; set; }
        public string Title { get; set; }
        public string subtitle { get; set; }
        public string GalleryURL { get; set; }
        public string ViewItemURL { get; set; }
        public string postalCode { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public float ShippingServiceCost { get; set; }
        public float CurrentPrice { get; set; }
        public string TimeLeft { get; set; }
        public int ConditionId { get; set; }
        public string ConditionDisplayName { get; set; }
        public int LaptopId { get; set; }

        //public virtual Laptop Laptop { get; set; }

        public EbayItem(JToken jToken)
        {
            //JToken jUser = jToken["item"][0];
            ItemId = (long)jToken["itemId"][0];
            if (jToken["title"] != null)
            {
                Title = (string)jToken["title"][0];
            }
            else
            {
                Title = "Unknown";
            }
            
            if(jToken["subtitle"] != null)
            {
                subtitle = (string)jToken["subtitle"][0];
            }
            else
            {
                subtitle = "Unknown";
            }
            if (jToken["galleryURL"] != null)
            {
                GalleryURL = (string)jToken["galleryURL"][0];
            }
            else
            {
                GalleryURL = "Unknown";
            }
            if (jToken["viewItemURL"] != null)
            {
                ViewItemURL = (string)jToken["viewItemURL"][0];
            }
            else
            {
                ViewItemURL = "Unknown";
            }

            /*
            if (jToken["postalCode"] != null)
            {
                postalCode = (string)jToken["postalCode"][0];
            }
            else
            {
                postalCode = "Unknown";
            }

            if (jToken["location"] != null)
            {
                Location = (string)jToken["location"][0];
            }
            else
            {
                Location = "Unknown";
            }
            if (jToken["country"] != null)
            {
                Country = (string)jToken["country"][0];
            }
            else
            {
                Country = "Unknown";
            }
            */
            //ShippingServiceCost = (float)jToken["shippingInfo"][0]["shippingServiceCost"][0]["__value__"];
            CurrentPrice = (int)((float)(jToken["sellingStatus"][0]["currentPrice"][0]["__value__"]));
            TimeLeft = (string)jToken["sellingStatus"][0]["timeLeft"][0];
            if (jToken["condition"] != null)
            {
                ConditionId = (int)jToken["condition"][0]["conditionId"][0];
                ConditionDisplayName = (string)jToken["condition"][0]["conditionDisplayName"][0];
            }
            else
            {
                ConditionId = 0;
                ConditionDisplayName = "Unknown";
            }
        }
    }
}
