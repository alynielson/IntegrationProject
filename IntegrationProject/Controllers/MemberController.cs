using System;
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
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public MemberController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Member
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Members.Include(m => m.Answer).Include(m => m.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var member = await _context.Members
                .Include(m => m.Answer)
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            member.Answer.Activities = _context.Activities.Where(activity => activity.AnswerId == member.AnswerId).ToList();
            member.Answer.Drinks = _context.Drinks.Where(drink => drink.AnswerId == member.AnswerId).ToList();
            member.Answer.Foods = _context.Foods.Where(food => food.AnswerId == member.AnswerId).ToList();
            member.Answer.Musics = _context.Musics.Where(music => music.AnswerId == member.AnswerId).ToList();
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Answer", "ApplicationUserId")] Member member)
        {
            if (ModelState.IsValid)
            {
                var user = (await _userManager.GetUserAsync(HttpContext.User));
                member.Answer = GetCheckLists(member.Answer);
                member.ApplicationUserId = user?.Id;
                member.Name = user?.Email;
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(member);
        }

        private List<Drink> GetDrinks (List<Drink> memberDrinks)
        {
            for(int i = 0; i < Survey.DRINKS.Count; i++)
            {
                memberDrinks[i].Type = Survey.DRINKS[i].Type;
            }
            var filteredDrinks = memberDrinks.Where(drink => drink.Checked == true).ToList();
            return filteredDrinks;
        }
        private List<Food> GetFoods(List<Food> memberFoods)
        {
            for (int i = 0; i < Survey.FOODS.Count; i++)
            {
                memberFoods[i].Type = Survey.FOODS[i].Type;
            }
            var filteredFoods = memberFoods.Where(food => food.Checked == true).ToList();
            return filteredFoods;
        }
        private List<ActivityItem> GetActivities(List<ActivityItem> memberActivities)
        {
            for (int i = 0; i < Survey.ACTIVITIES.Count; i++)
            {
                memberActivities[i].Type = Survey.ACTIVITIES[i].Type;
            }
            var filteredActivities = memberActivities.Where(activity => activity.Checked == true).ToList();
            return filteredActivities;
        }
        private List<Music> GetMusics(List<Music> memberMusics)
        {
            for (int i = 0; i < Survey.MUSICS.Count; i++)
            {
                memberMusics[i].Type = Survey.MUSICS[i].Type;
            }
            var filteredMusics = memberMusics.Where(music => music.Checked == true).ToList();
            return filteredMusics;
        }
        private Answer GetCheckLists(Answer answer)
        {
            answer.Drinks = GetDrinks(answer.Drinks);
            answer.Foods = GetFoods(answer.Foods);
            answer.Activities = GetActivities(answer.Activities);
            answer.Musics = GetMusics(answer.Musics);
            return answer;
        }

        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", member.AnswerId);
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", member.ApplicationUserId);
            return View(member);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AnswerId,ApplicationUserId")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            ViewData["AnswerId"] = new SelectList(_context.Answers, "Id", "Id", member.AnswerId);
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", member.ApplicationUserId);
            return View(member);
        }

        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.Answer)
                .Include(m => m.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
