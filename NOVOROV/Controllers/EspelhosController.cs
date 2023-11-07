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
    public class EspelhosController : BaseController
    {
        private readonly RovDbContext _context;

        public EspelhosController(RovDbContext context)
        {
            _context = context;
        }

        // GET: Espelhos
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Espelho
                .Include(e => e.AnalistaCriador);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: Espelhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Espelho == null)
            {
                return NotFound();
            }

            var espelho = await _context.Espelho
                .Include(e => e.AnalistaCriador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (espelho == null)
            {
                return NotFound();
            }

            return View(espelho);
        }

        // GET: Espelhos/Create
        public IActionResult Create()
        {
            ViewData["AnalistaCriadorId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");
            return View();
        }

        // POST: Espelhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Espelho espelho, IFormFile postedFile)
        {
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

                espelho.AnalistaCriadorId = userId;
                espelho.NomeEspelho = name;
                espelho.Bytes = bytes;
                espelho.ContentType = contentType;
                espelho.DataEspelho = DateTime.Now;
               

                _context.Add(espelho);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Espelho adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar espelho!", notificationType: Notification.error);
                return View();
            }

           
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            Espelho espelho = _context.Espelho.ToList().Find(p => p.Id == fileId.Value);
            return File(espelho.Bytes, espelho.ContentType, espelho.NomeEspelho);
        }

        // GET: Espelhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espelho = await _context.Espelho.FindAsync(id);
            if (espelho == null)
            {
                return NotFound();
            }
            ViewData["AnalistaCriadorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", espelho.AnalistaCriadorId);
            return View(espelho);
        }

        // POST: Espelhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Espelho espelho, IFormFile postedFile)
        {
            if (id != espelho.Id)
            {
                return NotFound();
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

                espelho.AnalistaCriadorId = userId;
                espelho.NomeEspelho = name;
                espelho.Bytes = bytes;
                espelho.ContentType = contentType;
                
               

                _context.Update(espelho);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Espelho alterado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar espelho!", notificationType: Notification.error);
                return View();
            }

        }

        // GET: Espelhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Espelho == null)
            {
                return NotFound();
            }

            var espelho = await _context.Espelho
                .Include(e => e.AnalistaCriador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (espelho == null)
            {
                return NotFound();
            }

            return View(espelho);
        }

        // POST: Espelhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Espelho == null)
            {
                return Problem("Entity set 'RovDbContext.Espelho'  is null.");
            }
            var espelho = await _context.Espelho.FindAsync(id);
            if (espelho != null)
            {
                _context.Espelho.Remove(espelho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspelhoExists(int id)
        {
          return (_context.Espelho?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
