using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestPrice.Models;
using Microsoft.EntityFrameworkCore;

namespace BestPrice.Controllers
{
    public class HomeController : Controller
    {
        private readonly prj666_192a03Context _context;

        public HomeController(prj666_192a03Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult ReportIssue()
        {
            return View();
        }

        public async Task<IActionResult> HelpCentre()
        {
            return View(await _context.Faqs.ToListAsync());
        }

        public IActionResult About()
        {
            return View();
        }

        public PartialViewResult HelpProductSearch()
        {
            return PartialView("HelpCentrePartials/_ProductSearch");
        }

        public PartialViewResult HelpNotifications()
        {
            return PartialView("HelpCentrePartials/_Notifications");
        }

        public PartialViewResult HelpWishlist()
        {
            return PartialView("HelpCentrePartials/_Wishlist");
        }

        public PartialViewResult HelpCreateAccount()
        {
            return PartialView("HelpCentrePartials/_CreateAccount");
        }

        public PartialViewResult HelpDeleteAccount()
        {
            return PartialView("HelpCentrePartials/_DeleteAccount");
        }

        public PartialViewResult HelpChangeEmail()
        {
            return PartialView("HelpCentrePartials/_ChangeEmail");
        }

        public PartialViewResult HelpAddItem()
        {
            return PartialView("HelpCentrePartials/_AddItem");
        }
        public PartialViewResult HelpRemoveItem()
        {
            return PartialView("HelpCentrePartials/_RemoveItem");
        }
    }
}
