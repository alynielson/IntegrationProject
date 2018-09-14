using System;
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
            var applicationDbContext = _context.Events.Include(m => m.ApplicationUser);
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
          
                .Include(m => m.ApplicationUser)
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
                
                @event.ApplicationUser = user;
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
            
            return View(@event);
        }
        


        

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Date,Details","Origin","Destination")] Event @event, IFormCollection form)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var eventToUpdate = _context.Events.Find(id);
                try
                {
                    eventToUpdate.Name = @event.Name;
                    eventToUpdate.Date = @event.Date;
                    eventToUpdate.Details = @event.Details;
                    Survey.ClearLocations(eventToUpdate.Origin, eventToUpdate.Destination, _context);
                    eventToUpdate.Origin = new Origin()
                    {
                        Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Latitude,
                        Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Longitude
                    };
                    eventToUpdate.Destination = new Destination()
                    {
                        Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Destination"]).Latitude,
                        Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Destination"]).Longitude
                    };
                    Waypoint newWaypoint = new Waypoint()
                    {
                        Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Waypoint"]).Latitude,
                        Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Waypoint"]).Longitude,
                        EventId = @event.Id
                    };
                    _context.Add(newWaypoint);

                    _context.Update(eventToUpdate);
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
            
            return View(@event);
        }

      
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
