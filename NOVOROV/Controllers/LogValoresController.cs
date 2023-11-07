using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class LogValoresController : Controller
    {
        private readonly RovDbContext _context;

        public LogValoresController(RovDbContext context)
        {
            _context = context;
        }

        // GET: LogValores
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.LogValor
                .Include(l => l.Ocorrencia)
                .Include(l => l.ValorAlteradoPor)
                .Include(l => l.TipoOcorrencia)
                .Include(l=> l.TipoSite);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: LogValores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LogValor == null)
            {
                return NotFound();
            }

            var logValor = await _context.LogValor
                .Include(l => l.Ocorrencia)
                .Include(l => l.ValorAlteradoPor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logValor == null)
            {
                return NotFound();
            }

            return View(logValor);
        }

        // GET: LogValores/Create
        public IActionResult Create()
        {
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencia, "Id", "CEP");
            ViewData["ValorAlteradoPorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: LogValores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OcorrenciaId,DataAlteracaoValor,ValorAlteradoPorId,ValorPerdaTotal,ValorConteudoAnterior,ValorConteudoAtual,ValorDiferenca,ValorDiferencaPercentual")] LogValor logValor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logValor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencia, "Id", "CEP", logValor.OcorrenciaId);
            ViewData["ValorAlteradoPorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", logValor.ValorAlteradoPorId);
            return View(logValor);
        }

        // GET: LogValores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LogValor == null)
            {
                return NotFound();
            }

            var logValor = await _context.LogValor.FindAsync(id);
            if (logValor == null)
            {
                return NotFound();
            }
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencia, "Id", "CEP", logValor.OcorrenciaId);
            ViewData["ValorAlteradoPorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", logValor.ValorAlteradoPorId);
            return View(logValor);
        }

        // POST: LogValores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OcorrenciaId,DataAlteracaoValor,ValorAlteradoPorId,ValorPerdaTotal,ValorConteudoAnterior,ValorConteudoAtual,ValorDiferenca,ValorDiferencaPercentual")] LogValor logValor)
        {
            if (id != logValor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logValor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogValorExists(logValor.Id))
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
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencia, "Id", "CEP", logValor.OcorrenciaId);
            ViewData["ValorAlteradoPorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", logValor.ValorAlteradoPorId);
            return View(logValor);
        }

        // GET: LogValores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LogValor == null)
            {
                return NotFound();
            }

            var logValor = await _context.LogValor
                .Include(l => l.Ocorrencia)
                .Include(l => l.ValorAlteradoPor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logValor == null)
            {
                return NotFound();
            }

            return View(logValor);
        }

        // POST: LogValores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LogValor == null)
            {
                return Problem("Entity set 'RovDbContext.LogValor'  is null.");
            }
            var logValor = await _context.LogValor.FindAsync(id);
            if (logValor != null)
            {
                _context.LogValor.Remove(logValor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogValorExists(int id)
        {
          return (_context.LogValor?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public FileResult ExportFile()
        {
            var userId = User.Identity.Name.Split("\\")[1];



            var logValores = _context.LogValor
                .Include(o => o.Ocorrencia)
                .Include(o => o.TipoOcorrencia)
                .Include(o => o.TipoSite)
                .Include(o => o.ValorAlteradoPor)
                .ToList();



            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("LogValores");



                var currentRow = 1;



                worksheet.Cell(currentRow, 1).Value = "Rov";
                worksheet.Cell(currentRow, 2).Value = "Tipo Ocorrência";
                worksheet.Cell(currentRow, 3).Value = "Tipo Site";
                worksheet.Cell(currentRow, 4).Value = "Data Alteração";
                worksheet.Cell(currentRow, 5).Value = "Valor Alterado Por";
                worksheet.Cell(currentRow, 6).Value = "Conteúdo Anterior";
                worksheet.Cell(currentRow, 7).Value = "Conteudo Atual";
                worksheet.Cell(currentRow, 8).Value = "Valor Diferença";
                worksheet.Cell(currentRow, 9).Value = "Diferença Percentual";





                foreach (var logValor in logValores)
                {
                    currentRow++;




                    worksheet.Cell(currentRow, 1).Value = logValor.Id;
                    worksheet.Cell(currentRow, 2).Value = logValor.TipoOcorrencia != null ? logValor.TipoOcorrencia.NomeTipoOcorrencia : "";
                    worksheet.Cell(currentRow, 3).Value = logValor.TipoSite != null ? logValor.TipoSite.NomeTipoSite : "";
                    worksheet.Cell(currentRow, 4).Value = logValor.DataAlteracaoValor;
                    worksheet.Cell(currentRow, 5).Value = logValor.ValorAlteradoPor.NomeUsuario;
                    worksheet.Cell(currentRow, 6).Value = logValor.ValorConteudoAnterior;
                    worksheet.Cell(currentRow, 7).Value = logValor.ValorConteudoAtual;
                    worksheet.Cell(currentRow, 8).Value = logValor.ValorDiferenca;
                    worksheet.Cell(currentRow, 9).Value = logValor.ValorDiferencaPercentual;




                }



                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"logValores-{DateTime.Now:dd/MM/yyyy}.xlsx");
                }



            }



        }
    }
}
