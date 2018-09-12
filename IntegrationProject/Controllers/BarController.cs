﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegrationProject.Data;
using IntegrationProject.Models;

namespace IntegrationProject.Controllers
{
    public class BarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bars.Include(b => b.Admin).Include(b => b.Answer);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult Details(int barId)
        {
            return View();
        }
        // GET: Bars/Details/5
        public void SetBar(string id)
        {
            var yelpData = JsonParser.ParseYelpSearchBar(id);
            var bar = _context.Bars.SingleOrDefault(b => b.YelpId == id);

            if (bar == null)
            {
                Bar newBar = CreateBar(yelpData);
                var barDetails = _context.Bars.SingleOrDefault(b => b.YelpId == id);
                Details(barDetails.Id);
            }
            else if (bar.YelpId != null && bar.YelpId == id)
            {
                Details(bar.Id);
            }
            else
            {
                NotFound();
            }
        }

        public Bar CreateBar(Business data)
        {
            Bar bar = new Bar()
            {
                YelpId= data.id,
                Name = data.name,
                Image_Url = data.image_url,
                Phone = data.phone,
                Address = data.location.address1,
                City = data.location.city,
                State = data.location.state,
                Zipcode = data.location.zip_code
            };
            _context.Bars.Add(bar);
            _context.SaveChanges();
            return bar;
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
    }
}
