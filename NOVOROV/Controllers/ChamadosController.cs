using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOVOROV.Context;
using NOVOROV.Models;
using NOVOROV.ViewModels;

namespace NOVOROV.Controllers
{
    public class ChamadosController : BaseController
    {
        private readonly RovDbContext _context;

        public ChamadosController(RovDbContext context)
        {
            _context = context;
        }

        // GET: Chamados
        public async Task<IActionResult> Index()
        {
            var rovDbContext = _context.Chamado
                .Include(c => c.Solicitante)
                .Include(c => c.UsuarioOperador)
                .Include(c => c.StatusAtendimentoChamado)
                .Include(c => c.StatusChamado)
                 .Include(c => c.AnexoChamado)
                .ThenInclude(c => c.TipoAnexo);
            return View(await rovDbContext.ToListAsync());
        }

        // GET: Chamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chamado == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamado
                .Include(c => c.Solicitante)
                .Include(c => c.UsuarioOperador)
                .Include(c => c.StatusAtendimentoChamado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // GET: Chamados/Create
        public IActionResult Create()

        {
            var userId = User.Identity.Name.Split("\\")[1];
            var userName = _context.Usuario.Where(u => u.UsuarioId == userId).Select(u => u.NomeUsuario).FirstOrDefault();



            TempData["NomeUsuario"] = userName;
            TempData["MatriculaUsuario"] = userId;
            TempData["DataAbertura"] = DateTime.Now;

            ViewData["SolicitanteId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");
            ViewData["UsuarioOperadorId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");
            //ViewData["StatusAtendimentoChamadoId"] = new SelectList(_context.StatusAtendimentoChamado, "StatusAtendimentoChamadoId", "NomeStatusAtendimento");
            ViewData["StatusAtendimentoChamadoId"] = new SelectList(_context.StatusAtendimentoChamado, "Id", "NomeStatusAtendimento");


            return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Chamado chamado)
        {
            var userId = User.Identity.Name.Split("\\")[1];

            chamado.UsuarioOperadorId = userId;
            chamado.DataAbertura = DateTime.Now;
            chamado.StatusChamadoId = 1;

            try
            {
                //chamado.DataAbertura = FormatacaoDataSemMilissegundos(DateTime.Now);
                _context.Add(chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) { }

            ViewData["SolicitanteId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", chamado.SolicitanteId);
            ViewData["UsuarioOperadorId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", chamado.UsuarioOperadorId);
            return View(chamado);

        }

        public async Task<IActionResult> AdicionarResposta(Atendimento atendimento, IFormFile postedFile, int chamadoId, int statusChamadoId)
        {
            var userId = User.Identity.Name.Split("\\")[1];

            Chamado chamado = _context.Chamado.Where(c => c.Id == chamadoId).FirstOrDefault();

            try
            {
                byte[] bytes;
                if (postedFile == null)
                {
                    bytes = null;

                }
                else
                {
                    using (BinaryReader binaryReader = new BinaryReader(postedFile.OpenReadStream()))
                    {
                        bytes = binaryReader.ReadBytes((int)postedFile.Length);
                    }
                }


                var name = Path.GetFileName(postedFile?.FileName);
                var contentType = postedFile?.ContentType;

                atendimento.NomeAnexoAtendimento = name;
                atendimento.ContentType = contentType;
                atendimento.Bytes = bytes;
                atendimento.ChamadoId = chamadoId;
                atendimento.DataAtendimento = DateTime.Now;
                atendimento.UsuarioRespostaId = userId;
                atendimento.StatusChamadoId = statusChamadoId;


                chamado.StatusChamadoId = statusChamadoId;

                _context.Update(chamado);

                _context.Add(atendimento);
                await _context.SaveChangesAsync();

                Notify(title: "Ok!", message: "Resposta enviada com sucesso!", notificationType: Notification.success);
                return RedirectToAction("Edit", "Chamados", new { id = chamadoId });

            }
            catch (Exception ex)
            {
                Notify(title: "Erro!", message: "Erro ao adicionar resposta!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Chamados", new { id = chamadoId });
            }
        }

        // GET: Chamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chamado == null)
            {
                return NotFound();
            }

            var teste = _context.Atendimento.Count();
            TempData["teste"] = teste;

            var chamado = await _context.Chamado.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }

            var atendimento = new Atendimento();
            var userId = _context.Chamado.Where(o => o.Id == id).Select(u => u.UsuarioOperadorId).FirstOrDefault();
            var userName = _context.Usuario.Where(u => u.UsuarioId == userId).Select(u => u.NomeUsuario).FirstOrDefault();

            ChamadoAndAtendimento chamadoAtendimento = new ChamadoAndAtendimento();


            TempData["NomeUsuario"] = userName;

            var atendimentos = _context.Atendimento.Where(a => a.ChamadoId == chamado.Id)
                 .Select(a =>
                 new Atendimento
                 {
                     Id = a.Id,
                     Resposta = a.Resposta,
                     StatusAtendimentoChamadoId = a.StatusAtendimentoChamadoId,
                     StatusAtendimentoChamado = a.StatusAtendimentoChamado,
                     UsuarioRespostaId = a.UsuarioRespostaId,
                     UsuarioResposta = a.UsuarioResposta,
                     DataAtendimento = a.DataAtendimento,
                     NomeAnexoAtendimento = a.NomeAnexoAtendimento,
                     StatusChamadoId = a.StatusChamadoId,
                     StatusChamado = a.StatusChamado

                 }).ToList();

            var anexosChamado = _context.AnexosChamado.Where(a => a.ChamadoId == chamado.Id)
                 .Select(a =>
                 new AnexosChamado
                 {
                     Id = a.Id,
                     DataAnexo = a.DataAnexo,
                     Produto = a.Produto,
                     Codigo = a.Codigo,
                     Quantidade = a.Quantidade,
                     Comentario = a.Comentario,
                     Autor = a.Autor,
                     NomeAnexo = a.NomeAnexo,
                     ChamadoId = a.ChamadoId,
                     TipoAnexo = a.TipoAnexo,
                     DescricaoAnexo = a.DescricaoAnexo,
                     Bytes = a.Bytes
                 }).ToList();

            chamado.AnexoChamado = anexosChamado;

            chamado.Atendimento = atendimentos;
            chamadoAtendimento.Chamado = chamado;
            chamadoAtendimento.Atendimento = atendimento;

            ViewData["SolicitanteId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario", chamado.SolicitanteId);
            ViewData["UsuarioOperadorId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario", chamado.UsuarioOperadorId);
            ViewData["StatusAtendimentoChamadoId"] = new SelectList(_context.StatusAtendimentoChamado, "Id", "NomeStatusAtendimento", atendimento.StatusAtendimentoChamadoId);
            ViewData["StatusChamadoId"] = new SelectList(_context.StatusChamado, "Id", "NomeStatusChamado", atendimento.StatusAtendimentoChamadoId);
            return View(chamadoAtendimento);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Chamado chamado)
        {


            if (id != chamado.Id)
            {
                return NotFound();
            }

            var userId = User.Identity.Name.Split("\\")[1];

            try
            {
                _context.Update(chamado);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChamadoExists(chamado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Edit", "Chamados", new { id = id });
        }

        // GET: Chamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chamado == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamado
                .Include(c => c.Solicitante)
                .Include(c => c.UsuarioOperador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // POST: Chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chamado == null)
            {
                return Problem("Entity set 'RovDbContext.Chamado'  is null.");
            }
            var chamado = await _context.Chamado.FindAsync(id);
            if (chamado != null)
            {
                _context.Chamado.Remove(chamado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoExists(int id)
        {
            return (_context.Chamado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
