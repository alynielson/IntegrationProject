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
using Microsoft.AspNetCore.Identity;

namespace IntegrationProject.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public EventsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Events.Include(m => m.Member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
          
                .Include(m => m.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }
        

        // GET: Events/Create
        public IActionResult Create()
        {
           
            var yelpData = JsonParser.ParseYelpSearch(_context);
            var businesses = yelpData.businesses.Select(b => new SelectListItem { Text = b.name, Value = b.id });
            ViewData["Businesses"] = businesses;
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Date,Time,Details,Origin,Destination")] Event @event, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                var user = (await _userManager.GetUserAsync(HttpContext.User));
                var member = _context.Members.SingleOrDefault(m => m.ApplicationUserId == user.Id);
                @event.Member = member;
                Origin newOrigin = new Origin();

                newOrigin.Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Latitude;
                newOrigin.Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Longitude;
                @event.Origin = newOrigin;
                Destination newDestination = new Destination();
                newDestination.Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Destination"]).Latitude;
                newDestination.Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Destination"]).Longitude;
                @event.Destination = newDestination;
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", @event.MemberId);
            return View(@event);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            var yelpData = JsonParser.ParseYelpSearch(_context);
            var businesses = yelpData.businesses.Select(b => new SelectListItem { Text = b.name, Value = b.id });
            ViewData["Businesses"] = businesses;
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Date,Time,Details","Origin","Destination")] Event @event, IFormCollection form)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Waypoint newWaypoint = new Waypoint()
                    {
                        Latitude = JsonParser.ParseYelpSearchBar(form["Waypoint"]).coordinates.latitude.ToString(),
                        Longitude = JsonParser.ParseYelpSearchBar(form["Waypoint"]).coordinates.longitude.ToString(),
                        EventId = @event.Id
                    };
                    _context.Add(newWaypoint);
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", @event.MemberId);
            return View(@event);
        }

      
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
