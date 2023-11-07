using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Controllers
{
    public class TipoApoliceSeguroesController : Controller
    {
        private readonly RovDbContext _context;

        public TipoApoliceSeguroesController(RovDbContext context)
        {
            _context = context;
        }

        // GET: TipoApoliceSeguroes
        public async Task<IActionResult> Index()
        {
              return _context.TipoApoliceSeguro != null ? 
                          View(await _context.TipoApoliceSeguro.ToListAsync()) :
                          Problem("Entity set 'RovDbContext.TipoApoliceSeguro'  is null.");
        }

        // GET: TipoApoliceSeguroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoApoliceSeguro == null)
            {
                return NotFound();
            }

            var tipoApoliceSeguro = await _context.TipoApoliceSeguro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoApoliceSeguro == null)
            {
                return NotFound();
            }

            return View(tipoApoliceSeguro);
        }

        // GET: TipoApoliceSeguroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoApoliceSeguroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTipoApoliceSeguro")] TipoApoliceSeguro tipoApoliceSeguro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoApoliceSeguro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoApoliceSeguro);
        }

        // GET: TipoApoliceSeguroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoApoliceSeguro == null)
            {
                return NotFound();
            }

            var tipoApoliceSeguro = await _context.TipoApoliceSeguro.FindAsync(id);
            if (tipoApoliceSeguro == null)
            {
                return NotFound();
            }
            return View(tipoApoliceSeguro);
        }

        // POST: TipoApoliceSeguroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTipoApoliceSeguro")] TipoApoliceSeguro tipoApoliceSeguro)
        {
            if (id != tipoApoliceSeguro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoApoliceSeguro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoApoliceSeguroExists(tipoApoliceSeguro.Id))
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
            return View(tipoApoliceSeguro);
        }

        // GET: TipoApoliceSeguroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoApoliceSeguro == null)
            {
                return NotFound();
            }

            var tipoApoliceSeguro = await _context.TipoApoliceSeguro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoApoliceSeguro == null)
            {
                return NotFound();
            }

            return View(tipoApoliceSeguro);
        }

        // POST: TipoApoliceSeguroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoApoliceSeguro == null)
            {
                return Problem("Entity set 'RovDbContext.TipoApoliceSeguro'  is null.");
            }
            var tipoApoliceSeguro = await _context.TipoApoliceSeguro.FindAsync(id);
            if (tipoApoliceSeguro != null)
            {
                _context.TipoApoliceSeguro.Remove(tipoApoliceSeguro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoApoliceSeguroExists(int id)
        {
          return (_context.TipoApoliceSeguro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
