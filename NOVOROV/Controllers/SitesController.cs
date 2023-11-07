using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class SitesController : BaseController
    {
        private readonly RovDbContext _context;

        public SitesController(RovDbContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Site.Include(s => s.SistemaFechaduraBluetooth).Include(s => s.SistemaRastreamento).Include(s => s.Status).Include(s => s.TipoSite);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Site == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .Include(s => s.SistemaFechaduraBluetooth)
                .Include(s => s.SistemaRastreamento)
                .Include(s => s.Status)
                .Include(s => s.TipoSite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            ViewData["SistemaFechaduraBluetoothId"] = new SelectList(_context.SistemaFechaduraBluetooth, "Id", "NomeFechaduraBluetooth ");
            ViewData["SistemaRastreamentoId"] = new SelectList(_context.SistemaRastreamento, "Id", "NomeRastreamento");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "NomeStatus");
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite");
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Site site)
        {
            try
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Site adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction("Create", "Ocorrencias");
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar site!", notificationType: Notification.warning);
                return RedirectToAction("Create", "Ocorrencias");
            }

        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            ViewData["SistemaFechaduraBluetoothId"] = new SelectList(_context.SistemaFechaduraBluetooth, "Id", "Id", site.SistemaFechaduraBluetoothId);
            ViewData["SistemaRastreamentoId"] = new SelectList(_context.SistemaRastreamento, "Id", "Id", site.SistemaRastreamentoId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id", site.StatusId);
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite", site.TipoSiteId);
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Site site)
        {
            if (id != site.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(site);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Site alterado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar site!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }


        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Site == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .Include(s => s.SistemaFechaduraBluetooth)
                .Include(s => s.SistemaRastreamento)
                .Include(s => s.Status)
                .Include(s => s.TipoSite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Site == null)
            {
                return Problem("Entity set 'RovDbContext.Site'  is null.");
            }
            var site = await _context.Site.FindAsync(id);
            if (site != null)
            {
                _context.Site.Remove(site);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
            return (_context.Site?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
