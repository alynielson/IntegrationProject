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
                .Include(o => o.Origin)
                .Include(o => o.Destination)
                .FirstOrDefaultAsync(m => m.Id == id);
            @event.Waypoints = _context.Waypoints.Where(w => w.EventId == id).ToList();
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }
        

        // GET: Events/Create
        public IActionResult Create(string id)
        {

            //var yelpData = JsonParser.ParseYelpSearch(_context);
            //var businesses = yelpData.businesses.Select(b => new SelectListItem { Text = b.name, Value = b.id });
            var businesses = _context.Bars.Select(b => new SelectListItem { Text = b.Name, Value= b.YelpId });
            var stops = new List<int> { 0, 1, 2, 3, 4 };
            var selectStops = stops.Select(s => new SelectListItem { Text = s.ToString(), Value = s.ToString() });
            ViewData["Stops"] = selectStops;
            ViewData["Businesses"] = businesses;
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id, [Bind("Name,Date,Time,Details,Origin,Destination")] Event @event, IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                var user = (await _userManager.GetUserAsync(HttpContext.User));
                
                @event.ApplicationUser = user;
                Origin newOrigin = new Origin();
                newOrigin.Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Latitude;
                newOrigin.Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Longitude;
                newOrigin.Name = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Name;
                @event.Origin = newOrigin;

                var numberOfStops = int.Parse(form["Stops"]);
                if (numberOfStops == 0)
                {
                    Destination newDestination = new Destination();
                    newDestination.Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Latitude;
                    newDestination.Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Longitude;
                    newDestination.Name = _context.Bars.SingleOrDefault(b => b.YelpId == form["Origin"]).Name;
                    @event.Destination = newDestination;
                }
                else if (numberOfStops >= 1)
                {
                    Destination newDestination = new Destination();
                    @event.Destination = newDestination;
                    if (numberOfStops > 1)
                    {
                        List<Waypoint> waypoints = new List<Waypoint>();
                        for(int i = 0; i < numberOfStops - 1; i++)
                        {
                            waypoints.Add(new Waypoint());
                        }
                        @event.Waypoints = waypoints;
                    }
                }
                
                _context.Add(@event);
                _context.SaveChanges();
                var userToFind = (await _userManager.GetUserAsync(HttpContext.User));
                var eventToView = _context.Events.OrderByDescending(s => s.Id).FirstOrDefault(a => a.ApplicationUserId == userToFind.Id).Id;
                if(numberOfStops == 0)
                {
                    return RedirectToAction(nameof(Details), new { id = eventToView });
                }
                else
                {
                    return RedirectToAction(nameof(Edit), new { id = eventToView });
                }
                
            }

            return View(@event);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var businesses = _context.Bars.Select(b => new SelectListItem { Text = b.Name, Value = b.YelpId });
            ViewData["Businesses"] = businesses;
            var @event = await _context.Events.Include(o => o.Origin).Include(d => d.Destination).Include(w => w.Waypoints).Include(a => a.ApplicationUser).SingleOrDefaultAsync(a => id ==a.Id);

            if (@event == null)
            {
                return NotFound();
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
            

            if (ModelState.IsValid)
            {
                var eventToUpdate = _context.Events.Include(d => d.Destination).Include(o => o.Origin).Include(w => w.Waypoints).SingleOrDefault(e => e.Id == id);
                try
                {


                    eventToUpdate.Destination.Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Destination"]).Latitude;
                    eventToUpdate.Destination.Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form["Destination"]).Longitude;
                    eventToUpdate.Destination.Name = _context.Bars.SingleOrDefault(b => b.YelpId == form["Destination"]).Name;


                    _context.Destinations.Update(eventToUpdate.Destination);
                    var waypointsFromDb = _context.Waypoints.Include(e => e.Event).Where(w => w.EventId == eventToUpdate.Id).ToList();
                    for (int i = 0; i < waypointsFromDb.Count; i++)
                    {
                        waypointsFromDb[i].Latitude = _context.Bars.SingleOrDefault(b => b.YelpId == form[$"Waypoints[{i}]"]).Latitude;
                        waypointsFromDb[i].Longitude = _context.Bars.SingleOrDefault(b => b.YelpId == form[$"Waypoints[{i}]"]).Longitude;
                        waypointsFromDb[i].Name = _context.Bars.SingleOrDefault(b => b.YelpId == form[$"Waypoints[{i}]"]).Name;

                        _context.Waypoints.Update(waypointsFromDb[i]);
                    }
                    _context.SaveChanges();
                    
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
