using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pharmacie_ami_salah.Data;
using pharmacie_ami_salah.Models;

namespace pharmacie_ami_salah.Controllers
{
    public class CommandesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommandesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commandes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Commandes.Include(c => c.produit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Commandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Commandes == null)
            {
                return NotFound();
            }

            var commandes = await _context.Commandes
                .Include(c => c.produit)
                .FirstOrDefaultAsync(m => m.Id_commande == id);
            if (commandes == null)
            {
                return NotFound();
            }

            return View(commandes);
        }

        // GET: Commandes/Create
        public IActionResult Create()
        {
            ViewData["Id_produit"] = new SelectList(_context.Produits, "id_prod", "id_prod");
            return View();
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_commande,Id_produit")] Commandes commandes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commandes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_produit"] = new SelectList(_context.Produits, "id_prod", "id_prod", commandes.Id_produit);
            return View(commandes);
        }

        // GET: Commandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Commandes == null)
            {
                return NotFound();
            }

            var commandes = await _context.Commandes.FindAsync(id);
            if (commandes == null)
            {
                return NotFound();
            }
            ViewData["Id_produit"] = new SelectList(_context.Produits, "id_prod", "id_prod", commandes.Id_produit);
            return View(commandes);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_commande,Id_produit")] Commandes commandes)
        {
            if (id != commandes.Id_commande)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commandes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandesExists(commandes.Id_commande))
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
            ViewData["Id_produit"] = new SelectList(_context.Produits, "id_prod", "id_prod", commandes.Id_produit);
            return View(commandes);
        }

        // GET: Commandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Commandes == null)
            {
                return NotFound();
            }

            var commandes = await _context.Commandes
                .Include(c => c.produit)
                .FirstOrDefaultAsync(m => m.Id_commande == id);
            if (commandes == null)
            {
                return NotFound();
            }

            return View(commandes);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Commandes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Commandes'  is null.");
            }
            var commandes = await _context.Commandes.FindAsync(id);
            if (commandes != null)
            {
                _context.Commandes.Remove(commandes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandesExists(int id)
        {
          return (_context.Commandes?.Any(e => e.Id_commande == id)).GetValueOrDefault();
        }
    }
}
