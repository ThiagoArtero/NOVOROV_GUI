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
    public class AnexosController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly ILogger<Anexo> _logger;

        public AnexosController(RovDbContext context, ILogger<Anexo> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Anexos
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Anexo
                .Include(a => a.Ocorrencia)
                .Include(a => a.TipoAnexo)
                .Include(a => a.Autor);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: Anexos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anexo == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexo
                .Include(a => a.Ocorrencia)
                .Include(a => a.TipoAnexo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anexo == null)
            {
                return NotFound();
            }

            return View(anexo);
        }

        // GET: Anexos/Create
        public IActionResult Create(int ocorrenciaId)
        {
            ViewBag.OcorrenciaId = ocorrenciaId;
            ViewData["TipoAnexoId"] = new SelectList(_context.TipoAnexo, "Id", "NomeTipoAnexo");
            return View();
        }

        // POST: Anexos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Anexo anexo, IFormFile postedFile, int ocorrenciaId)
        {

            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }
            
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            try
            {
                byte[] bytes;
                using (BinaryReader binaryReader = new BinaryReader(postedFile.OpenReadStream()))
                {
                    bytes = binaryReader.ReadBytes((int)postedFile.Length);
                }

                var name = Path.GetFileName(postedFile.FileName);
                var contentType = postedFile.ContentType;

                anexo.NomeAnexo = name;
                anexo.AutorId = userId;
                anexo.ContentType = contentType;
                anexo.Bytes = bytes;
                anexo.DataAnexo = DateTime.Now;

                _context.Anexo.Add(anexo);
                await _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Anexo adicionado com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} adicionou um anexo na ocorrência {anexo.OcorrenciaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao adicionar anexo!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            Anexo anexo = _context.Anexo.ToList().Find(p => p.Id == fileId.Value);
            return File(anexo.Bytes, anexo.ContentType, anexo.NomeAnexo);
        }

        // GET: Anexos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anexo == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexo.FindAsync(id);
            if (anexo == null)
            {
                return NotFound();
            }
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencia, "Id", "Id", anexo.OcorrenciaId);
            ViewData["TipoAnexoId"] = new SelectList(_context.TipoAnexo, "Id", "NomeTipoAnexo", anexo.TipoAnexoId);
            return View(anexo);
        }

        // POST: Anexos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile postedFile, Anexo anexo, int ocorrenciaId)
        {
            if (id != anexo.Id)
            {
                return NotFound();
            }

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            try
            {
                if (postedFile != null)
                {
                    byte[] bytes;
                    using (BinaryReader binaryReader = new BinaryReader(postedFile.OpenReadStream()))
                    {
                        bytes = binaryReader.ReadBytes((int)postedFile.Length);
                    }

                    var name = Path.GetFileName(postedFile.FileName);
                    var contentType = postedFile.ContentType;

                    anexo.NomeAnexo = name;
                    anexo.AutorId = userId;
                    anexo.ContentType = contentType;
                    anexo.Bytes = bytes;
                }

                    _context.Anexo.Update(anexo);
                    await _context.SaveChangesAsync();
                    Notify(title: "Ok!", message: "Anexo alterado com sucesso!", notificationType: Notification.success);
                    _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} editou o anexo {anexo.Id} na ocorrência {anexo.OcorrenciaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                    return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar anexo!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }

        }

        // GET: Anexos/Delete/5
        public async Task<IActionResult> Delete(int? id, int ocorrenciaId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anexo = await _context.Anexo
                .Include(a => a.Ocorrencia)
                .Include(a => a.TipoAnexo)
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewBag.OcorrenciaId = ocorrenciaId;

            if (anexo == null)
            {
                return NotFound();
            }

            return View(anexo);
        }

        // POST: Anexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int ocorrenciaId)
        {
            if (_context.Anexo == null)
            {
                return Problem("Entity set 'RovDbContext.Anexo'  is null.");
            }

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var anexo = await _context.Anexo.FindAsync(id);
            if (anexo != null)
            {
                try
                {
                    _context.Anexo.Remove(anexo);
                    await _context.SaveChangesAsync();
                    Notify(title: "Ok!", message: "Anexo excluído com sucesso!", notificationType: Notification.success);
                    _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} excluiu o anexo {anexo.Id} na ocorrência {anexo.OcorrenciaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                    return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
                }
                catch
                {
                    Notify(title: "Oops!", message: "Erro ao excluir anexo!", notificationType: Notification.warning);
                    _logger.LogWarning($"{userId}, erro ao adicionar anexo na ocorrência {ocorrenciaId}");
                    return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
                }
            }
            else
            {
                Notify(title: "Oops!", message: "Anexo não encontrado!", notificationType: Notification.error);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }
        }

        private bool AnexoExists(int id)
        {
          return (_context.Anexo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
