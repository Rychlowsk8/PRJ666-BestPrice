﻿using System;
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
        public async Task<IActionResult> Create([Bind("Id,UserId,ProductName,Seller,BeforePrice,CurrentPrice,PriceStatus,LastModified")] Notifications notifications)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ProductName,Seller,BeforePrice,CurrentPrice,PriceStatus,LastModified")] Notifications notifications)
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
