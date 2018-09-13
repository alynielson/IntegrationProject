﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegrationProject.Data;
using IntegrationProject.Models;
using Microsoft.AspNetCore.Identity;

namespace IntegrationProject.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            var user = (await _userManager.GetUserAsync(HttpContext.User));
            var admin = _context.Admins.SingleOrDefault(a => a.ApplicationUserId == user.Id);
            AdminBarVM viewModel = new AdminBarVM();
            viewModel.bars = new List<BarVM>();
            viewModel.admin = admin;
            SearchResult allBars = JsonParser.ParseYelpSearch();
            for (int i = 0; i < allBars.businesses.Length; i++)
            {
                var bar = _context.Bars.SingleOrDefault(b => allBars.businesses[i].id == b.YelpId);
                if (bar == null)
                {
                    BarCreator.CreateBar(allBars.businesses[i], _context);
                    bar = _context.Bars.Include(a => a.Admin).SingleOrDefault(b => allBars.businesses[i].id == b.YelpId);
                }
                BarVM barVM = new BarVM() {};
                if (bar.AdminId != null)
                {
                    barVM.adminName = bar.Admin.Name;
                }
                barVM.bar = bar;
                viewModel.bars.Add(barVM);
            }
            return View(viewModel);
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        
       

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        
        public async Task<IActionResult> Create()
        {
            
                var user = (await _userManager.GetUserAsync(HttpContext.User));
                Admin admin = new Admin();
                admin.ApplicationUserId = user.Id;
                admin.Name = user.Email;
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", admin.ApplicationUserId);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ApplicationUserId")] Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", admin.ApplicationUserId);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
        [HttpGet]
        public async Task<IActionResult> DoSurvey(int id)
        {
            var bar = await _context.Bars.FindAsync(id);
            return View(bar);
        }
        [HttpPost]
        public async Task<IActionResult> DoSurvey(int id, [Bind("Answer")] Bar bar)
        {
            if (ModelState.IsValid)
            {
                var barToUpdate = _context.Bars.Find(id);
                try
                {
                    barToUpdate.Answer = bar.Answer;
                    barToUpdate.Answer = Survey.GetCheckLists(barToUpdate.Answer);
                    _context.Update(barToUpdate);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (barToUpdate == null)
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
            return RedirectToAction("Index", "Admins");
        }
    }
}
