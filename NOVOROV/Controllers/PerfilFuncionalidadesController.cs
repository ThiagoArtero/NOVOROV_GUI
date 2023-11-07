using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public class PerfilFuncionalidadesController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Envolvido> _logger;

        public PerfilFuncionalidadesController(RovDbContext context, IConfiguration configuration, ILogger<Envolvido> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: PerfilFuncionalidades
        public async Task<IActionResult> Index()
        {
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "NomePerfil");

            var rovDbContext = _context.PerfilFuncionalidade
                .Include(p => p.Funcionalidade)
                .Include(p => p.Perfil);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: PerfilFuncionalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PerfilFuncionalidade == null)
            {
                return NotFound();
            }

            var perfilFuncionalidade = await _context.PerfilFuncionalidade
                .Include(p => p.Funcionalidade)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfilFuncionalidade == null)
            {
                return NotFound();
            }

            return View(perfilFuncionalidade);
        }

        // GET: PerfilFuncionalidades/Create
        public IActionResult Create()
        {
            ViewData["FuncionalidadeId"] = new SelectList(_context.Funcionalidade, "Id", "NomeFuncionalidade");
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "NomePerfil");
            return View();
        }

        // POST: PerfilFuncionalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FuncionalidadeId,PerfilId")] PerfilFuncionalidade perfilFuncionalidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfilFuncionalidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionalidadeId"] = new SelectList(_context.Funcionalidade, "Id", "Id", perfilFuncionalidade.FuncionalidadeId);
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "Id", perfilFuncionalidade.PerfilId);
            return View(perfilFuncionalidade);
        }

        // GET: PerfilFuncionalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PerfilFuncionalidade == null)
            {
                return NotFound();
            }

            var perfilFuncionalidade = await _context.PerfilFuncionalidade.FindAsync(id);
            if (perfilFuncionalidade == null)
            {
                return NotFound();
            }
            ViewData["FuncionalidadeId"] = new SelectList(_context.Funcionalidade, "Id", "Id", perfilFuncionalidade.FuncionalidadeId);
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "Id", perfilFuncionalidade.PerfilId);
            return View(perfilFuncionalidade);
        }

        // POST: PerfilFuncionalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FuncionalidadeId,PerfilId")] PerfilFuncionalidade perfilFuncionalidade)
        {
            if (id != perfilFuncionalidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfilFuncionalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilFuncionalidadeExists(perfilFuncionalidade.Id))
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
            ViewData["FuncionalidadeId"] = new SelectList(_context.Funcionalidade, "Id", "Id", perfilFuncionalidade.FuncionalidadeId);
            ViewData["PerfilId"] = new SelectList(_context.Perfil, "Id", "Id", perfilFuncionalidade.PerfilId);
            return View(perfilFuncionalidade);
        }

        // GET: PerfilFuncionalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PerfilFuncionalidade == null)
            {
                return NotFound();
            }

            var perfilFuncionalidade = await _context.PerfilFuncionalidade
                .Include(p => p.Funcionalidade)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfilFuncionalidade == null)
            {
                return NotFound();
            }

            return View(perfilFuncionalidade);
        }

        // POST: PerfilFuncionalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PerfilFuncionalidade == null)
            {
                return Problem("Entity set 'RovDbContext.PerfilFuncionaidades'  is null.");
            }
            var perfilFuncionalidade = await _context.PerfilFuncionalidade.FindAsync(id);
            if (perfilFuncionalidade != null)
            {
                _context.PerfilFuncionalidade.Remove(perfilFuncionalidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilFuncionalidadeExists(int id)
        {
          return (_context.PerfilFuncionalidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        public JsonResult GetFuncionalidades(int id)
        {
           
            var item = _context.PerfilFuncionalidade.Where(p => p.PerfilId == id).Select(p => p.Funcionalidade.NomeFuncionalidade).ToList();
            var descricao = _context.PerfilFuncionalidade.Where(p => p.PerfilId == id).Select(p => p.Funcionalidade.DescricaoFuncionalidade).ToList();
            var idRelacao = _context.PerfilFuncionalidade.Where(p => p.PerfilId == id).Select(p => p.Id).ToList();

            return Json(new { funcionalidade = item, descricao, idRelacao });
        }


        public async Task<ActionResult> DeleteFuncionalidadeAtribuida(int id)
        {
            var perfilFuncionalidade = await _context.PerfilFuncionalidade.FindAsync(id);

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            if (perfilFuncionalidade != null)
            {
                _context.PerfilFuncionalidade.Remove(perfilFuncionalidade);
            }
            await _context.SaveChangesAsync();
            _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} removeu uma funcionalidade de um perfil", userId, IpAndHostname[0], IpAndHostname[1]);
            return RedirectToAction(nameof(Index));
        }

    }
}
