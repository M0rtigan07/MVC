using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;



namespace MVC.Controllers
{
    public class PelisController : Controller
    {
        private readonly MVCContext _context;

        public PelisController(MVCContext context)
        {
            _context = context;
        }

        // GET: Pelis
        public async Task<IActionResult> Index( string cadenaBusqueda)
        {
            var v_pelis = from m in _context.Peli
                          select m;
            v_pelis = _context.Peli.Include(c => c.Genero);
            if (!String.IsNullOrEmpty(cadenaBusqueda))
            {
                v_pelis = v_pelis.Where(s => s.Titulo.Contains(cadenaBusqueda));
            }
            return View(await v_pelis.ToListAsync());
        }

        // GET: Pelis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peli = await _context.Peli
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli == null)
            {
                return NotFound();
            }

            return View(peli);
        }

        // GET: Pelis/Create
        public IActionResult Create()
        {
            ViewData["GeneroID"] = new SelectList(_context.Genero, "ID", "Descripcion");
            return View();
        }

        // POST: Pelis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Peli peli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroID"] = new SelectList(_context.Genero, "ID","Descripcion");
            return View(peli);
        }

        // GET: Pelis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peli = await _context.Peli.FindAsync(id);
            if (peli == null)
            {
                return NotFound();
            }
            ViewData["GeneroID"] = new SelectList(_context.Genero, "ID", "Descripcion");
            return View(peli);
        }

        // POST: Pelis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,FechaEstreno,Genero,Precio,Clasificacion")] Peli peli)
        {
            if (id != peli.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliExists(peli.ID))
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
            return View(peli);
        }

        // GET: Pelis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peli = await _context.Peli
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli == null)
            {
                return NotFound();
            }

            return View(peli);
        }

        // POST: Pelis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peli = await _context.Peli.FindAsync(id);
            _context.Peli.Remove(peli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliExists(int id)
        {
            return _context.Peli.Any(e => e.ID == id);
        }

    }
}
