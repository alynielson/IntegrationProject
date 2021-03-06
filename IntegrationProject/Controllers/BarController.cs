﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegrationProject.Data;
using IntegrationProject.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;
using Microsoft.Win32.SafeHandles;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace IntegrationProject.Controllers
{
    public class BarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BarController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bars.Include(b => b.Admin).Include(b => b.Answer);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            var barToView = _context.Bars.Include(bar => bar.Comments).Include(bar => bar.Ratings).FirstOrDefault(b => b.Id == id);
            var yelpData = JsonParser.ParseYelpReviews(barToView.YelpId);
            var reviews = yelpData.reviews.Select(review => review.text).ToList();
            ViewData["Reviews"] = reviews;
            barToView.Comments = _context.Comments.Where(c => c.BarId == id).ToList();
            barToView.Ratings = _context.Ratings.Where(rating => rating.BarId == id).ToList();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("Member"))
            {
                ViewData["ApplicationUserId"] = user.Id;
                ViewData["MemberId"] = _context.Members.SingleOrDefault(m => m.ApplicationUserId == user.Id).Id;
            }
            
            return View(barToView);
        }


        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]

        public ActionResult Details(int id, IFormCollection form)
        {
            var barToEdit = _context.Bars.Find(id);
            _context.Comments.Add(new Comment()
            {
                userComment = form["Comment"],
                BarId = barToEdit.Id
            });
            _context.Ratings.Add(new Rating()
            {
                userRating = int.Parse(form["Rating"]),
                BarId = barToEdit.Id
            });

            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { id = id });
        }
        public IActionResult SetBar(string id)
        {
            var yelpData = JsonParser.ParseYelpSearchBar(id);
            var bar = _context.Bars.SingleOrDefault(b => b.YelpId == id);
            if (bar == null)
            {
                Bar newBar = BarCreator.CreateBar(yelpData, _context);
                var barDetails = _context.Bars.SingleOrDefault(b => b.YelpId == id);
                return RedirectToAction("Details", "Bar", new { id = barDetails.Id }, null);
            }
            else if (bar.YelpId != null && bar.YelpId == id)
            {
                return RedirectToAction("Details", "Bar", new { id = bar.Id }, null);
            }
            else
            {
                return NotFound();
            }

        }



        // GET: Bars/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admins, "Id", "Id");
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id");
            return View();
        }

        // POST: Bars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,YelpId,AdminId,AnswerId")] Bar bar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "Id", "Id", bar.AdminId);
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", bar.AnswerId);
            return View(bar);
        }

        // GET: Bars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bar = await _context.Bars.FindAsync(id);
            if (bar == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "Id", "Id", bar.AdminId);
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", bar.AnswerId);
            return View(bar);
        }

        // POST: Bars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,YelpId,AdminId,AnswerId")] Bar bar)
        {
            if (id != bar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarExists(bar.Id))
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
            ViewData["AdminId"] = new SelectList(_context.Admins, "Id", "Id", bar.AdminId);
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", bar.AnswerId);
            return View(bar);
        }

        // GET: Bars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bar = await _context.Bars
                .Include(b => b.Admin)
                .Include(b => b.Answer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bar == null)
            {
                return NotFound();
            }

            return View(bar);
        }

        // POST: Bars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bar = await _context.Bars.FindAsync(id);
            _context.Bars.Remove(bar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarExists(int id)
        {
            return _context.Bars.Any(e => e.Id == id);
        }
        private async Task<string> UploadImageAsync(string Url)
        {
            byte[] response;
            using (var client = new WebClient())
            {
                string clientID = Credentials.ImgurApi;
                client.Headers.Add("Authorization", "Client-ID " + clientID);
                var values = new NameValueCollection { { "image",Url } };
                response = await client.UploadValuesTaskAsync("https://api.imgur.com/3/upload", values);
            }

            var result = JsonConvert.DeserializeObject<ImgurResponseViewModel>(Encoding.ASCII.GetString(response));

            return result.Data.Link;
        }
    }
}

