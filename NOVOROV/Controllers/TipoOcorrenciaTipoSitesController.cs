using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NOVOROV.Context;
using NOVOROV.DatabaseHelper;
using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Controllers
{
    public class TipoOcorrenciaTipoSitesController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Envolvido> _logger;


        public TipoOcorrenciaTipoSitesController(RovDbContext context, IConfiguration configuration, ILogger<Envolvido> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: TipoOcorrenciaTipoSites
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.TipoOcorrenciaTipoSite
                .Include(t => t.TipoOcorrencia)
                .Include(t => t.TipoSite);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: TipoOcorrenciaTipoSites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoOcorrenciaTipoSite == null)
            {
                return NotFound();
            }

            var tipoOcorrenciaTipoSite = await _context.TipoOcorrenciaTipoSite
                .Include(t => t.TipoOcorrencia)
                .Include(t => t.TipoSite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoOcorrenciaTipoSite == null)
            {
                return NotFound();
            }

            return View(tipoOcorrenciaTipoSite);
        }

        // GET: TipoOcorrenciaTipoSites/Create
        public IActionResult Create()
        {
            ViewData["TipoOcorrenciaId"] = new SelectList(_context.TipoOcorrencia, "Id", "NomeTipoOcorrencia");
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite");
            return View();
        }

        // POST: TipoOcorrenciaTipoSites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoOcorrenciaTipoSite tipoOcorrenciaTipoSite)
        {
            Notify(title: "OK!", message: "Tipo Site alterado com sucesso!", notificationType: Notification.success);
            return RedirectToAction("Create", "TipoOcorrenciaTipoSites");
            
        }

        // GET: TipoOcorrenciaTipoSites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoOcorrenciaTipoSite == null)
            {
                return NotFound();
            }

            var tipoOcorrenciaTipoSite = await _context.TipoOcorrenciaTipoSite.FindAsync(id);
            if (tipoOcorrenciaTipoSite == null)
            {
                return NotFound();
            }
            ViewData["TipoOcorrenciaId"] = new SelectList(_context.TipoOcorrencia, "Id", "NomeTipoOcorrencia", tipoOcorrenciaTipoSite.TipoOcorrenciaId);
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite", tipoOcorrenciaTipoSite.TipoSiteId);
            return View(tipoOcorrenciaTipoSite);
        }

        // POST: TipoOcorrenciaTipoSites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoSiteId,TipoOcorrenciaId")] TipoOcorrenciaTipoSite tipoOcorrenciaTipoSite)
        {
            if (id != tipoOcorrenciaTipoSite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoOcorrenciaTipoSite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoOcorrenciaTipoSiteExists(tipoOcorrenciaTipoSite.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoOcorrenciaId"] = new SelectList(_context.TipoOcorrencia, "Id", "NomeTipoOcorrencia", tipoOcorrenciaTipoSite.TipoOcorrenciaId);
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite", tipoOcorrenciaTipoSite.TipoSiteId);
            return View(tipoOcorrenciaTipoSite);
        }

        // GET: TipoOcorrenciaTipoSites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoOcorrenciaTipoSite == null)
            {
                return NotFound();
            }

            var tipoOcorrenciaTipoSite = await _context.TipoOcorrenciaTipoSite
                .Include(t => t.TipoOcorrencia)
                .Include(t => t.TipoSite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoOcorrenciaTipoSite == null)
            {
                return NotFound();
            }

            return View(tipoOcorrenciaTipoSite);
        }

        // POST: TipoOcorrenciaTipoSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoOcorrenciaTipoSite == null)
            {
                return Problem("Entity set 'RovDbContext.TipoOcorrenciaTipoSite'  is null.");
            }
            var tipoOcorrenciaTipoSite = await _context.TipoOcorrenciaTipoSite.FindAsync(id);
            if (tipoOcorrenciaTipoSite != null)
            {
                _context.TipoOcorrenciaTipoSite.Remove(tipoOcorrenciaTipoSite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoOcorrenciaTipoSiteExists(int id)
        {
          return (_context.TipoOcorrenciaTipoSite?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        [HttpPost]
        public JsonResult PegaIdTipoOcorrencia(int idDdlTipoSite, int idTipoOcorrencia)
        {

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var verificacaoSeExisteItem = _context.TipoOcorrenciaTipoSite.Where(t => t.TipoSiteId == idDdlTipoSite && t.TipoOcorrenciaId == idTipoOcorrencia).Select(t => t.TipoOcorrenciaId).FirstOrDefault();

            var database = new Database(_configuration);
            string query;
            if (verificacaoSeExisteItem == null)
            {
                query = $"insert into TipoOcorrenciaTipoSite (TipoSiteId, TipoOcorrenciaId) Values({idDdlTipoSite}, {idTipoOcorrencia})";

                try
                {
                    database.ExecuteQuery(query);
                    _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} atribuiu um novo tipo ocorrência para um tipo site", userId, IpAndHostname[0], IpAndHostname[1]);
                    return new JsonResult(Ok());
                }
                catch (Exception ex)
                {
                    return new JsonResult(Ok());
                }
            }
            return new JsonResult(Ok());

        }

        [HttpPost]
        public void DeletarTipoSiteTipoOcorrencia(int idTipoSite, int idTipoOcorrencia)
        {
            var database = new Database(_configuration);
            string query;
            query = $"DELETE FROM TipoOcorrenciaTipoSite WHERE TipoSiteId = {idTipoSite} and TipoOcorrenciaId = {idTipoOcorrencia}";
            database.ExecuteQuery(query);
            //return new JsonResult(Ok());
        }

        [HttpGet]
        public JsonResult GetTipoOcorrencia(int idTipoSite)
        {
            var item = _context.TipoOcorrenciaTipoSite.Where(t => t.TipoSiteId == idTipoSite).Select(t => t.TipoOcorrenciaId).ToList();

            return Json(new { tipo = item });
        }
    }

}
