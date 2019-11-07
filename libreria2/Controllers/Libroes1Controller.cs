using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using libreria.Database;
using libreria.Models;

namespace libreria2.Controllers
{
    public class Libroes1Controller : Controller
    {
        private readonly LibreriaDbContext _context;

        public Libroes1Controller(LibreriaDbContext context)
        {
            _context = context;
        }

        // GET: Libroes1
        public async Task<IActionResult> Index()
        {
            var libreriaDbContext = _context.Libros.Include(l => l.Editorial).Include(l => l.Genero);
            return View(await libreriaDbContext.ToListAsync());
        }

        // GET: Libroes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libroes1/Create
        public IActionResult Create()
        {
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "nombre");
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Titulo");
            return View();
        }

        // POST: Libroes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,AnioPublicado,Stock,EditorialId,GeneroId")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "nombre", libro.EditorialId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Titulo", libro.GeneroId);
            return View(libro);
        }

        // GET: Libroes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "nombre", libro.EditorialId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Titulo", libro.GeneroId);
            return View(libro);
        }

        // POST: Libroes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AnioPublicado,Stock,EditorialId,GeneroId")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "nombre", libro.EditorialId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Titulo", libro.GeneroId);
            return View(libro);
        }

        // GET: Libroes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
