using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelTestBlog.Data;
using TravelTestBlog.Models;

namespace TravelTestBlog.Controllers
{
    public class ExperiencesPeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperiencesPeopleController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ExperiencesPeople
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExperiencePerson.Include(e => e.Experience).Include(e => e.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExperiencesPeople/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencePerson = await _context.ExperiencePerson.SingleOrDefaultAsync(m => m.ExperiencePersonId == id);
            if (experiencePerson == null)
            {
                return NotFound();
            }

            return View(experiencePerson);
        }

        // GET: ExperiencesPeople/Create
        public IActionResult Create()
        {
            ViewData["ExperienceId"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceId");
            ViewData["PersonId"] = new SelectList(_context.Person, "PersonId", "PersonId");
            return View();
        }

        // POST: ExperiencesPeople/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperiencePersonId,ExperienceId,PersonId")] ExperiencePerson experiencePerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiencePerson);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ExperienceId"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceId", experiencePerson.ExperienceId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PersonId", "PersonId", experiencePerson.PersonId);
            return View(experiencePerson);
        }

        // GET: ExperiencesPeople/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencePerson = await _context.ExperiencePerson.SingleOrDefaultAsync(m => m.ExperiencePersonId == id);
            if (experiencePerson == null)
            {
                return NotFound();
            }
            ViewData["ExperienceId"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceId", experiencePerson.ExperienceId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PersonId", "PersonId", experiencePerson.PersonId);
            return View(experiencePerson);
        }

        // POST: ExperiencesPeople/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperiencePersonId,ExperienceId,PersonId")] ExperiencePerson experiencePerson)
        {
            if (id != experiencePerson.ExperiencePersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiencePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperiencePersonExists(experiencePerson.ExperiencePersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ExperienceId"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceId", experiencePerson.ExperienceId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PersonId", "PersonId", experiencePerson.PersonId);
            return View(experiencePerson);
        }

        // GET: ExperiencesPeople/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencePerson = await _context.ExperiencePerson.SingleOrDefaultAsync(m => m.ExperiencePersonId == id);
            if (experiencePerson == null)
            {
                return NotFound();
            }

            return View(experiencePerson);
        }

        // POST: ExperiencesPeople/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiencePerson = await _context.ExperiencePerson.SingleOrDefaultAsync(m => m.ExperiencePersonId == id);
            _context.ExperiencePerson.Remove(experiencePerson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ExperiencePersonExists(int id)
        {
            return _context.ExperiencePerson.Any(e => e.ExperiencePersonId == id);
        }
    }
}
