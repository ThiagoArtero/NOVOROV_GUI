using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class AvisosController : BaseController
    {
        private readonly RovDbContext _context;

        public AvisosController(RovDbContext context)
        {
            _context = context;
        }

        // GET: Avisos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aviso.ToListAsync());
        }

        // GET: Avisos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Aviso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aviso == null)
            {
                return NotFound();
            }

            return View(aviso);
        }

        // GET: Avisos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avisos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aviso aviso)
        {
            try
            {
                _context.Add(aviso);
                await _context.SaveChangesAsync();
                Notify("Aviso adicionado com sucesso!", "Sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify("Algo deu errado ao adicionar o aviso");
                return View(aviso);
            }



        }

        // GET: Avisos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Aviso.FindAsync(id);
            if (aviso == null)
            {
                return NotFound();
            }
            return View(aviso);
        }

        // POST: Avisos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aviso aviso)
        {
            if (id != aviso.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(aviso);
                await _context.SaveChangesAsync();
                Notify("Aviso alterado com sucesso!", "Sucesso!", notificationType: Notification.success);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvisoExists(aviso.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            Notify("Algo deu errado ao alterar o aviso");
            return View(aviso);
        }

        // GET: Avisos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviso = await _context.Aviso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aviso == null)
            {
                return NotFound();
            }

            return View(aviso);
        }

        // POST: Avisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aviso = await _context.Aviso.FindAsync(id);
            _context.Aviso.Remove(aviso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvisoExists(int id)
        {
            return _context.Aviso.Any(e => e.Id == id);
        }
    }
}

