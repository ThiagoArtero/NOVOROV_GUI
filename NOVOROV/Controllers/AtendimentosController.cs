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
    public class AtendimentosController : Controller
    {
        private readonly RovDbContext _context;

        public AtendimentosController(RovDbContext context)
        {
            _context = context;
        }

        // GET: Atendimentos
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Atendimento
                .Include(a => a.Chamado)
                .Include(a => a.StatusAtendimentoChamado)
                .Include(a => a.UsuarioResposta)
                .Include(a => a.StatusChamado);
            return View(await rovDbContext.ToListAsync());
        }


        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            Atendimento atendimento = _context.Atendimento.ToList().Find(p => p.Id == fileId.Value);
            return File(atendimento.Bytes, atendimento.ContentType, atendimento.NomeAnexoAtendimento);
        }

        // GET: Atendimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atendimento == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .Include(a => a.Chamado)
                .Include(a => a.StatusAtendimentoChamado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // GET: Atendimentos/Create
        public IActionResult Create()
        {
            ViewData["ChamadoId"] = new SelectList(_context.Chamado, "Id", "Id");
            ViewData["StatusAtendimentoChamadoId"] = new SelectList(_context.StatusAtendimentoChamado, "Id", "Id");
            return View();
        }

        // POST: Atendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChamadoId,Resposta,StatusAtendimentoChamadoId")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChamadoId"] = new SelectList(_context.Chamado, "Id", "Id", atendimento.ChamadoId);
            ViewData["StatusAtendimentoChamadoId"] = new SelectList(_context.StatusAtendimentoChamado, "Id", "Id", atendimento.StatusAtendimentoChamadoId);
            return View(atendimento);
        }

        // GET: Atendimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atendimento == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            ViewData["ChamadoId"] = new SelectList(_context.Chamado, "Id", "Id", atendimento.ChamadoId);
            ViewData["StatusAtendimentoChamadoId"] = new SelectList(_context.StatusAtendimentoChamado, "Id", "Id", atendimento.StatusAtendimentoChamadoId);
            return View(atendimento);
        }

        // POST: Atendimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChamadoId,Resposta,StatusAtendimentoChamadoId")] Atendimento atendimento)
        {
            if (id != atendimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.Id))
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
            ViewData["ChamadoId"] = new SelectList(_context.Chamado, "Id", "Id", atendimento.ChamadoId);
            ViewData["StatusAtendimentoChamadoId"] = new SelectList(_context.StatusAtendimentoChamado, "Id", "Id", atendimento.StatusAtendimentoChamadoId);
            return View(atendimento);
        }

        // GET: Atendimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atendimento == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .Include(a => a.Chamado)
                .Include(a => a.StatusAtendimentoChamado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // POST: Atendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atendimento == null)
            {
                return Problem("Entity set 'RovDbContext.Atendimento'  is null.");
            }
            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento != null)
            {
                _context.Atendimento.Remove(atendimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoExists(int id)
        {
          return (_context.Atendimento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
