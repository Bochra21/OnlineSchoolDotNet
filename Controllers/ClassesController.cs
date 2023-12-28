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
    public class ClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Classe.Include(c => c.Niveau);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classe == null)
            {
                return NotFound();
            }

            var classe = await _context.Classe
                .Include(c => c.Niveau)
                .FirstOrDefaultAsync(m => m.ClasseId == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            ViewData["NiveauId"] = new SelectList(_context.Niveau, "NiveauId", "NiveauId");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasseId,Nom,NiveauId")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NiveauId"] = new SelectList(_context.Niveau, "NiveauId", "NiveauId", classe.NiveauId);
            return View(classe);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classe == null)
            {
                return NotFound();
            }

            var classe = await _context.Classe.FindAsync(id);
            if (classe == null)
            {
                return NotFound();
            }
            ViewData["NiveauId"] = new SelectList(_context.Niveau, "NiveauId", "NiveauId", classe.NiveauId);
            return View(classe);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasseId,Nom,NiveauId")] Classe classe)
        {
            if (id != classe.ClasseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseExists(classe.ClasseId))
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
            ViewData["NiveauId"] = new SelectList(_context.Niveau, "NiveauId", "NiveauId", classe.NiveauId);
            return View(classe);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classe == null)
            {
                return NotFound();
            }

            var classe = await _context.Classe
                .Include(c => c.Niveau)
                .FirstOrDefaultAsync(m => m.ClasseId == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classe == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Classe'  is null.");
            }
            var classe = await _context.Classe.FindAsync(id);
            if (classe != null)
            {
                _context.Classe.Remove(classe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseExists(int id)
        {
          return (_context.Classe?.Any(e => e.ClasseId == id)).GetValueOrDefault();
        }
    }
}
