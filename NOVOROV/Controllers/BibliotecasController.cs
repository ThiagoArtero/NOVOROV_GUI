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
    public class BibliotecasController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly ILogger<Biblioteca> _logger;

        public BibliotecasController(RovDbContext context, ILogger<Biblioteca> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Bibliotecas
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Biblioteca
                .Include(b => b.AnalistaSolicitante)
                .Include(b => b.TipoBiblioteca);
            //.Include(a => a.AnalistaSolicitante);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: Bibliotecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca
                .Include(b => b.TipoBiblioteca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // GET: Bibliotecas/Create
        public IActionResult Create()
        {
            ViewData["TipoBibliotecaId"] = new SelectList(_context.TipoBiblioteca, "Id", "NomeTipoBiblioteca");
            return View();
        }

        // POST: Bibliotecas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Biblioteca biblioteca, IFormFile postedFile)
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

                biblioteca.AnalistaSolicitanteId = userId;
                biblioteca.Bytes = bytes;
                biblioteca.ContentType = contentType;
                biblioteca.DataAtualizacao = DateTime.Now;
                biblioteca.NomeAnexo = name;

                _context.Add(biblioteca);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Biblioteca adicionada com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} criou uma nova biblioteca com Id = {biblioteca.Id}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar biblioteca!", notificationType: Notification.error);
                return View();
            }
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            Biblioteca biblioteca = _context.Biblioteca.ToList().Find(p => p.Id == fileId.Value);
            return File(biblioteca.Bytes, biblioteca.ContentType, biblioteca.NomeAnexo);
        }

        // GET: Bibliotecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca.FindAsync(id);
            if (biblioteca == null)
            {
                return NotFound();
            }
            ViewData["TipoBibliotecaId"] = new SelectList(_context.TipoBiblioteca, "Id", "NomeTipoBiblioteca", biblioteca.TipoBibliotecaId);
            return View(biblioteca);
        }

        // POST: Bibliotecas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Biblioteca biblioteca, IFormFile postedFile)
        {
            if (id != biblioteca.Id)
            {
                return NotFound();
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

                biblioteca.AnalistaSolicitanteId = userId;
                biblioteca.Bytes = bytes;
                biblioteca.ContentType = contentType;
                biblioteca.DataAtualizacao = DateTime.Now;
                biblioteca.NomeAnexo = name;

                _context.Update(biblioteca);
                await _context.SaveChangesAsync();
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} editou a biblioteca com Id = {biblioteca.Id}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Bibliotecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biblioteca = await _context.Biblioteca
                .Include(b => b.TipoBiblioteca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // POST: Bibliotecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Biblioteca == null)
            {
                return Problem("Entity set 'RovDbContext.Biblioteca'  is null.");
            }

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var biblioteca = await _context.Biblioteca.FindAsync(id);
            if (biblioteca != null)
            {
                _context.Biblioteca.Remove(biblioteca);
            }
            await _context.SaveChangesAsync();
            _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} excluiu a biblioteca com Id = {biblioteca.Id}", userId, IpAndHostname[0], IpAndHostname[1]);
            return RedirectToAction(nameof(Index));
        }

        private bool BibliotecaExists(int id)
        {
            return (_context.Biblioteca?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
