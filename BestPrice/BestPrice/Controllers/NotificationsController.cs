using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BestPrice.Models;
using BestPrice.Services;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using BestPrice.Models.Notification;
using Newtonsoft.Json.Linq;

namespace BestPrice.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly prj666_192a03Context _context;
        private readonly IEmailSender _emailSender;

        public NotificationsController(prj666_192a03Context context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;

        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var prj666_192a03Context = _context.Notifications.Include(n => n.User);
            return View(await prj666_192a03Context.ToListAsync());
        }

        public async Task<IActionResult> SendEmailForNotifications()
        {
            await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Testing Hnagfire", "<img src='https://i.ibb.co/QQYMWZQ/logo.jpg' style='width:200px;height:150px' alt='TechPG logo' >" +
                   $"<h1>Thanks for joining TechPG!</h1> <br/>" +
                   $"Testinggggggggggggggg: helooooooooooooo");
            return Ok();
        }

        public async Task<IActionResult> CheckPriceforItemOne()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=273032356635";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 169)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 169" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }


        public async Task<IActionResult> CheckPriceforItemTwo()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=123732025135";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 364)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 364" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }

        public async Task<IActionResult> CheckPriceforItemThree()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=293104493960";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 1799)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 1799" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }

        public async Task<IActionResult> CheckPriceforItemFour()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=173703481402";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 399)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 399" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }



        public async Task<IActionResult> CheckPriceforItemFive()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=162528855123";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 189)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 189" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }




        public async Task<IActionResult> CheckPriceforItemSix()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=292993730163";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 299)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 299" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }




        public async Task<IActionResult> CheckPriceforItemSeven()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=123832160256";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 800)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 800" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }


        public async Task<IActionResult> CheckPriceforItemEight()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=153562128346";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 8)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 8" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }



        public async Task<IActionResult> CheckPriceforItemNine()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=273927661844";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 13)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 13" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }


        public async Task<IActionResult> CheckPriceforItemTen()
        {
            string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=302839163319";

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

            JsonTextReader reader = new JsonTextReader(new StringReader(ebayResponse));
            JObject ebayParser = JObject.Parse(ebayResponse);

            String check = ebayParser["Ack"].ToObject<String>();
            if (check == "Success")
            {
                JToken jEbay = ebayParser["Item"];
                {
                    Product eItem = new Product();
                    eItem.Title = (string)jEbay["Title"];
                    eItem.ItemId = (long)jEbay["ItemID"];
                    eItem.CurrentPrice = (int)((float)(jEbay["ConvertedCurrentPrice"]["Value"]));
                    eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                    if (eItem.CurrentPrice != 23)
                    {
                        await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                      $"<h1>Product</h1> <br/>" +
                      $"Title: " + eItem.Title + "<br/>" +
                      $"Price Before: 23" + "<br/>" +
                      $"Price Now: " + eItem.CurrentPrice + "<br/>" +
                      $"Link: " + eItem.ViewItemURL + "<br/>"
                      );
                    }
                }
            }
            else
            {
                await _emailSender.SendEmailByMailKitAsync2("jatinkumarg18@gmail.com", "TechPG - Product price change",
                  $"<h1>Boy its not working</h1> <br/>"

                  );
            }
            return Ok();

        }









        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _context.Notifications
                .Include(n => n.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (notifications == null)
            {
                return NotFound();
            }

            return View(notifications);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ProductName,Seller,BeforePrice,CurrentPrice,PriceStatus,LastModified,ProductDescription,ProductCondition,Link,Image")] Notifications notifications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notifications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", notifications.UserId);
            return View(notifications);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _context.Notifications.SingleOrDefaultAsync(m => m.Id == id);
            if (notifications == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", notifications.UserId);
            return View(notifications);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ProductName,Seller,BeforePrice,CurrentPrice,PriceStatus,LastModified,ProductDescription,ProductCondition,Link,Image")] Notifications notifications)
        {
            if (id != notifications.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notifications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationsExists(notifications.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", notifications.UserId);
            return View(notifications);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifications = await _context.Notifications
                .Include(n => n.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (notifications == null)
            {
                return NotFound();
            }

            return View(notifications);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notifications = await _context.Notifications.SingleOrDefaultAsync(m => m.Id == id);
            _context.Notifications.Remove(notifications);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationsExists(int id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }
    }
}
