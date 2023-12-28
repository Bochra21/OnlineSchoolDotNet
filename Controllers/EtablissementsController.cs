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
    public class EtablissementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtablissementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etablissements
        public async Task<IActionResult> Index()
        {
              return _context.Etablissement != null ? 
                          View(await _context.Etablissement.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Etablissement'  is null.");
        }

        // GET: Etablissements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Etablissement == null)
            {
                return NotFound();
            }

            var etablissement = await _context.Etablissement
                .FirstOrDefaultAsync(m => m.EtablissementId == id);
            if (etablissement == null)
            {
                return NotFound();
            }

            return View(etablissement);
        }

        // GET: Etablissements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etablissements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtablissementId,Nom,Adresse")] Etablissement etablissement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etablissement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etablissement);
        }

        // GET: Etablissements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Etablissement == null)
            {
                return NotFound();
            }

            var etablissement = await _context.Etablissement.FindAsync(id);
            if (etablissement == null)
            {
                return NotFound();
            }
            return View(etablissement);
        }

        // POST: Etablissements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtablissementId,Nom,Adresse")] Etablissement etablissement)
        {
            if (id != etablissement.EtablissementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etablissement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtablissementExists(etablissement.EtablissementId))
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
            return View(etablissement);
        }

        // GET: Etablissements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Etablissement == null)
            {
                return NotFound();
            }

            var etablissement = await _context.Etablissement
                .FirstOrDefaultAsync(m => m.EtablissementId == id);
            if (etablissement == null)
            {
                return NotFound();
            }

            return View(etablissement);
        }

        // POST: Etablissements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Etablissement == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Etablissement'  is null.");
            }
            var etablissement = await _context.Etablissement.FindAsync(id);
            if (etablissement != null)
            {
                _context.Etablissement.Remove(etablissement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtablissementExists(int id)
        {
          return (_context.Etablissement?.Any(e => e.EtablissementId == id)).GetValueOrDefault();
        }



        //Display all school years that belongs to a school 
        public async Task<IActionResult> AnneeScolaires(int? id)
        {
            if (id == null || _context.Etablissement == null)
            {
                return NotFound();
            }

            var etablissement = await _context.Etablissement
                .Include(e => e.AnneeScolaires) // Include related AnneeScolaires
                .FirstOrDefaultAsync(m => m.EtablissementId == id);

            if (etablissement == null)
            {
                return NotFound();
            }

            return View(etablissement.AnneeScolaires.ToList());
        }



    }
}
