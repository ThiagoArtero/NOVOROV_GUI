using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class AnexosChamadosController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly ILogger<AnexosChamado> _logger;

        public AnexosChamadosController(RovDbContext context, ILogger<AnexosChamado> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public FileStreamResult VerImagem(int id)
        {
            AnexosChamado imagem = _context.AnexosChamado.FirstOrDefault(m => m.Id == id);
            MemoryStream ms = new MemoryStream(imagem.Bytes);
            return new FileStreamResult(ms, imagem.ContentType);
        }

        // GET: AnexosChamados
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.AnexosChamado
                .Include(a => a.Autor)
                .Include(a => a.Chamado)
                .Include(a => a.TipoAnexo);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: AnexosChamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnexosChamado == null)
            {
                return NotFound();
            }

            var anexosChamado = await _context.AnexosChamado
                .Include(a => a.Autor)
                .Include(a => a.Chamado)
                .Include(a => a.TipoAnexo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anexosChamado == null)
            {
                return NotFound();
            }

            return View(anexosChamado);
        }

        // GET: AnexosChamados/Create
        public IActionResult Create(int chamadoId)
        {
            ViewBag.ChamadoId = chamadoId;
            //ViewData["AutorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId");
            //ViewData["ChamadoId"] = new SelectList(_context.Chamado, "Id", "Id");
            ViewData["TipoAnexoId"] = new SelectList(_context.TipoAnexo, "Id", "NomeTipoAnexo");
            return View();
        }

        // POST: AnexosChamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnexosChamado anexosChamado, IFormFile postedFile, int chamadoId)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(anexosChamado);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["AutorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", anexosChamado.AutorId);
            //ViewData["ChamadoId"] = new SelectList(_context.Chamado, "Id", "Id", anexosChamado.ChamadoId);
            //ViewData["TipoAnexoId"] = new SelectList(_context.TipoAnexo, "Id", "Id", anexosChamado.TipoAnexoId);
            //return View(anexosChamado);


            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }

            var userId = User.Identity.Name.Split("\\")[1];
           

            try
            {
                byte[] bytes;
                using (BinaryReader binaryReader = new BinaryReader(postedFile.OpenReadStream()))
                {
                    bytes = binaryReader.ReadBytes((int)postedFile.Length);
                }

                var name = Path.GetFileName(postedFile.FileName);
                var contentType = postedFile.ContentType;

                anexosChamado.NomeAnexo = name;
                anexosChamado.AutorId = userId;
                anexosChamado.ContentType = contentType;
                anexosChamado.Bytes = bytes;
                anexosChamado.DataAnexo = DateTime.Now;

                _context.AnexosChamado.Add(anexosChamado);
                await _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Anexo adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction("Edit", "Chamados", new { id = chamadoId });
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao adicionar anexo!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Chamados", new { id = chamadoId });
            }
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            AnexosChamado anexosChamado = _context.AnexosChamado.ToList().Find(p => p.Id == fileId.Value);
            return File(anexosChamado.Bytes, anexosChamado.ContentType, anexosChamado.NomeAnexo);
        }

        // GET: AnexosChamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnexosChamado == null)
            {
                return NotFound();
            }

            var anexosChamado = await _context.AnexosChamado.FindAsync(id);
            if (anexosChamado == null)
            {
                return NotFound();
            }
            //ViewData["AutorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", anexosChamado.AutorId);
            ViewData["ChamadoId"] = new SelectList(_context.Chamado, "Id", "Id", anexosChamado.ChamadoId);
            ViewData["TipoAnexoId"] = new SelectList(_context.TipoAnexo, "Id", "NomeTipoAnexo", anexosChamado.TipoAnexoId);
            return View(anexosChamado);
        }

        // POST: AnexosChamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile postedFile, AnexosChamado anexosChamado, int chamadoId)
        {
            if (id != anexosChamado.Id)
            {
                return NotFound();
            }

            var userId = User.Identity.Name.Split("\\")[1];
            //List<string> IpAndHostname = GetIpAndHostname();


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

                    anexosChamado.NomeAnexo = name;
                    anexosChamado.AutorId = userId;
                    anexosChamado.ContentType = contentType;
                    anexosChamado.Bytes = bytes;
                }

                _context.AnexosChamado.Update(anexosChamado);
                await _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Anexo alterado com sucesso!", notificationType: Notification.success);
                
                return RedirectToAction("Edit", "Chamados", new { id = chamadoId });
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar anexo!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Chamados", new { id = chamadoId });
            }
        }
            // GET: AnexosChamados/Delete/5
        public async Task<IActionResult> Delete(int? id, int chamadoId)
            {
            if (id == null || _context.AnexosChamado == null)
            {
                return NotFound();
            }

            var anexosChamado = await _context.AnexosChamado
                .Include(a => a.Autor)
                .Include(a => a.Chamado)
                .Include(a => a.TipoAnexo)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewBag.ChamadoId = chamadoId;

            if (anexosChamado == null)
            {
                return NotFound();
            }

            return View(anexosChamado);
        }

        // POST: AnexosChamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int chamadoId)
        {
            if (_context.AnexosChamado == null)
            {
                return Problem("Entity set 'RovDbContext.AnexosChamado'  is null.");
            }

            var userId = User.Identity.Name.Split("\\")[1];
            //List<string> IpAndHostname = GetIpAndHostname();

            var anexosChamado = await _context.AnexosChamado.FindAsync(id);
            if (anexosChamado != null)
            {

                try
                {
                    _context.AnexosChamado.Remove(anexosChamado);
                    await _context.SaveChangesAsync();
                    Notify(title: "Ok!", message: "Anexo excluído com sucesso!", notificationType: Notification.success);
                    return RedirectToAction("Edit", "Chamados", new { id = chamadoId });
                }
                catch
                {
                    Notify(title: "Oops!", message: "Erro ao excluir anexo!", notificationType: Notification.warning);
                    return RedirectToAction("Edit", "Chamados", new { id = chamadoId });
                }
            }
            else
            {
                //Notify(title: "Oops!", message: "Anexo não encontrado!", notificationType: Notification.error);
                return RedirectToAction("Edit", "Chamados", new { id = chamadoId });
            }
        }

        private bool AnexosChamadoExists(int id)
        {
          return (_context.AnexosChamado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
