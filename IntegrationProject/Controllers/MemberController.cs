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

        public async Task<IActionResult> Events(string Id)
        {
            var member = _context.Members.SingleOrDefault(a => a.ApplicationUserId == Id);
            MemberEventVM viewModel = new MemberEventVM();
            viewModel.member = member;
            var @events = _context.Events.Include(a => a.Origin).Include(a => a.ApplicationUser).Where(e => e.ApplicationUserId == member.ApplicationUserId);
            viewModel.@events = @events.ToList();
            return View(viewModel);
        }

      

        // GET: Member
        public async Task<IActionResult> Index()
        {
            var user = (await _userManager.GetUserAsync(HttpContext.User));
            var member = _context.Members.Include(m => m.Answer).Include(m => m.ApplicationUser).SingleOrDefault(u => u.ApplicationUserId == user.Id);
            MemberBarVM viewModel = new MemberBarVM();
            viewModel.member = member;
            List<BarMatch> barMatches = new List<BarMatch> { };
            var bars = _context.Matches.Include(m => m.Bar).Where(m => m.MemberId == member.Id).OrderByDescending(m => m.Score).Select(m => m.Bar).ToList();
            var scores = _context.Matches.Include(m => m.Bar).Where(m => m.MemberId == member.Id).OrderByDescending(m => m.Score).Select(m => m.Score).ToList();
            for (int i = 0; i < bars.Count; i++)
            {
                BarMatch newMatch = new BarMatch();
                newMatch.bar = bars[i];
                newMatch.score = scores[i];
                barMatches.Add(newMatch);
            }
            viewModel.matchedBars = barMatches;
           
            return View(viewModel);
        }

        public IActionResult AllBars(int Id)
        {
            var member = _context.Members.Find(Id);
            var yelpData = JsonParser.ParseYelpSearch(_context);
            var businesses = yelpData.businesses.ToList();
            ViewData["Businesses"] = businesses;
            return View(member);
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
                member.Answer = Survey.GetCheckLists(member.Answer);
                member.ApplicationUserId = user?.Id;
                member.Name = user?.Email;
                _context.Add(member);
                await _context.SaveChangesAsync();
                SurveyAnalyzer.GetNewMemberMatchResults(member, _context);
                return RedirectToAction(nameof(Index));
            }

            return View(member);
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
        public async Task<IActionResult> Edit(int id, [Bind("Answer")] Member member)
        {
            if (ModelState.IsValid)
            {
                var memberToUpdate = _context.Members.Find(id);
                
                try
                {

                    var currentAnswer = _context.Answers.Find(memberToUpdate.AnswerId);
                    Survey.ClearAnswers(currentAnswer, _context);
                    Answer answerToCopy = member.Answer;
                    Survey.CopyValuesToAnswerRow(currentAnswer, answerToCopy, _context);

                    Survey.ClearMatchesMember(_context, memberToUpdate);

                 
                    await _context.SaveChangesAsync();
                    SurveyAnalyzer.GetNewMemberMatchResults(memberToUpdate, _context);
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

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            var userToRemove = _context.Users.SingleOrDefault(user => user.Id == member.ApplicationUserId);
            var answerToRemove = _context.Answers.SingleOrDefault(answer => answer.Id == member.AnswerId);
            _context.Answers.Remove(answerToRemove);
            _context.Users.Remove(userToRemove);
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
