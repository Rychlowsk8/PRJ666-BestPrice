using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BestPrice.Models;
using BestPrice.Models.Api;
using BestPrice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BestPrice.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly prj666_192a03Context _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApiController(
          UserManager<ApplicationUser> userManager,
          prj666_192a03Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Item> items = new List<Item>();

            string url = "https://svcs.ebay.com/services/search/FindingService/v1?SECURITY-APPNAME=JatinKum-TechPG-PRD-41ea39f9c-08819029&OPERATION-NAME=findItemsByKeywords&SERVICE-VERSION=1.0.0&RESPONSE-DATA-FORMAT=JSON&callback=_cb_findItemsByKeywords&REST-PAYLOAD&keywords=laptop&paginationInput.entriesPerPage=6&GLOBAL-ID=EBAY-ENCA&siteid=2";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // Set credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            string ebayResponse = readStream.ReadToEnd();
            response.Close();
            readStream.Close();

            // Malformed json String --> replace unfitting parts
            ebayResponse = ebayResponse.Replace("/**/_cb_findItemsByKeywords(", "");
            ebayResponse = ebayResponse.Remove(ebayResponse.Length - 1, 1);

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);
            JToken jEbay = ebayParser.First.First.First["searchResult"][0];
            foreach (JToken i in jEbay["item"])
            {
                Item eItem = new Item();
                items.Add(eItem);
            }

            return View(items);
        }
        [Route("[action]/{keyword}")]
        public async Task<IActionResult> Search(string keyword, int? pageNumber)
        {
            if (User.Identity.IsAuthenticated)
            {
                SearchHistories entry = new SearchHistories();
                entry.Name = keyword;
                entry.Date = DateTime.Now;
                var user = await _userManager.GetUserAsync(User);
                entry.UserId = user.Id;
                _context.SearchHistories.Add(entry);
                await _context.SaveChangesAsync();
            }

            ViewBag.keyword = keyword;

            List<Item> items = new List<Item>();

            /*
             * eBay API Details
             * 
             **/
            string url1 = "https://svcs.ebay.com/services/search/FindingService/v1?SECURITY-APPNAME=JatinKum-TechPG-PRD-41ea39f9c-08819029&OPERATION-NAME=findItemsByKeywords&SERVICE-VERSION=1.0.0&RESPONSE-DATA-FORMAT=JSON&callback=_cb_findItemsByKeywords&REST-PAYLOAD&keywords=";
            string keywordz = keyword;
            string url2 = "&GLOBAL-ID=EBAY-ENCA&siteid=2";
            string url = url1 + keyword + url2;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // Set credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            string ebayResponse = readStream.ReadToEnd();
            response.Close();
            readStream.Close();

            // Malformed json String --> replace unfitting parts
            ebayResponse = ebayResponse.Replace("/**/_cb_findItemsByKeywords(", "");
            ebayResponse = ebayResponse.Remove(ebayResponse.Length - 1, 1);           

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);
            JToken jEbay = ebayParser.First.First.First["searchResult"][0];
            int count = jEbay["@count"].ToObject<int>();

            // Amazon API test string (USE WHEN TESTING, API CALLS ARE LIMITED)
            string amazonResponse = "{\"responseStatus\":\"PRODUCT_FOUND_RESPONSE\",\"responseMessage\":\"Product successfully found!\",\"sortStrategy\":\"relevanceblender\",\"domainCode\":\"ca\",\"keyword\":\"laptop\",\"numberOfProducts\":10,\"resultCount\":14,\"foundProducts\":[\"B07Q147J19\",\"B07D8FVX22\",\"B079G38PT5\",\"B071F49Q2P\",\"B07CXY95LG\",\"B07NV1WJ3P\",\"B07G65DGXS\",\"B07D1WBPYG\",\"B07KDQW7Q1\",\"B0795W86N3\"],\"foundProductDetails\":[{\"responseStatus\":\"PRODUCT_FOUND_RESPONSE\",\"responseMessage\":\"Product successfully found!\",\"productTitle\":\"HP Elitebook 840 G1,Core i5,8GB RAM,320GB,Win 10 Pro(Renewed)\",\"manufacturer\":\"Amazon Renewed\",\"countReview\":96,\"answeredQuestions\":122,\"productRating\":\"3.8 out of 5 stars\",\"asin\":\"B079G38PT5\",\"sizeSelection\":[],\"soldBy\":\"Mega PC Mall\",\"fulfilledBy\":\"Amazon\",\"warehouseAvailability\":\"In Stock.\",\"retailPrice\":0.0,\"price\":329.0,\"priceShippingInformation\":\"FREE Shipping\",\"priceSaving\":null,\"features\":[\"14 LED - Backlit anti - glare Display\",\"Intel Core i5 4th Gen, 8 GB DDR3 RAM, 320 GB HDD\",\"90 Day Parts and Labour Hardware Warranty\",\"Windows 10 Pro\"],\"imageUrlList\":[\"https://images-na.ssl-images-amazon.com/images/I/41AbzoLyUQL.jpg\",\"https://images-na.ssl-images-amazon.com/images/I/71ZJQUc13gL._SL1500_.jpg\",\"https://images-na.ssl-images-amazon.com/images/I/31DnFQCYqJL.jpg\",\"https://images-na.ssl-images-amazon.com/images/I/51XLSSu3V%2BL._SL1024_.jpg\",\"https://images-na.ssl-images-amazon.com/images/I/41ODKIrhDSL.jpg\"],\"productDescription\":\"With its sleek and lighter design the HP Elitebook 840 G1 offers you utmost portability while at the work place or on the go . As thin as .83 inches and weighing only 3.48 lb (1.58 kg), you will be confident knowing you can carry less and do more. The HP Elitebook 840 G1 equipped with faster 4th Gen Intel Core i5 along with 8GB RAM offers you faster processing and effortless multi-tasking.\",\"productDetails\":[{\"name\":\"Display Size\",\"value\":\"14 inches\"},{\"name\":\"Processor\",\"value\":\"2 GHz Intel Core i5\"},{\"name\":\"RAM\",\"value\":\"8 GB\"},{\"name\":\"Hard Drive\",\"value\":\"320 GB HDD\"},{\"name\":\"Graphics Coprocessor\",\"value\":\"intel hd graphics 4400\"},{\"name\":\"Chipset Brand\",\"value\":\"intel\"},{\"name\":\"Brand Name\",\"value\":\"HP\"},{\"name\":\"Item model number\",\"value\":\"HP Elitebook 840 G1\"},{\"name\":\"Hardware Platform\",\"value\":\"PC\"},{\"name\":\"Operating System\",\"value\":\"Windows 10\"},{\"name\":\"Item dimensions L x W x H\",\"value\":\"23.7 x 33.9 x 2.1 cm\"},{\"name\":\"Color\",\"value\":\"Gray/Black\"},{\"name\":\"Processor Brand\",\"value\":\"Intel\"},{\"name\":\"Processor Count\",\"value\":\"2\"},{\"name\":\"Memory Type\",\"value\":\"DDR3 SDRAM\"},{\"name\":\"Hard Disk Interface\",\"value\":\"Serial ATA\"},{\"name\":\"Batteries:\",\"value\":\"1 Lithium ion batteries required. (included)\"},{\"name\":\"ASIN\",\"value\":\"B079G38PT5\"},{\"name\":\"Customer Reviews\",\"value\":\"3.8 out of 5 stars 96 customer reviews\"},{\"name\":\"Amazon Bestsellers Rank\",\"value\":\"#1,928 in Electronics (See Top 100 in Electronics) #14 in Laptop Computers\"},{\"name\":\"Shipping Weight\",\"value\":\"2.9 Kg (View shipping rates and policies)\"},{\"name\":\"Date First Available\",\"value\":\"Jan. 30 2018\"}],\"addon\":false,\"pantry\":false,\"prime\":false}]}";

            // ** to test, comment out from here to the next comment (uncomment string above as well)
            /*
            string amazonUrl1 = "https://axesso-axesso-amazon-data-service-v1.p.rapidapi.com/amz/amazon-search-by-keyword?sortBy=relevanceblender&domainCode=ca&page=1&keyword=";
            string amazonUrl = amazonUrl1 + keywordz;
            HttpWebRequest ARequest = (HttpWebRequest)WebRequest.Create(amazonUrl);
            ARequest.Credentials = CredentialCache.DefaultCredentials;
            ARequest.Headers["X-RapidAPI-Host"] = "axesso-axesso-amazon-data-service-v1.p.rapidapi.com";
            ARequest.Headers["X-RapidAPI-Key"] = "823b61990amsh1d2994b66a6151cp14a23cjsn2ad2c946e5f7";
            HttpWebResponse AResponse = (HttpWebResponse)ARequest.GetResponse();
            Stream AReceiveStream = AResponse.GetResponseStream();
            StreamReader AReadStream = new StreamReader(AReceiveStream, System.Text.Encoding.UTF8);
            string amazonResponse = AReadStream.ReadToEnd();
            AResponse.Close();
            AReadStream.Close();
            */
            // **comment to here

            JsonTextReader aReader = new JsonTextReader(new StringReader(amazonResponse));
            JObject amazonParser = JObject.Parse(amazonResponse);
            JToken jAmazon = amazonParser;          

            if (count > 0)
            {
                foreach (JToken i in jEbay["item"])
                {
                    Item eItem = new Item();
                    eItem.Title = (string)i["title"][0];
                    eItem.ItemId = (long)i["itemId"][0];
                    eItem.GalleryURL = (string)i["galleryURL"][0];
                    eItem.CurrentPrice = (int)((float)(i["sellingStatus"][0]["currentPrice"][0]["__value__"]));
                    eItem.subtitle = "Condition: " + (string)i["condition"][0]["conditionDisplayName"][0];
                    eItem.ViewItemURL = (string)i["viewItemURL"][0];
                    eItem.soldBy = "eBay";
                    items.Add(eItem);
                }
            }

            foreach (JToken i in jAmazon["foundProductDetails"])
            {
                Item aItem = new Item();
                aItem.Title = (string)i["productTitle"];
                aItem.GalleryURL = (string)i["imageUrlList"][0];
                aItem.CurrentPrice = (float)i["price"];
                aItem.subtitle = (string)i["productDescription"];
                aItem.ViewItemURL = "https://www.amazon.ca/dp/" + (string)i["asin"];
                aItem.soldBy = "Amazon";
                items.Add(aItem);
            }

            int pageSize = 20;
            
            return View(PaginatedList<Item>.CreatePage(items.OrderBy(p => p.CurrentPrice), pageNumber ?? 1, pageSize));
        }

    }
}