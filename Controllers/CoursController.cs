using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSchoolWebApp.Data;
using OnlineSchoolWebApp.Models;

namespace OnlineSchoolWebApp.Controllers
{
    public class CoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cours
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cours.Include(c => c.Classe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cours == null)
            {
                return NotFound();
            }

            var cours = await _context.Cours
                .Include(c => c.Classe)
                .FirstOrDefaultAsync(m => m.CoursId == id);
            if (cours == null)
            {
                return NotFound();
            }

            return View(cours);
        }


        public async Task<List<ApplicationUser>> DisplayTeachers()
        {
            var roleId = await _context.Roles
                .Where(r => r.Name == "Teacher")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            if (roleId == null)
            {
               
            }

            var userIds = await _context.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToListAsync();

            var teachers = await _context.Users
                .OfType<ApplicationUser>()
                .Where(u => userIds.Contains(u.Id))
                .Select(u => new ApplicationUser
                {
                    Id = u.Id, 
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .ToListAsync();

            return teachers;
        }

        // GET: Cours/Create


        public async Task<IActionResult> Create()
        {
            ViewData["ClasseId"] = new SelectList(_context.Classe, "ClasseId", "Nom");
            var teachers = await DisplayTeachers();
            ViewData["EnseignantId"] = new SelectList(teachers, "Id", "LastName");
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoursId,Nom,ClasseId,EnseignantId")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasseId"] = new SelectList(_context.Classe, "ClasseId", "ClasseId", cours.ClasseId);
            return View(cours);
        }

        // GET: Cours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cours == null)
            {
                return NotFound();
            }

            var cours = await _context.Cours.FindAsync(id);
            if (cours == null)
            {
                return NotFound();
            }
            ViewData["ClasseId"] = new SelectList(_context.Classe, "ClasseId", "ClasseId", cours.ClasseId);
            return View(cours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoursId,Nom,ClasseId,EnseignantId")] Cours cours)
        {
            if (id != cours.CoursId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursExists(cours.CoursId))
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
            ViewData["ClasseId"] = new SelectList(_context.Classe, "ClasseId", "ClasseId", cours.ClasseId);
            return View(cours);
        }

        // GET: Cours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cours == null)
            {
                return NotFound();
            }

            var cours = await _context.Cours
                .Include(c => c.Classe)
                .FirstOrDefaultAsync(m => m.CoursId == id);
            if (cours == null)
            {
                return NotFound();
            }

            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cours == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cours'  is null.");
            }
            var cours = await _context.Cours.FindAsync(id);
            if (cours != null)
            {
                _context.Cours.Remove(cours);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursExists(int id)
        {
          return (_context.Cours?.Any(e => e.CoursId == id)).GetValueOrDefault();
        }
    }
}
