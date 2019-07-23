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
using Microsoft.AspNetCore.Identity;

namespace BestPrice.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly prj666_192a03Context _context;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotificationsController(prj666_192a03Context context, IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;

        }

        // GET: Notifications
        public async Task<IActionResult> Index(int? pageNumber)
        {           
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _userManager.GetUserAsync(User);
            var prj666_192a03Context = _context.Notifications.Include(n => n.User).Where(x => x.UserId == user.Id);
            List<Notifications> items = new List<Notifications>(await prj666_192a03Context.ToListAsync());

            int pageSize = 5;
            return View(PaginatedList<Notifications>.CreatePage(items.OrderByDescending(p => p.LastModified), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> ClearNotifications()
        {
            var user = await _userManager.GetUserAsync(User);
            var prj666_192a03Context = _context.Notifications.Include(n => n.User).Where(x => x.UserId == user.Id);
            List<Notifications> list = new List<Notifications>(await prj666_192a03Context.ToListAsync());

            _context.Notifications.RemoveRange(list);
             await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CheckPriceforAll()
        {
            List<Wishlists> wishlist = _context.Wishlists.ToList();

            if (wishlist.Count != 0)
            {
                foreach (var wish in wishlist)
                {
                    var user = _context.AspNetUsers.FirstOrDefault(u => u.Id == wish.UserId);
                    if (user.GetNotified == 1)
                    {
                        if (wish.SellerName == "eBay")
                        { 
                        string url = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=JSON&appid=JatinKum-TechPG-PRD-41ea39f9c-08819029&siteid=2&version=967&ItemID=" + wish.ProductId;

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
                                eItem.ItemId = (string)jEbay["ItemID"];
                                eItem.CurrentPrice = (float)(jEbay["ConvertedCurrentPrice"]["Value"]);
                                eItem.ViewItemURL = (string)jEbay["ViewItemURLForNaturalSearch"];

                                if (eItem.CurrentPrice != wish.Price)
                                {
                                    Notifications list = new Notifications();
                                    list.ProductName = wish.ProductName;
                                    list.Link = wish.Link;
                                    list.Image = wish.Image;
                                    list.Seller = wish.SellerName;
                                    list.BeforePrice = wish.Price;
                                    list.CurrentPrice = eItem.CurrentPrice;
                                    if (list.BeforePrice > list.CurrentPrice)
                                    {
                                        list.PriceStatus = "Decreased";
                                    }
                                    else
                                    {
                                        list.PriceStatus = "Increased";
                                    }
                                    list.LastModified = DateTime.Now;

                                    list.UserId = wish.UserId;

                                    await _emailSender.SendEmailByMailKitAsync2(user.Email, "TechPG - Product price change",
                                    $"<h1>Product</h1>: " + wish.ProductName + "<br/>" +
                                    $"<img src='" + wish.Image + "' style='width:200px;height:150px' alt='TechPG logo' >" + "<br/>" +
                                    $"Price Before: " + wish.Price + "<br/>" +
                                    $"Price Now: " + list.CurrentPrice + "<br/>" +
                                    $"Link: " + wish.Link + "<br/>"
                                    );

                                    //To update the wishlist price
                                    _context.Wishlists.Where(p => p.ProductId == wish.ProductId).ToList().ForEach(x => x.Price = list.CurrentPrice);

                                    _context.Add(list);
                                    await _context.SaveChangesAsync();

                                }
                            }
                         }
                      }
                     // ------------------------------------Amazon------------------------------------
                     /*
                        if (wish.SellerName == "Amazon")
                        {
                            string amazonUrl1 = "https://axesso-axesso-amazon-data-service-v1.p.rapidapi.com/amz/amazon-lookup-product?url=https%3A%2F%2Fwww.amazon.ca%2Fdp%2F";
                            string amazonUrl = amazonUrl1 + wish.ProductId;
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

                            JsonTextReader aReader = new JsonTextReader(new StringReader(amazonResponse));
                            JObject amazonParser = JObject.Parse(amazonResponse);
                            
                            JToken jAmazon = amazonParser;
                            {
                                Product aItem = new Product();
                                aItem.Title = (string)jAmazon["productTitle"];
                                aItem.ItemId = (string)jAmazon["asin"];
                                aItem.CurrentPrice = (float)jAmazon["price"];
                                aItem.ViewItemURL = "https://www.amazon.ca/dp/" + (string)jAmazon["asin"];

                                if (aItem.CurrentPrice != wish.Price)
                                    {
                                        Notifications list = new Notifications();
                                        list.ProductName = wish.ProductName;
                                        list.Link = wish.Link;
                                        list.Image = wish.Image;
                                        list.Seller = wish.SellerName;
                                        list.BeforePrice = wish.Price;
                                        list.CurrentPrice = aItem.CurrentPrice;
                                        if (list.BeforePrice > list.CurrentPrice)
                                        {
                                            list.PriceStatus = "Decreased";
                                        }
                                        else
                                        {
                                            list.PriceStatus = "Increased";
                                        }
                                        list.LastModified = DateTime.Now;

                                        list.UserId = wish.UserId;

                                        await _emailSender.SendEmailByMailKitAsync2(user.Email, "TechPG - Product price change",
                                        $"<h1>Product</h1>: " + wish.ProductName + "<br/>" +
                                        $"<img src='" + wish.Image + "' style='width:200px;height:150px' alt='TechPG logo' >" + "<br/>" +
                                        $"Price Before: " + wish.Price + "<br/>" +
                                        $"Price Now: " + list.CurrentPrice + "<br/>" +
                                        $"Link: " + wish.Link + "<br/>"
                                        );

                                        //To update the wishlist price
                                        _context.Wishlists.Where(p => p.ProductId == wish.ProductId).ToList().ForEach(x => x.Price = list.CurrentPrice);

                                        _context.Add(list);
                                        await _context.SaveChangesAsync();

                                    }
                                }
        
                        }
                        */
                        //-----------------------------------------------Amazon----------------------------------------------------------
                    }
                }
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
