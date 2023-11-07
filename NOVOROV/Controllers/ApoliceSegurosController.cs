using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.DatabaseHelper;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class ApoliceSegurosController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;

        public ApoliceSegurosController(RovDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: ApoliceSeguroes
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.ApoliceSeguro
                .Include(a => a.TipoApoliceSeguro)
                .Include(a => a.TipoOcorrencia)
                .Include(a => a.TipoSite);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: ApoliceSeguroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ApoliceSeguro == null)
            {
                return NotFound();
            }

            var apoliceSeguro = await _context.ApoliceSeguro
                .Include(a => a.TipoApoliceSeguro)
                .Include(a => a.TipoOcorrencia)
                .Include(a => a.TipoSite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apoliceSeguro == null)
            {
                return NotFound();
            }

            return View(apoliceSeguro);
        }

        // GET: ApoliceSeguroes/Create
        public IActionResult Create()
        {
            ViewData["TipoApoliceSeguroId"] = new SelectList(_context.TipoApoliceSeguro, "Id", "NomeTipoApoliceSeguro");
            ViewData["TipoOcorrenciaId"] = new SelectList(_context.TipoOcorrencia, "Id", "NomeTipoOcorrencia");
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite");
            return View();
        }

        // POST: ApoliceSeguroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApoliceSeguro apoliceSeguro)
        {

            Notify(title: "Ok!", message: "Apolice e Seguro Adicionado com Sucesso!", notificationType: Notification.success);
            return RedirectToAction(nameof(Index));
            
        }

        // GET: ApoliceSeguroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ApoliceSeguro == null)
            {
                return NotFound();
            }

            var apoliceSeguro = await _context.ApoliceSeguro.FindAsync(id);
            if (apoliceSeguro == null)
            {
                return NotFound();
            }
            ViewData["TipoApoliceSeguroId"] = new SelectList(_context.TipoApoliceSeguro, "Id", "NomeTipoApoliceSeguro", apoliceSeguro.TipoApoliceSeguroId);
            ViewData["TipoOcorrenciaId"] = new SelectList(_context.TipoOcorrencia, "Id", "NomeTipoOcorrencia", apoliceSeguro.TipoOcorrenciaId);
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite", apoliceSeguro.TipoSiteId);
            return View(apoliceSeguro);
        }

        // POST: ApoliceSeguroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApoliceSeguro apoliceSeguro)
        {
            if (id != apoliceSeguro.Id)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(apoliceSeguro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApoliceSeguroExists(apoliceSeguro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            //return View(apoliceSeguro);
            return RedirectToAction(nameof(Index));
        }

        // GET: ApoliceSeguroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ApoliceSeguro == null)
            {
                return NotFound();
            }

            var apoliceSeguro = await _context.ApoliceSeguro
                .Include(a => a.TipoApoliceSeguro)
                .Include(a => a.TipoOcorrencia)
                .Include(a => a.TipoSite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apoliceSeguro == null)
            {
                return NotFound();
            }

            return View(apoliceSeguro);
        }

        // POST: ApoliceSeguroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ApoliceSeguro == null)
            {
                return Problem("Entity set 'RovDbContext.ApoliceSeguro'  is null.");
            }
            var apoliceSeguro = await _context.ApoliceSeguro.FindAsync(id);
            if (apoliceSeguro != null)
            {
                _context.ApoliceSeguro.Remove(apoliceSeguro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApoliceSeguroExists(int id)
        {
          return (_context.ApoliceSeguro?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        public JsonResult CreateApoliceSeguros(int idTipoSite,int idTipoApoliceSeguro,int valorApoliceSeguro, string valorDescricaoApoliceSeguro, int idTipoOcorrencia)
        {
            decimal valorApolice = Convert.ToDecimal(valorApoliceSeguro);

            string query = $"INSERT INTO ApoliceSeguro(TipoSiteId,TipoApoliceSeguroId, ValorApoliceSeguro,DescricaoApoliceSeguro, TipoOcorrenciaId) VALUES({idTipoSite},{idTipoApoliceSeguro},{valorApolice}, '{valorDescricaoApoliceSeguro}', {idTipoOcorrencia})";
            var database = new Database(_configuration);
            try
            {
                database.ExecuteQuery(query);
                return new JsonResult(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(Ok());
            }
        }


    }
}
