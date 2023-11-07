using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NOVOROV.Context;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class EnvolvidosController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly ILogger<Envolvido> _logger;

        public EnvolvidosController(RovDbContext context, ILogger<Envolvido> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Envolvidos
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Envolvido.Include(e => e.AcaoTomada).Include(e => e.Ocorrencia).Include(e => e.TipoEnvolvimento);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: Envolvidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Envolvido == null)
            {
                return NotFound();
            }

            var envolvido = await _context.Envolvido
                .Include(e => e.AcaoTomada)
                .Include(e => e.Ocorrencia)
                .Include(e => e.TipoEnvolvimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (envolvido == null)
            {
                return NotFound();
            }

            return View(envolvido);
        }

        // GET: Envolvidos/Create
        public IActionResult Create(int ocorrenciaId)
        {
            ViewBag.OcorrenciaId = ocorrenciaId;
            ViewData["AcaoTomadaId"] = new SelectList(_context.AcaoTomada, "Id", "NomeAcaoTomada");
            ViewData["TipoEnvolvimentoId"] = new SelectList(_context.TipoEnvolvimento, "Id", "NomeTipoEnvolvimento");
            return View();
        }

        // POST: Envolvidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Envolvido envolvido, int ocorrenciaId)
        {
            //Validação se é reincidente
            var cpfsCadastrados = _context.Envolvido
                .Select(e => e.CPF == envolvido.CPF)
                .FirstOrDefault();

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            if (cpfsCadastrados != false)
            {
                envolvido.Reincidente = true;
            }
            else
            {
                envolvido.Reincidente = false;
            }

            try
            {
                _context.Add(envolvido);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Envolvido adicionado com sucesso!", notificationType: Notification.success);

                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}" , $"{userId} adicionou um novo envolvido na ocorrência {ocorrenciaId}",userId, IpAndHostname[0], IpAndHostname[1], "teste");
                
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar envolvido!", notificationType: Notification.warning);
                _logger.LogError("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} tentou adicionar uma ocorrência e deu erro", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }
        }

        // GET: Envolvidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Envolvido == null)
            {
                return NotFound();
            }

            var envolvido = await _context.Envolvido.FindAsync(id);
            if (envolvido == null)
            {
                return NotFound();
            }

            if (envolvido.Reincidente == true)
            {
                TempData["Reincidente"] = "Sim";
            }
            else
            {
                TempData["Reincidente"] = "Não";
            }

            ViewData["AcaoTomadaId"] = new SelectList(_context.AcaoTomada, "Id", "NomeAcaoTomada", envolvido.AcaoTomadaId);
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencia, "Id", "Id", envolvido.OcorrenciaId);
            ViewData["TipoEnvolvimentoId"] = new SelectList(_context.TipoEnvolvimento, "Id", "NomeTipoEnvolvimento", envolvido.TipoEnvolvimentoId);
            return View(envolvido);
        }

        // POST: Envolvidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Envolvido envolvido)
        {
            if (id != envolvido.Id)
            {
                return NotFound();
            }

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            try
            {
                _context.Update(envolvido);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Envolvido alterado com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} editou o envolvido de Id = {envolvido.Id} na ocorrência {envolvido.OcorrenciaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return View(envolvido);
            }
            catch (DbUpdateConcurrencyException)
            {
                Notify(title: "Oops!", message: "Erro ao adicionar envolvido!", notificationType: Notification.warning);
                return View(envolvido);
            }
        }

        // GET: Envolvidos/Delete/5
        public async Task<IActionResult> Delete(int? id, int ocorrenciaId)
        {
            if (id == null || _context.Envolvido == null)
            {
                return NotFound();
            }

            var envolvido = await _context.Envolvido
                .Include(e => e.AcaoTomada)
                .Include(e => e.Ocorrencia)
                .Include(e => e.TipoEnvolvimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (envolvido == null)
            {
                return NotFound();
            }

            return View(envolvido);
        }

        // POST: Envolvidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int ocorrenciaId)
        {
            if (_context.Envolvido == null)
            {
                return Problem("Entity set 'RovDbContext.Envolvido'  is null.");
            }
            var envolvido = await _context.Envolvido.FindAsync(id);
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            if (envolvido != null)
            {
                try
                {
                    _context.Envolvido.Remove(envolvido);
                    await _context.SaveChangesAsync();
                    Notify(title: "OK!", message: "Envolvido removido com sucesso!", notificationType: Notification.success);
                    _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} excluiu um envolvido com Id = {envolvido.OcorrenciaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                    return RedirectToAction("Edit", "Ocorrencias", new { id = envolvido.OcorrenciaId });
                }
                catch
                {
                    Notify(title: "Oops!", message: "Erro ao remover envolvido!", notificationType: Notification.warning);
                    return RedirectToAction("Edit", "Ocorrencias", new { id = envolvido.OcorrenciaId });
                }

            }
            else
            {
                Notify(title: "Oops!", message: "Envolvido não encontrado!", notificationType: Notification.error);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }

        }

        private bool EnvolvidoExists(int id)
        {
            return (_context.Envolvido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
