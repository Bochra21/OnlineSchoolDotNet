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
    public class NiveauxController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NiveauxController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Niveaux
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Niveau.Include(n => n.Departement);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Niveaux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Niveau == null)
            {
                return NotFound();
            }

            var niveau = await _context.Niveau
                .Include(n => n.Departement)
                .FirstOrDefaultAsync(m => m.NiveauId == id);
            if (niveau == null)
            {
                return NotFound();
            }

            return View(niveau);
        }

        // GET: Niveaux/Create
        public IActionResult Create()
        {
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "Nom");
            return View();
        }

        // POST: Niveaux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NiveauId,Nom,DepartementId")] Niveau niveau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(niveau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", niveau.DepartementId);
            return View(niveau);
        }

        // GET: Niveaux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Niveau == null)
            {
                return NotFound();
            }

            var niveau = await _context.Niveau.FindAsync(id);
            if (niveau == null)
            {
                return NotFound();
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "Nom", niveau.DepartementId);
            return View(niveau);
        }

        // POST: Niveaux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NiveauId,Nom,DepartementId")] Niveau niveau)
        {
            if (id != niveau.NiveauId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(niveau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NiveauExists(niveau.NiveauId))
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
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", niveau.DepartementId);
            return View(niveau);
        }

        // GET: Niveaux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Niveau == null)
            {
                return NotFound();
            }

            var niveau = await _context.Niveau
                .Include(n => n.Departement)
                .FirstOrDefaultAsync(m => m.NiveauId == id);
            if (niveau == null)
            {
                return NotFound();
            }

            return View(niveau);
        }

        // POST: Niveaux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Niveau == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Niveau'  is null.");
            }
            var niveau = await _context.Niveau.FindAsync(id);
            if (niveau != null)
            {
                _context.Niveau.Remove(niveau);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NiveauExists(int id)
        {
          return (_context.Niveau?.Any(e => e.NiveauId == id)).GetValueOrDefault();
        }
    }
}
