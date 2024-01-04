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
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Note.Include(n => n.Cours);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.Cours)
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            // Assuming you have access to the student information based on your context
            // Replace "StudentInfo" with the actual property or method that retrieves student information
            var studentInfo = _context.Etudiant.FirstOrDefault();

            ViewData["CoursId"] = new SelectList(_context.Cours, "CoursId", "Nom");
            ViewData["EtudiantId"] = new SelectList(_context.Cours, "EtudiantId", "Nom");
            return View();
        }

            // POST: Notes/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoteId,NoteValue,NoteDesc,EtudiantId,CoursId")] Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoursId"] = new SelectList(_context.Cours, "CoursId", "CoursId", note.CoursId);
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["CoursId"] = new SelectList(_context.Cours, "CoursId", "CoursId", note.CoursId);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoteId,NoteValue,NoteDesc,EtudiantId,CoursId")] Note note)
        {
            if (id != note.NoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.NoteId))
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
            ViewData["CoursId"] = new SelectList(_context.Cours, "CoursId", "CoursId", note.CoursId);
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Note == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .Include(n => n.Cours)
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Note == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Note'  is null.");
            }
            var note = await _context.Note.FindAsync(id);
            if (note != null)
            {
                _context.Note.Remove(note);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
          return (_context.Note?.Any(e => e.NoteId == id)).GetValueOrDefault();
        }
    }
}
