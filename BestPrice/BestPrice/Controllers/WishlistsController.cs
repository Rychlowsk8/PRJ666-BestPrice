using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BestPrice.Models;
using BestPrice.Models.Api;
using BestPrice.Services;
using Microsoft.AspNetCore.Identity;

namespace BestPrice.Controllers
{
    public class WishlistsController : Controller
    {
        private readonly prj666_192a03Context _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishlistsController(prj666_192a03Context context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Wishlists
        public async Task<IActionResult> Index(int? pageNumber)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            var user = await _userManager.GetUserAsync(User);
            var prj666_192a03Context = _context.Wishlists.Include(w => w.User)
                .Where(x => x.UserId == user.Id);
            List<Wishlists> items = new List<Wishlists>(await prj666_192a03Context.ToListAsync());
            int pageSize = 5;

            return View(PaginatedList<Wishlists>.CreatePage(items.OrderBy(p => p), pageNumber ?? 1, pageSize));
        }

        // GET: Wishlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlists = await _context.Wishlists
                .Include(w => w.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (wishlists == null)
            {
                return NotFound();
            }

            return View(wishlists);
        }

        // GET: Wishlists/Create
        public async Task<IActionResult> Create(long productId, string productName, string description, string link, string image, float price, string soldBy)
        {
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            var user = await _userManager.GetUserAsync(User);
            Wishlists list = new Wishlists();
            list.ProductName = productName;

            var noItem = await _context.Wishlists
                .Include(w => w.User)
                .SingleOrDefaultAsync(m => m.ProductId == productId);

            if (noItem == null)
            {
                var tooManyItems = _context.Wishlists
                    .Include(w => w.User)
                    .Where(m => m.UserId == user.Id.ToString())
                    .ToList();

                if (tooManyItems.Count() >= 20)
                {
                    list.ProductId = -2;
                }
                else
                {
                    list.ProductId = productId;
                    list.Description = description;
                    list.Link = link;
                    list.Image = image;
                    list.Price = price;
                    list.SellerName = soldBy;
                    list.UserId = user.Id.ToString();

                    _context.Add(list);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                list.ProductId = -1;
            }
            return View(list);
        }

        // GET: Wishlists/Delete/5
        public async Task<IActionResult> Delete(long? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var wishlists = await _context.Wishlists
                .Include(w => w.User)
                .SingleOrDefaultAsync(m => m.Id == productId);
            if (wishlists == null)
            {
                return NotFound();
            }
            _context.Wishlists.Remove(wishlists);
            await _context.SaveChangesAsync();

            return View(wishlists);
        }

        private bool WishlistsExists(int id)
        {
            return _context.Wishlists.Any(e => e.Id == id);
        }
    }
}
