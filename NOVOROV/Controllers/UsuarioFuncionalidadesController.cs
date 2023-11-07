using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class UsuarioFuncionalidadesController : Controller
    {
        private readonly RovDbContext _context;

        public UsuarioFuncionalidadesController(RovDbContext context)
        {
            _context = context;
        }

        // GET: UsuarioFuncionalidades
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.UsuarioFuncionalidade.Include(u => u.Funcionalidade).Include(u => u.Usuario);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: UsuarioFuncionalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuarioFuncionalidade == null)
            {
                return NotFound();
            }

            var usuarioFuncionalidade = await _context.UsuarioFuncionalidade
                .Include(u => u.Funcionalidade)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioFuncionalidade == null)
            {
                return NotFound();
            }

            return View(usuarioFuncionalidade);
        }

        // GET: UsuarioFuncionalidades/Create
        public IActionResult Create()
        {
            ViewData["FuncionalidadeId"] = new SelectList(_context.Funcionalidade, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: UsuarioFuncionalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FuncionalidadeId,UsuarioId")] UsuarioFuncionalidade usuarioFuncionalidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioFuncionalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionalidadeId"] = new SelectList(_context.Funcionalidade, "Id", "Id", usuarioFuncionalidade.FuncionalidadeId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", usuarioFuncionalidade.UsuarioId);
            return View(usuarioFuncionalidade);
        }

        // GET: UsuarioFuncionalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuarioFuncionalidade == null)
            {
                return NotFound();
            }

            var usuarioFuncionalidade = await _context.UsuarioFuncionalidade.FindAsync(id);
            if (usuarioFuncionalidade == null)
            {
                return NotFound();
            }
            ViewData["FuncionalidadeId"] = new SelectList(_context.Funcionalidade, "Id", "Id", usuarioFuncionalidade.FuncionalidadeId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", usuarioFuncionalidade.UsuarioId);
            return View(usuarioFuncionalidade);
        }

        // POST: UsuarioFuncionalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FuncionalidadeId,UsuarioId")] UsuarioFuncionalidade usuarioFuncionalidade)
        {
            if (id != usuarioFuncionalidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioFuncionalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioFuncionalidadeExists(usuarioFuncionalidade.Id))
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
            ViewData["FuncionalidadeId"] = new SelectList(_context.Funcionalidade, "Id", "Id", usuarioFuncionalidade.FuncionalidadeId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", usuarioFuncionalidade.UsuarioId);
            return View(usuarioFuncionalidade);
        }

        // GET: UsuarioFuncionalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuarioFuncionalidade == null)
            {
                return NotFound();
            }

            var usuarioFuncionalidade = await _context.UsuarioFuncionalidade
                .Include(u => u.Funcionalidade)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioFuncionalidade == null)
            {
                return NotFound();
            }

            return View(usuarioFuncionalidade);
        }

        // POST: UsuarioFuncionalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuarioFuncionalidade == null)
            {
                return Problem("Entity set 'RovDbContext.UsuarioFuncionalidade'  is null.");
            }
            var usuarioFuncionalidade = await _context.UsuarioFuncionalidade.FindAsync(id);
            if (usuarioFuncionalidade != null)
            {
                _context.UsuarioFuncionalidade.Remove(usuarioFuncionalidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioFuncionalidadeExists(int id)
        {
          return (_context.UsuarioFuncionalidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
