using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Controllers
{
    public class PerfilsController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Envolvido> _logger;

        public PerfilsController(RovDbContext context, IConfiguration configuration, ILogger<Envolvido> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: Perfils
        public async Task<IActionResult> Index()
        {
              return _context.Perfil != null ? 
                          View(await _context.Perfil.ToListAsync()) :
                          Problem("Entity set 'RovDbContext.Perfil'  is null.");
        }

        // GET: Perfils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Perfil == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // GET: Perfils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Perfil perfil)
        {
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            try
            {
                _context.Add(perfil);
                await _context.SaveChangesAsync();

                Notify(title: "OK!", message: "Perfil criado com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} criou um novo perfil = {perfil.NomePerfil} ", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                Notify(title: "Oops!", message: "Erro Ao Criar Perfil!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }          
            
        }

        // GET: Perfils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Perfil == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Perfil perfil)
        {
            if (id != perfil.Id)
            {
                return NotFound();
            }

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            try
            {
                _context.Update(perfil);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Perfil alterada com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} editou o perfil {perfil.NomePerfil} ", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction("Edit", "Perfils", new { id = id });
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar ocorrência!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Perfils", new { id = id });
            }
        }

        // GET: Perfils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Perfil == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }
        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Perfil == null)
            {
                return Problem("Entity set 'RovDbContext.Perfil'  is null.");
            }
            var perfil = await _context.Perfil.FindAsync(id);
            if (perfil != null)
            {
                try
                {
                    _context.Perfil.Remove(perfil);
                    Notify(title: "Ok!", message: "Perfil removido com sucesso!", notificationType: Notification.success);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    Notify(title: "Oops!", message: "Erro ao remover perfil!", notificationType: Notification.warning);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                Notify(title: "Oops!", message: "Perfil não encontrado!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

        }

        //// POST: Perfils/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Perfil == null)
        //    {
        //        return Problem("Entity set 'RovDbContext.Perfil'  is null.");
        //    }
        //    var perfil = await _context.Perfil.FindAsync(id);
        //    if (perfil != null)
        //    {
        //        _context.Perfil.Remove(perfil);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool PerfilExists(int id)
        {
          return (_context.Perfil?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
