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
    public class UsuariosController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly ILogger<Envolvido> _logger;

        public UsuariosController(RovDbContext context, ILogger<Envolvido> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = _context.Usuario
                .Include(u => u.Perfil)
                .Include(u => u.Gestor)
                .ToListAsync();
            return View(await usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        
        {
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "NomePerfil");
            ViewData["CmcId"] = new SelectList(_context.Cmc, "Id", "NomeCmc");
            ViewData["GestorId"] = new SelectList(_context.Gestor, "Id", "NomeGestor");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            try
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Usuário criado com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} adicionou um novo usuário = {usuario.NomeUsuario} com matrícula {usuario.UsuarioId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao adicionar usuário!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "NomePerfil", usuario.PerfilId);
            ViewData["CmcId"] = new SelectList(_context.Cmc, "Id", "NomeCmc", usuario.CmcId);
            ViewData["GestorId"] = new SelectList(_context.Gestor, "Id", "NomeGestor", usuario.GestorId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                Notify(title: "Oops!", message: "Usuário não encontrado!", notificationType: Notification.error);
                return NotFound();
            }

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Usuário alterado com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} editou o usuário com a matrícula {usuario.UsuarioId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar usuário!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Perfil)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'RovDbContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            if (usuario != null)
            {
                try
                {
                    _context.Usuario.Remove(usuario);
                    await _context.SaveChangesAsync();
                    Notify(title: "Ok!", message: "Usuário removido com sucesso!", notificationType: Notification.success);
                    _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} removeu o usuário {usuario.UsuarioId} ", userId, IpAndHostname[0], IpAndHostname[1]);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    Notify(title: "Oops!", message: "Erro ao remover usuário!", notificationType: Notification.warning);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                Notify(title: "Oops!", message: "Usuário não encontrado!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }

        public JsonResult GetFuncionalidades(string id)
        {
            var item = _context.UsuarioFuncionalidade.Where(p => p.UsuarioId == id).Select(p => p.Funcionalidade.NomeFuncionalidade).ToList();
            var descricao = _context.UsuarioFuncionalidade.Where(p => p.UsuarioId == id).Select(p => p.Funcionalidade.DescricaoFuncionalidade).ToList();
            var idRelacao = _context.UsuarioFuncionalidade.Where(p => p.UsuarioId == id).Select(p => p.Id).ToList();

            return Json(new { funcionalidade = item, descricao, idRelacao });
        }

        public async Task<ActionResult> DeleteUsuarioFuncionalidadeAtribuida(int id)
        {
            //var usuario = await _context.Usuario.FindAsync(id);

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var usuarioFuncionalidade = await _context.UsuarioFuncionalidade.FindAsync(id);
            if (usuarioFuncionalidade != null)
            {
                _context.UsuarioFuncionalidade.Remove(usuarioFuncionalidade);
            }
            await _context.SaveChangesAsync();

            _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} removeu uma funcionalidade", userId, IpAndHostname[0], IpAndHostname[1]);

            return RedirectToAction(nameof(Index));
        }
    }
}
