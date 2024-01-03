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
    public class DepartementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Departements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Departement.Include(d => d.Annee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Departements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departement == null)
            {
                return NotFound();
            }

            var departement = await _context.Departement
                .Include(d => d.Annee)
                .FirstOrDefaultAsync(m => m.DepartementId == id);
            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }

        // GET: Departements/Create
        //public IActionResult Create()
        //{
        //    // display etablissement name 
        //    ViewData["EtablissementId"] = new SelectList(_context.Etablissement, "EtablissementId", "Nom");
        //    return View();
        //}
        public IActionResult Create()
        {
            ViewData["AnneeId"] = new SelectList(_context.AnneeScolaire, "AnneeScolaireId", "DateDebut");
            return View();
        }

        // POST: Departements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartementId,Nom,AnneeId")] Departement departement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnneeId"] = new SelectList(_context.AnneeScolaire, "AnneeScolaireId", "AnneeScolaireId", departement.AnneeId);
            return View(departement);
        }

        // GET: Departements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departement == null)
            {
                return NotFound();
            }

            var departement = await _context.Departement.FindAsync(id);
            if (departement == null)
            {
                return NotFound();
            }
            ViewData["AnneeId"] = new SelectList(_context.AnneeScolaire, "AnneeScolaireId", "AnneeScolaireId", departement.AnneeId);
            return View(departement);
        }

        // POST: Departements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartementId,Nom,AnneeId")] Departement departement)
        {
            if (id != departement.DepartementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartementExists(departement.DepartementId))
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
            ViewData["AnneeId"] = new SelectList(_context.AnneeScolaire, "AnneeScolaireId", "AnneeScolaireId", departement.AnneeId);
            return View(departement);
        }

        // GET: Departements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departement == null)
            {
                return NotFound();
            }

            var departement = await _context.Departement
                .Include(d => d.Annee)
                .FirstOrDefaultAsync(m => m.DepartementId == id);
            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }

        // POST: Departements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departement == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Departement'  is null.");
            }
            var departement = await _context.Departement.FindAsync(id);
            if (departement != null)
            {
                _context.Departement.Remove(departement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartementExists(int id)
        {
          return (_context.Departement?.Any(e => e.DepartementId == id)).GetValueOrDefault();
        }
    }
}
