using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BestPrice.Models;
using BestPrice.Services;
using MailKit.Security;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;

namespace BestPrice.Controllers
{
    public class HomeController : Controller
    {
        private readonly prj666_192a03Context _context;
        private readonly IEmailSender _emailSender;

        public HomeController(prj666_192a03Context context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs([Bind("Subject, Name, Email, Message")] ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                var messageBody = $"From: {contactForm.Name}\n Email: {contactForm.Email}\n\n {contactForm.Message}";
                await _emailSender.SendEmailByMailKitAsync("prj666_group03@yahoo.com", contactForm.Subject, messageBody, "Contact Us");
                return RedirectToAction(nameof(ContactUsSuccessful));
            }

            return View();
        }

        public IActionResult ContactUsSuccessful()
        {
            return View();
        }


        public IActionResult ReportIssue()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportIssue([Bind("Subject, Description")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailByMailKitAsync("prj666_group03@yahoo.com", problem.Subject, problem.Description, "Problem Report");
                return RedirectToAction(nameof(ReportIssueSuccessful));
            }

            return View();
        }

        public IActionResult ReportIssueSuccessful()
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
