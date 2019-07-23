using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BestPrice.Models;
using BestPrice.Services;

namespace BestPrice.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly prj666_192a03Context _context;

        public ReviewsController(prj666_192a03Context context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index(string productName, string sellerName, string picture, string link, string productDescription, float price, long productId, int? pageNumber)
        {
            ViewBag.productName = productName;
            ViewBag.sellerName = sellerName;
            ViewBag.picture = picture;
            ViewBag.link = link;
            ViewBag.productDescription = productDescription;
            ViewBag.price = price;
            ViewBag.productId = productId;
            int pageSize = 10;
            var paged_reviews = (await _context.Reviews.Where(r => r.ProductId == productId).ToListAsync()).OrderByDescending(r => r.Id);
            var totalReviews = paged_reviews.Count();
            int sum_ratings = 0;
            foreach (var review in paged_reviews)
            {
                sum_ratings += review.Rating;
            }
            int average_rating = (int)Math.Round((double)sum_ratings / totalReviews);
            ViewBag.total_reviews = totalReviews;
            ViewBag.average_rating = average_rating;
            return View(PaginatedList<Reviews>.CreatePage(paged_reviews, pageNumber ?? 1, pageSize));
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .SingleOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create(string productName, string sellerName, string picture, string link, string productDescription, float price, long productId)
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            Reviews reviews = new Reviews();
            reviews.ProductName = productName;
            reviews.SellerName = sellerName;
            reviews.Image = picture;
            reviews.Link = link;
            reviews.ProductDescription = productDescription;
            reviews.Price = price;
            reviews.ProductId = productId;
            return View(reviews);
        }


        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Description,Rating,ProductName,SellerName,Image,Link,ProductDescription,ProductCondition,Price,SoldOut,ProductId")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviews);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { productName = reviews.ProductName, sellerName = reviews.SellerName, picture = reviews.Image, link = reviews.Link, productDescription = reviews.ProductDescription, price = reviews.Price, productId = reviews.ProductId});
            }
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Description,Rating,ProductName,SellerName,Image,Link,ProductDescription,ProductCondition,Price,SoldOut")] Reviews reviews)
        {
            if (id != reviews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.Id))
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
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .SingleOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
