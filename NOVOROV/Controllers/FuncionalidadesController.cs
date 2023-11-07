using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;
using Microsoft.IdentityModel.Tokens;
using NOVOROV.DatabaseHelper;

namespace NOVOROV.Controllers
{
    public class FuncionalidadesController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Envolvido> _logger;

        public FuncionalidadesController(RovDbContext context, IConfiguration configuration, ILogger<Envolvido> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: Funcionalidades
        public async Task<IActionResult> Index()
        {

            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "NomePerfil");

            return _context.Funcionalidade != null ?
                        View(await _context.Funcionalidade.ToListAsync()) :
                        Problem("Entity set 'RovDbContext.Funcionalidade'  is null.");
        }

        public IActionResult MenuFuncionalidade()
        {

            return View();
        }


        // GET: Funcionalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionalidade == null)
            {
                return NotFound();
            }

            var funcionalidade = await _context.Funcionalidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionalidade == null)
            {
                return NotFound();
            }

            return View(funcionalidade);
        }

        // GET: Funcionalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionalidade funcionalidade)
        {
            try
            {
                _context.Add(funcionalidade);
                await _context.SaveChangesAsync();

                Notify(title: "OK!", message: "Funcionalidade criada com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro Ao Criar Funcionalidade!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

            //_context.Add(funcionalidade);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));


        }

        // GET: Funcionalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcionalidade == null)
            {
                return NotFound();
            }

            var funcionalidade = await _context.Funcionalidade.FindAsync(id);
            if (funcionalidade == null)
            {
                return NotFound();
            }
            return View(funcionalidade);
        }

        // POST: Funcionalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Funcionalidade funcionalidade)
        {
            if (id != funcionalidade.Id)
            {
                return NotFound();
            }

            var userId = User.Identity.Name.Split("\\")[1];

            try
            {
                _context.Update(funcionalidade);
                Notify(title: "OK!", message: "Funcionalidade alterada com sucesso!", notificationType: Notification.success);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "Funcionalidades", new { id = id });
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar ocorrência!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Funcionalidades", new { id = id });
            }

        }

        // GET: Funcionalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionalidade == null)
            {
                return NotFound();
            }

            var funcionalidade = await _context.Funcionalidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionalidade == null)
            {
                return NotFound();
            }

            return View(funcionalidade);
        }


        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionalidade == null)
            {
                return Problem("Entity set 'RovDbContext.Funcionalidade'  is null.");
            }
            var funcionalidade = await _context.Funcionalidade.FindAsync(id);
            if (funcionalidade != null)
            {
                try
                {
                    _context.Funcionalidade.Remove(funcionalidade);
                    Notify(title: "Ok!", message: "funcionalidade removida com sucesso!", notificationType: Notification.success);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    Notify(title: "Oops!", message: "Erro ao remover funcionalidade!", notificationType: Notification.warning);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                Notify(title: "Oops!", message: "Funcionalidade não encontrado!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

        }

        private bool FuncionalidadeExists(int id)
        {
            return (_context.Funcionalidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //GET
        public async Task<IActionResult> AtribuicaoFuncionalidade()
        {

            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "NomePerfil");

            return _context.Funcionalidade != null ?
                        View(await _context.Funcionalidade.ToListAsync()) :
                        Problem("Entity set 'RovDbContext.Funcionalidade'  is null.");
        }

        [HttpPost]
        public JsonResult AtribuicaoFuncionalidade(int funcionalidadeId, int perfilId)
        {
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var verificacaoSeExisteItem = _context.PerfilFuncionalidade.Where(t => t.FuncionalidadeId == funcionalidadeId && t.PerfilId == perfilId).Select(t => t.Id).FirstOrDefault();

            string query = "";

            if (verificacaoSeExisteItem == 0)
            {
                query = $"INSERT INTO PerfilFuncionalidade(FuncionalidadeId, PerfilId) Values({funcionalidadeId}, {perfilId}) ";
            }          

            var database = new Database(_configuration);

            try
            {
                database.ExecuteQuery(query);
                Notify(title: "Ok!", message: "Funcionalidades atribuídas com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} atribuiu nova funcionalidade para o perfil {perfilId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return new JsonResult(Ok());
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao atribuir funcionalidades!", notificationType: Notification.error);
                return new JsonResult(Ok());
            }
            
        }

        public async Task<IActionResult> AtribuicaoUsuarioFuncionalidade()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");

            return _context.Funcionalidade != null ?
                        View(await _context.Funcionalidade.ToListAsync()) :
                        Problem("Entity set 'RovDbContext.Funcionalidade'  is null.");
        }

        [HttpPost]
        public void AtribuicaoUsuarioFuncionalidade(int funcionalidadeId, string usuarioId)
        {

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var verificacaoSeExisteItem = _context.UsuarioFuncionalidade.Where(t => t.FuncionalidadeId == funcionalidadeId && t.UsuarioId == usuarioId).Select(t => t.Id).FirstOrDefault();

            string query = "";

            if (verificacaoSeExisteItem == 0)
            {
                query = $"INSERT INTO UsuarioFuncionalidade(FuncionalidadeId, UsuarioId) Values({funcionalidadeId}, '{usuarioId}') ";
            }

            var database = new Database(_configuration);

            try
            {
                database.ExecuteQuery(query);
                Notify(title: "Ok!", message: "Funcionalidades atribuídas com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} atribuiu nova funcionalidade para o usuário {usuarioId}", userId, IpAndHostname[0], IpAndHostname[1]);
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao atribuir funcionalidades!", notificationType: Notification.error);
                
            }
        }

        public IActionResult Encaminhar()
        {
            Notify(title: "Ok!", message: "Funcionalidades atribuídas com sucesso!", notificationType: Notification.success);
            return RedirectToAction("AtribuicaoFuncionalidade", "Funcionalidades");
        }

        public IActionResult EncaminharParaUsuarioFuncionalidade()
        {
            Notify(title: "Ok!", message: "Funcionalidades atribuídas com sucesso!", notificationType: Notification.success);
            return RedirectToAction("AtribuicaoUsuarioFuncionalidade", "Funcionalidades");
        }

    }
}
