using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSchoolWebApp.Data;
using OnlineSchoolWebApp.Models;

namespace OnlineSchoolWebApp.Controllers
{
    public class AnneeScolairesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnneeScolairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnneeScolaires
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AnneeScolaire.Include(a => a.Etablissement);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AnneeScolaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnneeScolaire == null)
            {
                return NotFound();
            }

            var anneeScolaire = await _context.AnneeScolaire
                .Include(a => a.Etablissement)
                .FirstOrDefaultAsync(m => m.AnneeScolaireId == id);
            if (anneeScolaire == null)
            {
                return NotFound();
            }

            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Create
        public IActionResult Create()
        {
            // display etablissement name 
            ViewData["EtablissementId"] = new SelectList(_context.Etablissement, "EtablissementId", "Nom");
            return View();
        }

        // POST: AnneeScolaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnneeScolaireId,DateDebut,DateFin,EtablissementId")] AnneeScolaire anneeScolaire)
        {


            if (ModelState.IsValid)
            {
                _context.Add(anneeScolaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtablissementId"] = new SelectList(_context.Etablissement, "EtablissementId", "EtablissementId", anneeScolaire.EtablissementId);
            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnneeScolaire == null)
            {
                return NotFound();
            }

            var anneeScolaire = await _context.AnneeScolaire.FindAsync(id);
            if (anneeScolaire == null)
            {
                return NotFound();
            }
            ViewData["EtablissementId"] = new SelectList(_context.Etablissement, "EtablissementId", "EtablissementId", anneeScolaire.EtablissementId);
            return View(anneeScolaire);
        }

        // POST: AnneeScolaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnneeScolaireId,DateDebut,DateFin,EtablissementId")] AnneeScolaire anneeScolaire)
        {
            if (id != anneeScolaire.AnneeScolaireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anneeScolaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnneeScolaireExists(anneeScolaire.AnneeScolaireId))
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
            ViewData["EtablissementId"] = new SelectList(_context.Etablissement, "EtablissementId", "EtablissementId", anneeScolaire.EtablissementId);
            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnneeScolaire == null)
            {
                return NotFound();
            }

            var anneeScolaire = await _context.AnneeScolaire
                .Include(a => a.Etablissement)
                .FirstOrDefaultAsync(m => m.AnneeScolaireId == id);
            if (anneeScolaire == null)
            {
                return NotFound();
            }

            return View(anneeScolaire);
        }

        // POST: AnneeScolaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnneeScolaire == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AnneeScolaire'  is null.");
            }
            var anneeScolaire = await _context.AnneeScolaire.FindAsync(id);
            if (anneeScolaire != null)
            {
                _context.AnneeScolaire.Remove(anneeScolaire);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnneeScolaireExists(int id)
        {
          return (_context.AnneeScolaire?.Any(e => e.AnneeScolaireId == id)).GetValueOrDefault();
        }


        //public async Task<IActionResult> GetDepartmentByYearPartial(int? id)
        //{
        //    if (id == null || _context.AnneeScolaire == null)
        //    {
        //        return NotFound();
        //    }

        //    var schoolYear = await _context.AnneeScolaire
        //        .Include(e => e.Departements)
        //        .FirstOrDefaultAsync(m => m.AnneeScolaireId == id);

        //    if (schoolYear == null)
        //    {
        //        return NotFound();
        //    }

        //    Debug.WriteLine("Departements in schoolYear:");
        //    foreach (var department in schoolYear.Departements)
        //    {
        //        Debug.WriteLine(department.Nom);
        //    }
        //    return PartialView("_DepartmentsPartial", schoolYear.Departements.ToList());
        //}


        public async Task<IActionResult> YourAction(int? id)
        {
            if (id == null || _context.AnneeScolaire == null)
            {
                return NotFound();
            }

            var schoolYear = await _context.AnneeScolaire
                .Include(e => e.Departements)
                .FirstOrDefaultAsync(m => m.AnneeScolaireId == id);

            if (schoolYear == null)
            {
                return NotFound();
            }

            var viewModel = new SchoolViewModel
            {
                AnneeScolaire = schoolYear,
                Departements = schoolYear.Departements.ToList()
            };
            // Add this for debugging
            Debug.WriteLine($"Number of Departements: {viewModel.Departements.Count}");

            return View(viewModel);
        }



    }
    public class SchoolViewModel
    {
        public AnneeScolaire AnneeScolaire { get; set; }
        public List<Departement> Departements { get; set; }
    }


}
