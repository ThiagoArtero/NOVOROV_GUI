using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class PassivosController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly ILogger<Envolvido> _logger;

        public PassivosController(RovDbContext context, ILogger<Envolvido> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Passivos
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Passivo
                .Include(p => p.AreaInterna)
                .Include(p => p.Empresa)
                .Include(p => p.Perda)
                .Include(p => p.TipoRessarcimento);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: Passivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passivo == null)
            {
                return NotFound();
            }

            var passivo = await _context.Passivo
                .Include(p => p.AreaInterna)
                .Include(p => p.Empresa)
                .Include(p => p.Perda)
                .Include(p => p.TipoRessarcimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passivo == null)
            {
                return NotFound();
            }

            return View(passivo);
        }

        // GET: Passivos/Create
        public IActionResult Create(int perdaId)
        {
            ViewBag.Perda = perdaId;
            ViewData["AreaInternaId"] = new SelectList(_context.AreaInterna, "Id", "NomeAreaInterna");
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "NomeEmpresa");
            ViewData["TipoRessarcimentoId"] = new SelectList(_context.TipoRessarcimento, "Id", "NomeTipoRessarcimento");
            return View();
        }

        // POST: Passivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Passivo passivo, int perdaId, int ocorrenciaId)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }

            Perda perda = await _context.Perda
                .Where(p => p.Id == perdaId).FirstOrDefaultAsync();

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            //Soma para a tabela Total em perdas
            perda.TotalPassivo += passivo.ValorPassivo;
            perda.TotalRecuperadoPassivo += passivo.ValorRecuperadoPassivo;
            _context.Update(perda);

            passivo.PerdaId = perdaId;

            try
            {
                _context.Add(passivo);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Passivo adicionado com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} adicionou um novo passivo na perda {passivo.PerdaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction("Edit", "Perdas", new { id = perdaId });
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar passivo!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Perdas", new { id = perdaId });
            }

        }

        // GET: Passivos/Edit/5
        public async Task<IActionResult> Edit(int? id, int perdaId)
        {
            if (id == null || _context.Passivo == null)
            {
                return NotFound();
            }

            ViewBag.PerdaId = perdaId;

            var passivo = await _context.Passivo.FindAsync(id);
            if (passivo == null)
            {
                return NotFound();
            }
            ViewData["AreaInternaId"] = new SelectList(_context.AreaInterna, "Id", "NomeAreaInterna", passivo.AreaInternaId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "NomeEmpresa", passivo.EmpresaId);
            ViewData["TipoRessarcimentoId"] = new SelectList(_context.TipoRessarcimento, "Id", "NomeTipoRessarcimento", passivo.TipoRessarcimentoId);
            return View(passivo);
        }

        // POST: Passivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Passivo passivo)
        {
            if (id != passivo.Id)
            {
                return NotFound();
            }

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            try
            {
                _context.Update(passivo);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Passivo alterado com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} editou o passivo {passivo.Id} na perda {passivo.PerdaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar passivo!", notificationType: Notification.warning);

                return RedirectToAction(nameof(Index));
            }

        }

        // GET: Passivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passivo == null)
            {
                return NotFound();
            }

            var passivo = await _context.Passivo
                .Include(p => p.AreaInterna)
                .Include(p => p.Empresa)
                .Include(p => p.Perda)
                .Include(p => p.TipoRessarcimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passivo == null)
            {
                return NotFound();
            }

            return View(passivo);
        }

        // POST: Passivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passivo == null)
            {
                return Problem("Entity set 'RovDbContext.Passivo'  is null.");
            }

            var passivo = await _context.Passivo.FindAsync(id);

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            Perda perda = await _context.Perda
                .Where(p => p.Id == passivo.PerdaId).FirstOrDefaultAsync();

            //Soma para a tabela Total em perdas
            perda.TotalPassivo -= passivo.ValorPassivo;
            perda.TotalRecuperadoPassivo -= passivo.ValorRecuperadoPassivo;
            _context.Update(perda);


            if (passivo != null)
            {
                try
                {
                    _context.Passivo.Remove(passivo);
                    await _context.SaveChangesAsync();
                    Notify(title: "OK!", message: "Passivo deletado com sucesso!", notificationType: Notification.success);
                    _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} excluiu o passivo {passivo.Id} na perda {passivo.PerdaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    Notify(title: "Oops!", message: "Erro ao alterar passivo!", notificationType: Notification.warning);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                Notify(title: "Oops!", message: "Passivo não encontrado!", notificationType: Notification.error);
                return RedirectToAction(nameof(Index));
            }
        }

        private bool PassivoExists(int id)
        {
            return (_context.Passivo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
