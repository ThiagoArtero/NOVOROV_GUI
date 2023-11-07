using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using NOVOROV.Context;
using NOVOROV.DatabaseHelper;
using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;
using NOVOROV.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Database = NOVOROV.DatabaseHelper.Database;

namespace NOVOROV.Controllers
{
    public class PerdasController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Envolvido> _logger;

        public PerdasController(RovDbContext context, IConfiguration configuration, ILogger<Envolvido> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: Perdas
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Perda
                .Include(p => p.Ocorrencia)
                .Include(p => p.TipoEquipamento);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: Perdas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Perda == null)
            {
                return NotFound();
            }

            var perda = await _context.Perda
                .Include(p => p.Ocorrencia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perda == null)
            {
                return NotFound();
            }

            return View(perda);
        }

        // GET: Perdas/Create
        public IActionResult Create(int ocorrenciaId)
        {
            ViewBag.OcorrenciaId = ocorrenciaId;
            ViewData["TipoEquipamentoId"] = new SelectList(_context.TipoEquipamento, "Id", "NomeTipoEquipamento");
            return View();
        }

        // POST: Perdas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Perda perda, int ocorrenciaId)
        {
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            perda.TotalPassivo = 0;
            perda.TotalRecuperadoPassivo = 0;

            try
            {
                _context.Add(perda);
                await _context.SaveChangesAsync();

                SomarValorPerdaOcorrencia(perda.ValorPerda, ocorrenciaId);

                Notify(title: "OK!", message: "Perda adicionada com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} adicionou uma nova perda na ocorrência {perda.OcorrenciaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }
            catch(Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao adicionar perda!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }


            //return View(perda);
        }

        // GET: Perdas/Edit/5
        public async Task<IActionResult> Edit(int ocorrenciaId, int? id)
        {
            if (id == null || _context.Perda == null)
            {
                return NotFound();
            }

            ViewBag.OcorrenciaId = ocorrenciaId;

            decimal[] valoresPerdas = _context.Perda
                .Where(p => p.OcorrenciaId == ocorrenciaId)
                .Select(p => p.ValorPerda.Value)
                .ToArray();

            var total = 0.00;

            foreach (double val in valoresPerdas)
            {
                total += val;
            }

            ViewData["ValorTotal"] = total;

            var perda = await _context.Perda
                .FindAsync(id);

            var passivo = await _context.Passivo
               .FindAsync(id);

            if (perda == null)
            {
                return NotFound();
            }

            var passivos = _context.Passivo.Where(p => p.PerdaId == perda.Id)
                 .Select(p =>
                 new Passivo
                 {
                     Id = p.Id,
                     ValorPassivo = p.ValorPassivo,
                     ValorRecuperadoPassivo = p.ValorRecuperadoPassivo,
                     TipoRessarcimento = p.TipoRessarcimento,
                     AreaInterna = p.AreaInterna,
                     Empresa = p.Empresa,
                     PerdaId = p.PerdaId

                 }).ToList();

            perda.Passivo = passivos;

            var viewModel = new PerdasAndPassivosViewModel()
            {
                Perda = perda,
                Passivo = passivo,
                Passivos = passivos
            };

            ViewData["AreaInternaId"] = new SelectList(_context.AreaInterna, "Id", "NomeAreaInterna");
            ViewData["TipoRessarcimentoId"] = new SelectList(_context.TipoRessarcimento, "Id", "NomeTipoRessarcimento");
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "NomeEmpresa");
            ViewData["TipoEquipamentoId"] = new SelectList(_context.TipoEquipamento, "Id", "NomeTipoEquipamento");
            return View(viewModel);
        }

        // POST: Perdas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Perda perda, int ocorrenciaId)
        {
            if (id != perda.Id)
            {
                return NotFound();
            }

            decimal? valorTotalRecuperadoPassivo = _context.Perda.Where(p => p.Id == id).Select(p => p.TotalRecuperadoPassivo).FirstOrDefault();
            decimal? totalPassivo = _context.Perda.Where(p => p.Id == id).Select(p => p.TotalPassivo).FirstOrDefault();

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();
            perda.OcorrenciaId = ocorrenciaId;
            perda.TotalRecuperadoPassivo = valorTotalRecuperadoPassivo;
            perda.TotalPassivo = totalPassivo;

            try
            {
                _context.Update(perda);
                await _context.SaveChangesAsync();
                Notify(title: "OK!", message: "Perda alterada com sucesso!", notificationType: Notification.success);
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} editou uma perda na ocorrência {perda.OcorrenciaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                return RedirectToAction("Edit", "Perdas", new { id = id, ocorrenciaId = ocorrenciaId});
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar perda!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Perdas", new { id = id, ocorrenciaId = ocorrenciaId });
            }


        }

        // GET: Perdas/Delete/5
        public async Task<IActionResult> Delete(int? id, int ocorrenciaId)
        {
            if (id == null || _context.Perda == null)
            {
                return NotFound();
            }

            var perda = await _context.Perda
                .Include(p => p.Ocorrencia)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewBag.OcorrenciaId = ocorrenciaId;

            if (perda == null)
            {
                return NotFound();
            }

            return View(perda);
        }

        // POST: Perdas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int ocorrenciaId)
        {
            if (_context.Perda == null)
            {
                return Problem("Entity set 'RovDbContext.Perda'  is null.");
            }
            var perda = await _context.Perda.FindAsync(id);

            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            if (perda != null)
            {
                try
                {
                    _context.Perda.Remove(perda);
                    await _context.SaveChangesAsync();
                    Notify(title: "OK!", message: "Perda removida com sucesso!", notificationType: Notification.success);
                    _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} excluiu uma perda na ocorrência {perda.OcorrenciaId}", userId, IpAndHostname[0], IpAndHostname[1]);
                    LogSubtrairPerda(perda.ValorPerda , ocorrenciaId);
                    return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
                }
                catch
                {
                    Notify(title: "Oops!", message: "Erro ao alterar perda!", notificationType: Notification.warning);
                    return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
                }
            }
            else
            {
                Notify(title: "Oops!", message: "Perda não encontrada!", notificationType: Notification.error);
                return RedirectToAction("Edit", "Ocorrencias", new { id = ocorrenciaId });
            }

      
        }

        private bool PerdaExists(int id)
        {
            return (_context.Perda?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public void AdicionarPassivo(decimal valorPassivo, decimal valorRecuperado, int tipoRessarcimento, int areaInterna, int empresa, int perdaId)
        {
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            AtualizarSomaPassivo(valorPassivo, valorRecuperado, perdaId);

            var passivo = new Passivo();

            passivo.ValorPassivo = valorPassivo;
            passivo.ValorRecuperadoPassivo = valorRecuperado;
            passivo.TipoRessarcimentoId = tipoRessarcimento;
            passivo.AreaInternaId = areaInterna;
            passivo.EmpresaId = empresa;
            passivo.PerdaId = perdaId;

            _context.Add(passivo);
            _context.SaveChangesAsync();
            _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} adicionou um novo passivo na perda {perdaId}", userId, IpAndHostname[0], IpAndHostname[1]);
        }

        public void AtualizarSomaPassivo(decimal valorPassivo, decimal valorRecuperado, int perdaId)
        {
            Perda perda = _context.Perda.Where(p => p.Id == perdaId).FirstOrDefault();

            //Soma para a tabela Total em perdas
            perda.TotalPassivo += valorPassivo;
            perda.TotalRecuperadoPassivo += valorRecuperado;
            _context.Update(perda);
        }


        public JsonResult CarregarTabela(int id)
        {

            var listaPassivos = _context.Passivo
                .Where(p => p.PerdaId == id)
                .Include(t => t.TipoRessarcimento)
                .Include(a => a.AreaInterna)
                .Include(e => e.Empresa)
                .ToList();

            return Json(new { passivos = listaPassivos });

        }

        public void SomarValorPerdaOcorrencia(decimal? valorPerda, int ocorrenciaId)
        {

            var userId = User.Identity.Name.Split("\\")[1];

            Ocorrencia ocorrencia = _context.Ocorrencia.Where(o => o.Id == ocorrenciaId).FirstOrDefault();

            var valorPerdaTotal = ocorrencia.ValorPerdaTotal;
            var valorInicial = valorPerdaTotal;
            valorPerdaTotal += valorPerda;
            var diferencaValor = valorPerdaTotal - valorInicial;
            Decimal? variacaoPerdaPercentual;
            //if ()
            //{

            //}
            if (valorInicial != 0 && valorPerda != 0)
            {
                variacaoPerdaPercentual = (valorPerda * 100) / valorInicial;
            }
            else
            {
                variacaoPerdaPercentual = 0;
            }

            var valorEditado = valorPerdaTotal.ToString().Replace(',', '.');
            var valorAnteriorEditado = valorInicial.ToString().Replace(',','.');
            var diferencaValorEditado = diferencaValor.ToString().Replace(',', '.');
            var variacaoPerdaPercentualEditada = variacaoPerdaPercentual.ToString().Replace(',', '.');


            string query = $" INSERT INTO LogValor (OcorrenciaId, TipoOcorrenciaId, TipoSiteId ,DataAlteracaoValor, ValorAlteradoPorId, ValorConteudoAnterior, ValorConteudoAtual, ValorDiferenca, ValorDiferencaPercentual) " +
                $" VALUES ({ocorrenciaId},{ocorrencia.TipoOcorrenciaId} ,{ocorrencia.TipoSiteId} , CONVERT(DATETIME, '{DateTime.Now}', 103) , {userId}, {valorAnteriorEditado}, {valorEditado}, {diferencaValorEditado}, {variacaoPerdaPercentualEditada}); ";

            var database = new Database(_configuration);
            try
            {
                database.ExecuteQuery(query);

                query = $" UPDATE Ocorrencia SET ValorPerdaTotal = {valorEditado} WHERE Id = {ocorrenciaId}";

                database.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
            }

        }

        public void LogSubtrairPerda(decimal? valorPerda, int ocorrenciaId)
        {

            var userId = User.Identity.Name.Split("\\")[1];
            Ocorrencia ocorrencia = _context.Ocorrencia.Where(o => o.Id == ocorrenciaId).FirstOrDefault();

            var valorPerdaTotal = ocorrencia.ValorPerdaTotal;
            var valorInicial = valorPerdaTotal;
            valorPerdaTotal -= valorPerda;
            var diferencaValor = valorPerdaTotal - valorInicial;
            Decimal? variacaoPerdaPercentual;
            //if ()
            //{

            //}
            if (valorInicial != 0 && valorPerda != 0)
            {
                variacaoPerdaPercentual = (valorPerda * 100) / valorInicial;
            }
            else
            {
                variacaoPerdaPercentual = 0;
            }


            var valorEditado = valorPerdaTotal.ToString().Replace(',', '.');
            var valorAnteriorEditado = valorInicial.ToString().Replace(',', '.');
            var diferencaValorEditado = diferencaValor.ToString().Replace(',', '.');
            var variacaoPerdaPercentualEditada = variacaoPerdaPercentual.ToString().Replace(',', '.');

            string query = $" INSERT INTO LogValor (OcorrenciaId, TipoOcorrenciaId, TipoSiteId ,  DataAlteracaoValor, ValorAlteradoPorId, ValorConteudoAnterior, ValorConteudoAtual, ValorDiferenca, ValorDiferencaPercentual) " +
            $" VALUES ({ocorrenciaId}, {ocorrencia.TipoOcorrenciaId}, {ocorrencia.TipoSiteId}, CONVERT(DATETIME, '{DateTime.Now}', 103) , {userId}, {valorAnteriorEditado}, {valorEditado}, {diferencaValorEditado}, -{variacaoPerdaPercentualEditada}); ";

            var database = new Database(_configuration);
            try
            {
                database.ExecuteQuery(query);

                query = $" UPDATE Ocorrencia SET ValorPerdaTotal = {valorEditado} WHERE Id = {ocorrenciaId}";

                database.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
            }

        }

    }
}
