using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BestPrice.Models.ebay;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BestPrice.Controllers
{
    [Produces("application/json")]
    [Route("ebay")]
    public class ebayController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EbayItem> items = new List<EbayItem>();

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
                EbayItem eItem = new EbayItem(i);
                items.Add(eItem);
            }

            return View(items);
        }
        [Route("[action]/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            ViewBag.keyword = keyword;
            List<EbayItem> items = new List<EbayItem>();

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
  
            if (count > 0)
            {
                foreach (JToken i in jEbay["item"])
                {
                    EbayItem eItem = new EbayItem(i);
                    items.Add(eItem);
                }
            }
            return View(items);
        }

    }
}