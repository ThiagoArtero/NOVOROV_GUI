using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using NOVOROV.DatabaseHelper;
using NOVOROV.Context;
using NOVOROV.Models;
using static Azure.Core.HttpHeader;
using NOVOROV.Models.DropDownLists;
using static System.Net.Mime.MediaTypeNames;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Net;
using NOVOROV.Services;
using NOVOROV.Services.Interfaces;

namespace NOVOROV.Controllers
{
    public class OcorrenciasController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OcorrenciasController> _logger;
        private readonly IEmailService _emailService;

        public OcorrenciasController(RovDbContext context, IConfiguration configuration,
            ILogger<OcorrenciasController> logger,
            IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<IActionResult> EnviarEmail(int? id)
        {
            var ocorrencia = await _context.Ocorrencia
                .Include(o => o.AcionadoProntoAtendimento)
                .Include(o => o.AlarmeRealAcidente)
                .Include(o => o.AreaInterna)
                .Include(o => o.AreaSaude)
                .Include(o => o.AtendimentoSLA)
                .Include(o => o.BombeiroCivil)
                .Include(o => o.Cmc)
                .Include(o => o.EmpresaProntoAtendimento)
                .Include(o => o.EventoERB)
                .Include(o => o.FornecimentoAcessoFisico)
                .Include(o => o.FornecimentoEventoAlarme)
                .Include(o => o.FornecimentoImagem)
                .Include(o => o.Local)
                .Include(o => o.Manutencao)
                .Include(o => o.PlanoDeEmergencia)
                .Include(o => o.Qualificacao)
                .Include(o => o.TipoAcesso)
                .Include(o => o.TipoOcorrencia)
                .Include(o => o.TipoSite)
                .Include(o => o.Site)
                .Include(o => o.Empresa)
                .Include(o => o.Status)
                .Include(o => o.Perda)
                .FirstOrDefaultAsync(c => c.Id == id);

            PdfService pdfService = new PdfService();
            byte[] ocorrenciaReportInBytes = pdfService.PrepareReport(ocorrencia);
            string tempFilePath = Path.GetTempPath();
            var filename = $"ROV N° {ocorrencia.Id} - {ocorrencia.TipoOcorrencia?.NomeTipoOcorrencia} - {DateTime.Now:dd_MM_yyyy}.pdf";
            string filePath = Path.Combine(tempFilePath, filename);
            using var stream = System.IO.File.Create(filePath);
            stream.Write(ocorrenciaReportInBytes, 0, ocorrenciaReportInBytes.Length);
            stream.Dispose();
            List<string> lstAllRecipients = new List<string>();
            //lstAllRecipients.Add("guilherme.asantos@telefonica.com");
            //lstAllRecipients.Add("thiago.martero@telefonica.com");
            var subject = $"ROV Nº {ocorrencia.Id} - {ocorrencia.TipoOcorrencia?.NomeTipoOcorrencia} - Título: {ocorrencia.Site?.NomeSite}";
            _emailService.SendEmail(subject, lstAllRecipients, filePath);
            return RedirectToAction("MinhasOcorrencias");
        }

        public async Task<IActionResult> MinhasOcorrencias()
        {
            List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

            var userId = User.Identity.Name.Split("\\")[1];

            ocorrencias = await _context.Ocorrencia
            .Include(o => o.Cmc)
            .Include(o => o.TipoOcorrencia)
            .Include(o => o.Status)
            .Include(o => o.Anexo)
                .ThenInclude(o => o.TipoAnexo)
                .Where(o => o.ResponsavelOperacionalId == userId)
            .ToListAsync();
            return View(ocorrencias);
        }

        // GET: Ocorrencias
        public async Task<IActionResult> Index()
        {
            List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

            
                ocorrencias = await _context.Ocorrencia
                .Include(o => o.Cmc)
                .Include(o => o.TipoOcorrencia)
                .Include(o => o.Status)
                .Include(o => o.Anexo)
                    .ThenInclude(o => o.TipoAnexo)
                .ToListAsync();


            return View(ocorrencias);

        }

        // GET: Ocorrencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ocorrencia == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .Include(o => o.AcionadoProntoAtendimento)
                .Include(o => o.AlarmeRealAcidente)
                .Include(o => o.AnaliseConclusao)
                .Include(o => o.AreaInterna)
                .Include(o => o.AreaSaude)
                .Include(o => o.AreaTratamento)
                .Include(o => o.AtendimentoSLA)
                .Include(o => o.BombeiroCivil)
                .Include(o => o.BombeiroMilitar)
                .Include(o => o.Cmc)
                .Include(o => o.Condutor)
                .Include(o => o.Detentora)
                .Include(o => o.EmpresaChamadoSis)
                .Include(o => o.EmpresaProntoAtendimento)
                .Include(o => o.EquipamentoSis)
                .Include(o => o.EventoERB)
                .Include(o => o.FornecimentoAcessoFisico)
                .Include(o => o.FornecimentoEventoAlarme)
                .Include(o => o.FornecimentoImagem)
                .Include(o => o.Inbox)
                .Include(o => o.InformacaoComplementar)
                .Include(o => o.Local)
                .Include(o => o.Manutencao)
                .Include(o => o.OrgaoPublico)
                .Include(o => o.Placa)
                .Include(o => o.PlanoDeEmergencia)
                .Include(o => o.Qualificacao)
                .Include(o => o.RegistroPolicial)
                .Include(o => o.SistemaFechaduraBluetooth)
                .Include(o => o.SistemaRastreamento)
                .Include(o => o.SistemaSis)
                .Include(o => o.TipoAcesso)
                .Include(o => o.TipoAlarme)
                .Include(o => o.TipoOcorrencia)
                .Include(o => o.TipoSite)
                .Include(o => o.Transportadora)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            return View(ocorrencia);
        }

        // GET: Ocorrencias/Create
        public IActionResult Create()
        {
            try
            {
                var userId = User.Identity.Name.Split("\\")[1];
                var userName = _context.Usuario.Where(u => u.UsuarioId == userId).Select(u => u.NomeUsuario).FirstOrDefault();
                var userCmc = _context.Usuario.Where(u => u.UsuarioId == userId).Select(u => u.Cmc.NomeCmc).FirstOrDefault();
                var userCmcId = _context.Usuario.Where(u => u.UsuarioId == userId).Select(u => u.CmcId).FirstOrDefault();

                TempData["NomeUsuario"] = userName;
                TempData["MatriculaUsuario"] = userId;
                TempData["CmcUsuario"] = userCmc;
                TempData["CmcId"] = userCmcId;

                TempData["DataAtual"] = DateTime.Now;

                ViewData["AcionadoProntoAtendimentoId"] = new SelectList(_context.AcionadoProntoAtendimento, "Id", "NomeAcionadoProntoAtendimento");
                ViewData["AlarmeRealAcidenteId"] = new SelectList(_context.AlarmeRealAcidente, "Id", "NomeAlarmeRealAcidente");
                ViewData["AnaliseConclusaoId"] = new SelectList(_context.AnaliseConclusao, "Id", "Id");
                ViewData["AreaInternaId"] = new SelectList(_context.AreaInterna, "Id", "NomeAreaInterna");
                ViewData["AreaSaudeId"] = new SelectList(_context.AreaSaude, "Id", "NomeAreaSaude");
                ViewData["AreaTratamentoId"] = new SelectList(_context.AreaTratamento, "Id", "NomeAreaTratamento");
                ViewData["AtendimentoSLAId"] = new SelectList(_context.AtendimentoSLA, "Id", "Id");
                ViewData["BombeiroCivilId"] = new SelectList(_context.BombeiroCivil, "Id", "NomeBombeiroCivil");
                ViewData["BombeiroMilitarId"] = new SelectList(_context.BombeiroMilitar, "Id", "Id");
                ViewData["CmcId"] = new SelectList(_context.Cmc, "Id", "NomeCmc");
                ViewData["DetentoraId"] = new SelectList(_context.Detentora, "Id", "NomeDetentora");
                ViewData["EmpresaChamadoSisId"] = new SelectList(_context.EmpresaChamadoSis, "Id", "Id");
                ViewData["EmpresaProntoAtendimentoId"] = new SelectList(_context.EmpresaProntoAtendimento, "Id", "Id");
                ViewData["EquipamentoSisId"] = new SelectList(_context.EquipamentoSis, "Id", "Id");
                ViewData["EventoERBId"] = new SelectList(_context.EventoERB, "Id", "NomeEventoERB");
                ViewData["FornecimentoAcessoFisicoId"] = new SelectList(_context.FornecimentoAcessoFisico, "Id", "Id");
                ViewData["FornecimentoEventoAlarmeId"] = new SelectList(_context.FornecimentoEventoAlarme, "Id", "Id");
                ViewData["FornecimentoImagemId"] = new SelectList(_context.FornecimentoImagem, "Id", "Id");
                ViewData["InboxId"] = new SelectList(_context.Inbox, "Id", "NomeInbox");
                ViewData["InformacaoComplementarId"] = new SelectList(_context.InformacaoComplementar, "Id", "NomeInformacaoComplementar");
                ViewData["LocalId"] = new SelectList(_context.Local, "Id", "NomeLocal");
                ViewData["ManutencaoId"] = new SelectList(_context.Manutencao, "Id", "Id");
                ViewData["OrgaoPublicoId"] = new SelectList(_context.OrgaoPublico, "Id", "NomeOrgaoPublico");
                ViewData["PlacaId"] = new SelectList(_context.Placa, "Id", "Id");
                ViewData["PlanoDeEmergenciaId"] = new SelectList(_context.PlanoDeEmergencia, "Id", "NomePlanoDeEmergencia");
                ViewData["QualificacaoId"] = new SelectList(_context.Qualificacao, "Id", "NomeQualificacao");
                ViewData["RegistroPolicialId"] = new SelectList(_context.RegistroPolicial, "Id", "Id");
                ViewData["SistemaFechaduraBluetoothId"] = new SelectList(_context.SistemaFechaduraBluetooth, "Id", "NomeSistemaFechaduraBluetooth");
                ViewData["SistemaRastreamentoId"] = new SelectList(_context.SistemaRastreamento, "Id", "NomeSistemaRastreamento");
                ViewData["SistemaSisId"] = new SelectList(_context.SistemaSis, "Id", "Id");
                ViewData["TipoAcessoId"] = new SelectList(_context.TipoAcesso, "Id", "Id");
                ViewData["TipoOcorrenciaId"] = new SelectList(_context.TipoOcorrencia, "Id", "NomeTipoOcorrencia");
                ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite");
                ViewData["TransportadoraId"] = new SelectList(_context.Transportadora, "Id", "NomeTransportadora");
                ViewData["StatusId"] = new SelectList(_context.Status.Where(o => o.Id == 1), "Id", "NomeStatus");
                ViewData["GestaoQualidadeId"] = new SelectList(_context.GestaoQualidade, "Id", "NomeGestaoQualidade");
                ViewData["GestaoPerdaId"] = new SelectList(_context.GestaoPerda, "Id", "NomeGestaoPerda");
                ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "NomeEmpresa");
                ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NomeSite");
                ViewData["ResponsavelAveriguacaoId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");
                ViewData["StatusSiteId"] = new SelectList(_context.StatusSite, "Id", "NomeStatusSite");
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        // POST: Ocorrencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ocorrencia ocorrencia)
        {
            var userId = User.Identity.Name.Split("\\")[1];

            try
            {
                ocorrencia.DataRegistro = FormatacaoDataSemMilissegundos(DateTime.Now);
                ocorrencia.ValorPerdaTotal = 0;
                _context.Add(ocorrencia);
                await _context.SaveChangesAsync();


                Notify(title: "OK!", message: "Ocorrência criada com sucesso!", notificationType: Notification.success);

                List<string> IpAndHostname = GetIpAndHostname();
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} criou uma nova ocorrência com Id {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1]);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro Ao Criar Ocorrência!", notificationType: Notification.warning);
                return RedirectToAction("Create", "Ocorrencias");
            }

        }

        // GET: Ocorrencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var userId = _context.Ocorrencia.Where(o => o.Id == id).Select(u => u.UsuarioOperadorId).FirstOrDefault();
            var userName = _context.Usuario.Where(u => u.UsuarioId == userId).Select(u => u.NomeUsuario).FirstOrDefault();


            var userIdUltimaAlteracao = _context.Ocorrencia.Where(o => o.Id == id).Select(u => u.UsuarioAlteracaoOcorrenciaId).FirstOrDefault();
            var userNameUltimaAlteracao = _context.Usuario.Where(u => u.UsuarioId == userIdUltimaAlteracao).Select(u => u.NomeUsuario).FirstOrDefault();

            TempData["NomeUsuario"] = userName;
            TempData["MatriculaUsuario"] = userId;
            TempData["NomeUsuarioUltimaAlteracao"] = userNameUltimaAlteracao;

            //Soma das Perdas
            decimal[] valoresPerdas = _context.Perda
                .Where(p => p.OcorrenciaId == id)
                .Select(p => p.ValorPerda.Value)
                .ToArray();
            var totalPerda = 0.00;
            foreach (double val in valoresPerdas)
            {
                totalPerda += val;
            }
            ViewData["TotalPerda"] = totalPerda;

            //Soma Recuperação
            decimal[] valoresRecuperacao = _context.Perda
                .Where(p => p.OcorrenciaId == id)
                .Select(p => p.ValorEfetivamenteRecuperado.Value)
                .ToArray();
            var totalRecuperado = 0.00;
            foreach (double val in valoresRecuperacao)
            {
                totalRecuperado += val;
            }
            ViewData["TotalRecuperado"] = totalRecuperado;
            try
            {
                decimal[] valoresTotalPassivo = _context.Perda
                .Where(p => p.OcorrenciaId == id)
                .Select(p => p.TotalPassivo.Value)
                .ToArray();
                var totalPassivo = 0.00;

                foreach (double val in valoresTotalPassivo)
                {
                    totalPassivo += val;
                }
                ViewData["TotalPassivo"] = totalPassivo;
            }
            catch (Exception ex)
            {

            }
            //Soma Total Passivo

            double totalRecuperadoPassivo = 0.00;
            //Soma Recuperado Passivo
            try
            {
                decimal[] valoresRecuperadoPassivo = _context.Perda
                    .Where(p => p.OcorrenciaId == id)
                    .Select(p => p.TotalRecuperadoPassivo.Value)
                    .ToArray();
                if (valoresRecuperadoPassivo.Length == 0)
                {
                    totalRecuperadoPassivo = 0;
                }
                else
                {

                    foreach (double val in valoresRecuperadoPassivo)
                    {
                        totalRecuperadoPassivo += val;
                    }
                }


                ViewData["TotalRecuperadoPassivo"] = totalRecuperadoPassivo;
            }
            catch (Exception ex)
            {

            }



            if (id == null || _context.Ocorrencia == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia.FindAsync(id);
            if (ocorrencia == null)
            {
                return NotFound();
            }


            var anexos = _context.Anexo.Where(a => a.OcorrenciaId == ocorrencia.Id)
                 .Select(a =>
                 new Anexo
                 {
                     Id = a.Id,
                     DataAnexo = a.DataAnexo,
                     Autor = a.Autor,
                     NomeAnexo = a.NomeAnexo,
                     OcorrenciaId = a.OcorrenciaId,
                     TipoAnexo = a.TipoAnexo,
                     DescricaoAnexo = a.DescricaoAnexo
                 }).ToList();

            ocorrencia.Anexo = anexos;

            var perdas = _context.Perda.Where(p => p.OcorrenciaId == ocorrencia.Id)
                 .Select(p =>
                 new Perda
                 {
                     Id = p.Id,
                     NumeroBOSinistroRede = p.NumeroBOSinistroRede,
                     TipoEquipamento = p.TipoEquipamento,
                     QuantidadePerda = p.QuantidadePerda,
                     CodigoSinistro = p.CodigoSinistro,
                     ValorPerda = p.ValorPerda,
                     ValorEfetivamenteRecuperado = p.ValorEfetivamenteRecuperado,
                     ValorPerdaEvitada = p.ValorPerdaEvitada,
                     OcorrenciaId = p.OcorrenciaId

                 }).ToList();

            ocorrencia.Perda = perdas;

            var envolvidos = _context.Envolvido.Where(e => e.OcorrenciaId == ocorrencia.Id)
                 .Select(e =>
                 new Envolvido
                 {
                     Id = e.Id,
                     NomeEnvolvido = e.NomeEnvolvido,
                     CPF = e.CPF,
                     RG = e.RG,
                     PlacaVeiculo = e.PlacaVeiculo,
                     Justificativa = e.Justificativa,
                     TipoEnvolvimento = e.TipoEnvolvimento,
                     AcaoTomada = e.AcaoTomada,
                     OcorrenciaId = e.OcorrenciaId

                 }).ToList();

            ocorrencia.Envolvido = envolvidos;

            ViewData["AcionadoProntoAtendimentoId"] = new SelectList(_context.AcionadoProntoAtendimento, "Id", "NomeAcionadoProntoAtendimento");
            ViewData["AlarmeRealAcidenteId"] = new SelectList(_context.AlarmeRealAcidente, "Id", "NomeAlarmeRealAcidente");
            ViewData["AnaliseConclusaoId"] = new SelectList(_context.AnaliseConclusao, "Id", "NomeAnaliseConclusao");
            ViewData["AreaInternaId"] = new SelectList(_context.AreaInterna, "Id", "NomeAreaInterna");
            ViewData["AreaSaudeId"] = new SelectList(_context.AreaSaude, "Id", "NomeAreaSaude");
            ViewData["AreaTratamentoId"] = new SelectList(_context.AreaTratamento, "Id", "NomeAreaTratamento");
            ViewData["AtendimentoSLAId"] = new SelectList(_context.AtendimentoSLA, "Id", "NomeAtendimentoSLA");
            ViewData["BombeiroCivilId"] = new SelectList(_context.BombeiroCivil, "Id", "NomeBombeiroCivil");
            ViewData["BombeiroMilitarId"] = new SelectList(_context.BombeiroMilitar, "Id", "Id");
            ViewData["CmcId"] = new SelectList(_context.Cmc, "Id", "NomeCmc");
            ViewData["DetentoraId"] = new SelectList(_context.Detentora, "Id", "NomeDetentora");
            ViewData["EmpresaChamadoSisId"] = new SelectList(_context.EmpresaChamadoSis, "Id", "NomeEmpresaChamadoSis");
            ViewData["EmpresaProntoAtendimentoId"] = new SelectList(_context.EmpresaProntoAtendimento, "Id", "Id");
            ViewData["EquipamentoSisId"] = new SelectList(_context.EquipamentoSis, "Id", "NomeEquipamentoSis");
            ViewData["EventoERBId"] = new SelectList(_context.EventoERB, "Id", "NomeEventoERB");
            ViewData["FornecimentoAcessoFisicoId"] = new SelectList(_context.FornecimentoAcessoFisico, "Id", "NomeFornecimentoAcessoFisico");
            ViewData["FornecimentoEventoAlarmeId"] = new SelectList(_context.FornecimentoEventoAlarme, "Id", "NomeFornecimentoEventoAlarme");
            ViewData["FornecimentoImagemId"] = new SelectList(_context.FornecimentoImagem, "Id", "NomeFornecimentoImagem");
            ViewData["InboxId"] = new SelectList(_context.Inbox, "Id", "NomeInbox");
            ViewData["InformacaoComplementarId"] = new SelectList(_context.InformacaoComplementar, "Id", "NomeInformacaoComplementar");
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "NomeLocal");
            ViewData["ManutencaoId"] = new SelectList(_context.Manutencao, "Id", "Id");
            ViewData["OrgaoPublicoId"] = new SelectList(_context.OrgaoPublico, "Id", "NomeOrgaoPublico");
            ViewData["PlacaId"] = new SelectList(_context.Placa, "Id", "Id");
            ViewData["PlanoDeEmergenciaId"] = new SelectList(_context.PlanoDeEmergencia, "Id", "NomePlanoDeEmergencia");
            ViewData["QualificacaoId"] = new SelectList(_context.Qualificacao, "Id", "NomeQualificacao");
            ViewData["RegistroPolicialId"] = new SelectList(_context.RegistroPolicial, "Id", "NomeRegistroPolicial");
            ViewData["SistemaFechaduraBluetoothId"] = new SelectList(_context.SistemaFechaduraBluetooth, "Id", "NomeSistemaFechaduraBluetooth");
            ViewData["SistemaRastreamentoId"] = new SelectList(_context.SistemaRastreamento, "Id", "NomeSistemaRastreamento");
            ViewData["SistemaSisId"] = new SelectList(_context.SistemaSis, "Id", "NomeSistemaSis");
            ViewData["TipoAcessoId"] = new SelectList(_context.TipoAcesso, "Id", "NomeTipoAcesso");
            ViewData["TipoOcorrenciaId"] = new SelectList(_context.TipoOcorrencia, "Id", "NomeTipoOcorrencia");
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite");
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadora, "Id", "NomeTransportadora");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "NomeStatus");
            ViewData["GestaoQualidadeId"] = new SelectList(_context.GestaoQualidade, "Id", "NomeGestaoQualidade");
            ViewData["GestaoPerdaId"] = new SelectList(_context.GestaoPerda, "Id", "NomeGestaoPerda");
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "NomeEmpresa");
            ViewData["SeguimentoId"] = new SelectList(_context.Seguimento, "Id", "NomeSeguimento");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NomeSite");
            ViewData["ResponsavelAveriguacaoId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");
            ViewData["ResponsavelOperacionalId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");
            ViewData["StatusSiteId"] = new SelectList(_context.Site, "Id", "NomeStatusSite");

            return View(ocorrencia);
        }


        #region propriedades estaticas para verificar alteracoes

        public static string _teste { get; set; }
        public static string? InformacaoOrigem { get; set; }
        public static string? Status { get; set; }
        public static string? Inbox { get; set; }
        public static string? CargoFuncao { get; set; }
        public static string? TipoSite { get; set; }
        public static string? NomeSite { get; set; }
        public static string? TipoOcorrencia { get; set; }
        public static string? Qualificacao { get; set; }
        public static string? InformacaoComplementar { get; set; }
        public static string? SistemaRastreamento { get; set; }
        public static string? SistemaFechaduraBluetooth { get; set; }
        public static string? Detentora { get; set; }
        public static string? Local { get; set; }
        public static string? Ambiente { get; set; }
        public static string? Transportadora { get; set; }
        public static string? EventoERB { get; set; }
        public static string? AlarmeRealAcidente { get; set; }
        public static string? TipoAlarme { get; set; }
        public static string? Historico { get; set; }
        public static string? ResponsavelOperacional { get; set; }
        public static string? OrgaoPublico { get; set; }
        public static string? PlanoDeEmergencia { get; set; }
        public static string? BombeiroCivil { get; set; }
        public static string? AreaInterna { get; set; }
        public static string? AcionadoProntoAtendimento { get; set; }
        public static string? DataAcionamentoProntoAtendimento { get; set; }
        public static string? AreaSaude { get; set; }
        public static string? Placa { get; set; }
        public static string? Condutor { get; set; }
        public static string? Empresa { get; set; }
        public static string? GestaoQualidade { get; set; }
        public static string? Observacao { get; set; }
        public static string? SistemaSis { get; set; }
        public static string? EquipamentoSis { get; set; }
        public static string? EmpresaChamadoSis { get; set; }
        public static string? MotivoSis { get; set; }
        public static string? DataConclusaoSis { get; set; }
        public static string? DataReagendamentoSis { get; set; }
        public static string? ObservacaoSis { get; set; }
        public static string? FornecimentoImagem { get; set; }
        public static string? FornecimentoAcessoFisico { get; set; }
        public static string? FornecimentoEventoAlarme { get; set; }
        public static string? RegistroPolicial { get; set; }
        public static string? NumeroRegistroPolicial { get; set; }
        public static string? AtendimentoSLA { get; set; }
        public static string? TipoAcesso { get; set; }
        public static string? Seguimento { get; set; }
        public static string? DataConclusao { get; set; }
        public static string? DiasConclusao { get; set; }
        public static string? DiasConclusaoSis { get; set; }
        public static string? AnaliseConclusao { get; set; }
        public static string? ProvidenciaConclusao { get; set; }
        public static string? Conclusao { get; set; }

        #endregion

        public void ReceberDadosAoCarregarPagina(string idTestando, string informacaoOrigem, string status, string inbox, string cargoFuncao, string tipoSite,
            string nomeSite, string tipoOcorrencia, string qualificacao, string informacaoComplementar, string sistemaRastreamento,
            string sistemaFechaduraBluetooth, string detentora, string local, string ambiente, string transportadora, string eventoERB,
            string alarmeRealAcidente, string tipoAlarme, string historico, string responsavelOperacional, string orgaoPublico,
            string planoDeEmergencia, string bombeiroCivil, string areaInterna, string acionadoProntoAtendimento, string dataAcionamentoProntoAtendimento,
            string areaSaude, string placa, string condutor, string empresa, string gestaoQualidade, string observacao,
            string sistemaSis, string equipamentoSis, string empresaChamadoSis, string motivoSis, string dataConclusaoSis, string dataReagendamentoSis,
            string observacaoSis, string fornecimentoImagem, string fornecimentoAcessoFisico, string fornecimentoEventoAlarme,
            string registroPolicial, string numeroRegistroPolicial, string atendimentoSLA, string tipoAcesso, string seguimento,
            string dataConclusao, string diasConclusao, string diasConclusaoSis, string analiseConclusao, string providenciaConclusao,
            string conclusao)
        {
            _teste = idTestando;
            InformacaoOrigem = informacaoOrigem;
            Status = status;
            Inbox = inbox;
            CargoFuncao = cargoFuncao;
            TipoSite = tipoSite;
            NomeSite = nomeSite;
            TipoOcorrencia = tipoOcorrencia;
            Qualificacao = qualificacao;
            InformacaoComplementar = informacaoComplementar;
            SistemaRastreamento = sistemaRastreamento;
            SistemaFechaduraBluetooth = sistemaFechaduraBluetooth;
            Detentora = detentora;
            Local = local;
            Ambiente = ambiente;
            Transportadora = transportadora;
            EventoERB = eventoERB;
            AlarmeRealAcidente = alarmeRealAcidente;
            TipoAlarme = tipoAlarme;
            Historico = historico;
            ResponsavelOperacional = responsavelOperacional;
            OrgaoPublico = orgaoPublico;
            PlanoDeEmergencia = planoDeEmergencia;
            BombeiroCivil = bombeiroCivil;
            AreaInterna = areaInterna;
            AcionadoProntoAtendimento = acionadoProntoAtendimento;
            DataAcionamentoProntoAtendimento = dataAcionamentoProntoAtendimento;
            AreaSaude = areaSaude;
            Placa = placa;
            Condutor = condutor;
            Empresa = empresa;
            GestaoQualidade = gestaoQualidade;
            Observacao = observacao;
            SistemaSis = sistemaSis;
            EquipamentoSis = equipamentoSis;
            EmpresaChamadoSis = empresaChamadoSis;
            MotivoSis = motivoSis;
            DataConclusaoSis = dataConclusaoSis;
            DataReagendamentoSis = dataReagendamentoSis;
            ObservacaoSis = observacaoSis;
            FornecimentoImagem = fornecimentoImagem;
            FornecimentoAcessoFisico = fornecimentoAcessoFisico;
            FornecimentoEventoAlarme = fornecimentoEventoAlarme;
            RegistroPolicial = registroPolicial;
            NumeroRegistroPolicial = numeroRegistroPolicial;
            AtendimentoSLA = atendimentoSLA;
            TipoAcesso = tipoAcesso;
            Seguimento = seguimento;
            DataConclusao = dataConclusao;
            DiasConclusao = diasConclusao;
            DiasConclusaoSis = diasConclusaoSis;
            AnaliseConclusao = analiseConclusao;
            ProvidenciaConclusao = providenciaConclusao;
            Conclusao = conclusao;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.Id)
            {
                return NotFound();
            }


            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var valorPerdaTotal = _context.Ocorrencia.Where(o => o.Id == id).Select(o => o.ValorPerdaTotal).FirstOrDefault();
            ocorrencia.ValorPerdaTotal = valorPerdaTotal;

            var dataRegistro = _context.Ocorrencia.Where(o => o.Id == id).Select(o => o.DataRegistro.Value).FirstOrDefault();

            DateTime dataConclusao;

            DateTime dataAtual;

            double diasConclusao;

            int status;

            if (ocorrencia.DataConclusao == (DateTime)ocorrencia.DataConclusao)
            {
                ocorrencia.StatusId = 2;
            }

            try
            {
                dataConclusao = (DateTime)ocorrencia.DataConclusao;
                diasConclusao = dataConclusao.Subtract(dataRegistro).TotalDays;
            }
            catch (Exception ex)
            {
                diasConclusao = 0;
            }

            try
            {
                ocorrencia.UsuarioAlteracaoOcorrenciaId = userId;
                ocorrencia.DiasConclusao = (int)diasConclusao;
                _context.Update(ocorrencia);
                Notify(title: "OK!", message: "Ocorrência alterada com sucesso!", notificationType: Notification.success);
                await _context.SaveChangesAsync();

                //_logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1]);

                VerificacaoDeAlteracoes(ocorrencia);

                return RedirectToAction("Edit", "Ocorrencias", new { id = id });
            }
            catch (Exception ex)
            {
                Notify(title: "Oops!", message: "Erro ao alterar ocorrência!", notificationType: Notification.warning);
                return RedirectToAction("Edit", "Ocorrencias", new { id = id });
            }

        }

        public void VerificacaoDeAlteracoes(Ocorrencia ocorrencia)
        {
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var testando = _teste;

            string campo = "";

            if (InformacaoOrigem != ocorrencia.InformacaoOrigem)
            {
                campo = "Informação Origem";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, InformacaoOrigem, ocorrencia.InformacaoOrigem, ocorrencia.Id);
            }

            var statusNome = _context.Status.Where(s => s.Id == ocorrencia.StatusId).Select(s => s.NomeStatus).FirstOrDefault();
            if (Status != statusNome)
            {
                campo = "Status";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Status, statusNome, ocorrencia.Id);
            }

            var inboxNome = _context.Inbox.Where(s => s.Id == ocorrencia.InboxId).Select(s => s.NomeInbox).FirstOrDefault();
            if (Inbox != inboxNome && Inbox != "Selecione...")
            {
                campo = "Inbox";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Inbox, inboxNome, ocorrencia.Id);
            }

            if (CargoFuncao != ocorrencia.CargoFuncao)
            {
                campo = "Cargo Função";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, CargoFuncao, ocorrencia.CargoFuncao, ocorrencia.Id);
            }

            var tipoSiteNome = _context.TipoSite.Where(s => s.Id == ocorrencia.TipoSiteId).Select(s => s.NomeTipoSite).FirstOrDefault();
            if (TipoSite != tipoSiteNome && TipoSite != "Selecione...")
            {
                campo = "Tipo Site";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, TipoSite, tipoSiteNome, ocorrencia.Id);
            }

            var nomeSite = _context.Site.Where(s => s.Id == ocorrencia.SiteId).Select(s => s.NomeSite).FirstOrDefault();
            if (NomeSite != nomeSite && NomeSite != "Selecione...")
            {
                campo = "Nome Site";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, NomeSite, nomeSite, ocorrencia.Id);
            }

            var tipoOcorrencia = _context.TipoOcorrencia.Where(s => s.Id == ocorrencia.TipoOcorrenciaId).Select(s => s.NomeTipoOcorrencia).FirstOrDefault();
            if (TipoOcorrencia != tipoOcorrencia && TipoOcorrencia != "Selecione...")
            {
                campo = "Tipo Ocorrência";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, TipoOcorrencia, tipoOcorrencia, ocorrencia.Id);
            }

            var qualificacao = _context.Qualificacao.Where(s => s.Id == ocorrencia.QualificacaoId).Select(s => s.NomeQualificacao).FirstOrDefault();
            if (Qualificacao != qualificacao && Qualificacao != "Selecione...")
            {
                campo = "Qualificação";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Qualificacao, qualificacao, ocorrencia.Id);
            }

            var informacaoComplementar = _context.InformacaoComplementar.Where(s => s.Id == ocorrencia.InformacaoComplementarId).Select(s => s.NomeInformacaoComplementar).FirstOrDefault();
            if (InformacaoComplementar != informacaoComplementar && InformacaoComplementar != "Selecione...")
            {
                campo = "Informação Complementar";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, InformacaoComplementar, informacaoComplementar, ocorrencia.Id);
            }

            var sistemaRastreamento = _context.SistemaRastreamento.Where(s => s.Id == ocorrencia.SistemaRastreamentoId).Select(s => s.NomeSistemaRastreamento).FirstOrDefault();
            if (SistemaRastreamento != sistemaRastreamento && SistemaRastreamento != "Selecione...")
            {
                campo = "Sistema Rastreamento";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, SistemaRastreamento, sistemaRastreamento, ocorrencia.Id);
            }

            var sistemaFechaduraBluetooth = _context.SistemaFechaduraBluetooth.Where(s => s.Id == ocorrencia.SistemaFechaduraBluetoothId).Select(s => s.NomeSistemaFechaduraBluetooth).FirstOrDefault();
            if (SistemaFechaduraBluetooth != sistemaFechaduraBluetooth && SistemaFechaduraBluetooth != "Selecione...")
            {
                campo = "Sistema Fechadura Bluetooth";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, SistemaFechaduraBluetooth, sistemaFechaduraBluetooth, ocorrencia.Id);
            }

            var detentora = _context.Detentora.Where(s => s.Id == ocorrencia.DetentoraId).Select(s => s.NomeDetentora).FirstOrDefault();
            if (Detentora != detentora && Detentora != "Selecione...")
            {
                campo = "Detentora";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Detentora, detentora, ocorrencia.Id);
            }

            var local = _context.Local.Where(s => s.Id == ocorrencia.LocalId).Select(s => s.NomeLocal).FirstOrDefault();
            if (Local != local && Local != "Selecione...")
            {
                campo = "Local";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Local, local, ocorrencia.Id);
            }

            if (Ambiente != ocorrencia.Ambiente)
            {
                campo = "Ambiente";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Ambiente, ocorrencia.Ambiente, ocorrencia.Id);
            }

            var transportadora = _context.Transportadora.Where(s => s.Id == ocorrencia.TransportadoraId).Select(s => s.NomeTransportadora).FirstOrDefault();
            if (Transportadora != transportadora && Transportadora != "Selecione...")
            {
                campo = "Transportadora";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Transportadora, transportadora, ocorrencia.Id);
            }

            var eventoERB = _context.EventoERB.Where(s => s.Id == ocorrencia.EventoERBId).Select(s => s.NomeEventoERB).FirstOrDefault();
            if (EventoERB != eventoERB && EventoERB != "Selecione...")
            {
                campo = "Evento ERB";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, EventoERB, eventoERB, ocorrencia.Id);
            }

            var alarmeRealAcidente = _context.AlarmeRealAcidente.Where(s => s.Id == ocorrencia.AlarmeRealAcidenteId).Select(s => s.NomeAlarmeRealAcidente).FirstOrDefault();
            if (AlarmeRealAcidente != alarmeRealAcidente && AlarmeRealAcidente != "Selecione...")
            {
                campo = "Alarme Real Acidente";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, AlarmeRealAcidente, alarmeRealAcidente, ocorrencia.Id);
            }

            if (TipoAlarme != ocorrencia.TipoAlarme)
            {
                campo = "Tipo Alarme";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, TipoAlarme, ocorrencia.TipoAlarme, ocorrencia.Id);
            }

            if (Historico != ocorrencia.Historico)
            {
                campo = "Histórico";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Historico, ocorrencia.Historico, ocorrencia.Id);
            }

            var responsavelOperacional = _context.Usuario.Where(s => s.UsuarioId == ocorrencia.ResponsavelOperacionalId).Select(s => s.UsuarioId).FirstOrDefault();
            if (ResponsavelOperacional != responsavelOperacional && ResponsavelOperacional != "Selecione...")
            {
                campo = "Responsável Operacional";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, ResponsavelOperacional, responsavelOperacional, ocorrencia.Id);
            }

            var orgaoPublico = _context.OrgaoPublico.Where(s => s.Id == ocorrencia.OrgaoPublicoId).Select(s => s.NomeOrgaoPublico).FirstOrDefault();
            if (OrgaoPublico != orgaoPublico && OrgaoPublico != "Selecione...")
            {
                campo = "Orgão Público";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, OrgaoPublico, orgaoPublico, ocorrencia.Id);
            }

            var planoDeEmergencia = _context.PlanoDeEmergencia.Where(s => s.Id == ocorrencia.PlanoDeEmergenciaId).Select(s => s.NomePlanoDeEmergencia).FirstOrDefault();
            if (PlanoDeEmergencia != planoDeEmergencia && PlanoDeEmergencia != "Selecione...")
            {
                campo = "Plano de Emergência";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, PlanoDeEmergencia, planoDeEmergencia, ocorrencia.Id);
            }

            var bombeiroCivil = _context.BombeiroCivil.Where(s => s.Id == ocorrencia.BombeiroCivilId).Select(s => s.NomeBombeiroCivil).FirstOrDefault();
            if (BombeiroCivil != bombeiroCivil && BombeiroCivil != "Selecione...")
            {
                campo = "Bombeiro Civil";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, BombeiroCivil, bombeiroCivil, ocorrencia.Id);
            }

            var areaInterna = _context.AreaInterna.Where(s => s.Id == ocorrencia.AreaInternaId).Select(s => s.NomeAreaInterna).FirstOrDefault();
            if (AreaInterna != areaInterna && AreaInterna != "Selecione...")
            {
                campo = "Área Interna";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, AreaInterna, areaInterna, ocorrencia.Id);
            }

            var acionadoProntoAtendimento = _context.AcionadoProntoAtendimento.Where(s => s.Id == ocorrencia.AcionadoProntoAtendimentoId).Select(s => s.NomeAcionadoProntoAtendimento).FirstOrDefault();
            if (AcionadoProntoAtendimento != acionadoProntoAtendimento && AcionadoProntoAtendimento != "Selecione...")
            {
                campo = "Acionado Pronto Atendimento";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, AcionadoProntoAtendimento, acionadoProntoAtendimento, ocorrencia.Id);
            }


            var areaSaude = _context.AreaSaude.Where(s => s.Id == ocorrencia.AreaSaudeId).Select(s => s.NomeAreaSaude).FirstOrDefault();
            if (AreaSaude != areaSaude && AreaSaude != "Selecione...")
            {
                campo = "Área Saúde";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, AreaSaude, areaSaude, ocorrencia.Id);
            }

            if (Placa != ocorrencia.Placa)
            {
                campo = "Placa";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Placa, ocorrencia.Placa, ocorrencia.Id);
            }

            if (Condutor != ocorrencia.Condutor)
            {
                campo = "Condutor";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Condutor, ocorrencia.Condutor, ocorrencia.Id);
            }

            var empresa = _context.Empresa.Where(s => s.Id == ocorrencia.EmpresaId).Select(s => s.NomeEmpresa).FirstOrDefault();
            if (Empresa != empresa && Empresa != "Selecione...")
            {
                campo = "Empresa";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Empresa, empresa, ocorrencia.Id);
            }

            var gestaoQualidade = _context.GestaoQualidade.Where(s => s.Id == ocorrencia.GestaoQualidadeId).Select(s => s.NomeGestaoQualidade).FirstOrDefault();
            if (GestaoQualidade != gestaoQualidade && GestaoQualidade != "Selecione...")
            {
                campo = "Gestão Qualidade";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, GestaoQualidade, gestaoQualidade, ocorrencia.Id);
            }

            var sistemaSis = _context.SistemaSis.Where(s => s.Id == ocorrencia.SistemaSisId).Select(s => s.NomeSistemaSis).FirstOrDefault();
            if (SistemaSis != sistemaSis && SistemaSis != "Selecione...")
            {
                campo = "Sistema Sis";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, SistemaSis, sistemaSis, ocorrencia.Id);
            }

            var equipamentoSis = _context.EquipamentoSis.Where(s => s.Id == ocorrencia.EquipamentoSisId).Select(s => s.NomeEquipamentoSis).FirstOrDefault();
            if (EquipamentoSis != equipamentoSis && EquipamentoSis != "Selecione...")
            {
                campo = "Equipamento Sis";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, EquipamentoSis, equipamentoSis, ocorrencia.Id);
            }

            var empresaChamadoSis = _context.EmpresaChamadoSis.Where(s => s.Id == ocorrencia.EmpresaChamadoSisId).Select(s => s.NomeEmpresaChamadoSis).FirstOrDefault();
            if (EmpresaChamadoSis != empresaChamadoSis && EmpresaChamadoSis != "Selecione...")
            {
                campo = "Empresa Chamado Sis";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, EmpresaChamadoSis, empresaChamadoSis, ocorrencia.Id);
            }

            if (MotivoSis != ocorrencia.MotivoSis)
            {
                campo = "Motivo Sis";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, MotivoSis, ocorrencia.MotivoSis, ocorrencia.Id);
            }

            if (ObservacaoSis != ocorrencia.ObservacaoSis)
            {
                campo = "Observação Sis";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, ObservacaoSis, ocorrencia.ObservacaoSis, ocorrencia.Id);
            }

            var fornecimentoImagem = _context.FornecimentoImagem.Where(s => s.Id == ocorrencia.FornecimentoImagemId).Select(s => s.NomeFornecimentoImagem).FirstOrDefault();
            if (FornecimentoImagem != fornecimentoImagem && FornecimentoImagem != "Selecione...")
            {
                campo = "Fornecimento Imagem";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, FornecimentoImagem, fornecimentoImagem, ocorrencia.Id);
            }

            var fornecimentoAcessoFisico = _context.FornecimentoAcessoFisico.Where(s => s.Id == ocorrencia.FornecimentoAcessoFisicoId).Select(s => s.NomeFornecimentoAcessoFisico).FirstOrDefault();
            if (FornecimentoAcessoFisico != fornecimentoAcessoFisico && FornecimentoAcessoFisico != "Selecione...")
            {
                campo = "Fornecimento Acesso Físico";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, FornecimentoAcessoFisico, fornecimentoAcessoFisico, ocorrencia.Id);
            }

            var fornecimentoEventoAlarme = _context.FornecimentoEventoAlarme.Where(s => s.Id == ocorrencia.FornecimentoEventoAlarmeId).Select(s => s.NomeFornecimentoEventoAlarme).FirstOrDefault();
            if (FornecimentoEventoAlarme != fornecimentoEventoAlarme && FornecimentoEventoAlarme != "Selecione...")
            {
                campo = "Fornecimento Evento Alarme";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, FornecimentoEventoAlarme, fornecimentoEventoAlarme, ocorrencia.Id);
            }


            var registroPolicial = _context.RegistroPolicial.Where(s => s.Id == ocorrencia.RegistroPolicialId).Select(s => s.NomeRegistroPolicial).FirstOrDefault();
            if (RegistroPolicial != registroPolicial && RegistroPolicial != "Selecione...")
            {
                campo = "Fornecimento Evento Alarme";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, RegistroPolicial, registroPolicial, ocorrencia.Id);
            }

            if (NumeroRegistroPolicial != ocorrencia.NumeroRegistroPolicial)
            {
                campo = "Número Registro Policial";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, NumeroRegistroPolicial, ocorrencia.NumeroRegistroPolicial, ocorrencia.Id);
            }

            var atendimentoSLA = _context.AtendimentoSLA.Where(s => s.Id == ocorrencia.AtendimentoSLAId).Select(s => s.NomeAtendimentoSLA).FirstOrDefault();
            if (AtendimentoSLA != atendimentoSLA && AtendimentoSLA != "Selecione...")
            {
                campo = "Atendimento SLA";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, AtendimentoSLA, atendimentoSLA, ocorrencia.Id);
            }

            var tipoAcesso = _context.TipoAcesso.Where(s => s.Id == ocorrencia.TipoAcessoId).Select(s => s.NomeTipoAcesso).FirstOrDefault();
            if (TipoAcesso != tipoAcesso && TipoAcesso != "Selecione...")
            {
                campo = "Tipo Acesso";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, TipoAcesso, tipoAcesso, ocorrencia.Id);
            }

            var seguimento = _context.Seguimento.Where(s => s.Id == ocorrencia.SeguimentoId).Select(s => s.NomeSeguimento).FirstOrDefault();
            if (Seguimento != seguimento && Seguimento != "Selecione...")
            {
                campo = "Seguimento";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Seguimento, seguimento, ocorrencia.Id);
            }


            var analiseConclusao = _context.AnaliseConclusao.Where(s => s.Id == ocorrencia.AnaliseConclusaoId).Select(s => s.NomeAnaliseConclusao).FirstOrDefault();
            if (AnaliseConclusao != AnaliseConclusao && AnaliseConclusao != "Selecione...")
            {
                campo = "Análise Conclusão";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, AnaliseConclusao, analiseConclusao, ocorrencia.Id);
            }

            if (ProvidenciaConclusao != ocorrencia.ProvidenciaConclusao)
            {
                campo = "Providência Conclusão";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, ProvidenciaConclusao, ocorrencia.ProvidenciaConclusao, ocorrencia.Id);
            }

            if (Conclusao != ocorrencia.Conclusao)
            {
                campo = "Conclusão";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, Conclusao, ocorrencia.Conclusao, ocorrencia.Id);
            }

            if (DiasConclusao != ocorrencia.DiasConclusao.ToString())
            {
                campo = "Dias Conclusão";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, DiasConclusao, ocorrencia.DiasConclusao, ocorrencia.Id);
            }

            if (DiasConclusaoSis != ocorrencia.DiasConclusaoSis.ToString() && DiasConclusaoSis != null)
            {
                campo = "Dias Conclusão Sis";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, DiasConclusaoSis, ocorrencia.DiasConclusaoSis, ocorrencia.Id);
            }


            string dataAcionamentoConvertida = string.Format("{0:dd/MM/yyyy}", ocorrencia.DataAcionamentoProntoAtendimento);
            if (DataAcionamentoProntoAtendimento != dataAcionamentoConvertida && DataAcionamentoProntoAtendimento != "0")
            {
                campo = "Data Acionamento Pronto Atendimento";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, DataAcionamentoProntoAtendimento, dataAcionamentoConvertida, ocorrencia.Id);
            }

            string dataConclusaoSisConvertida = string.Format("{0:dd/MM/yyyy}", ocorrencia.DataConclusaoSis);
            if (DataConclusaoSis != dataConclusaoSisConvertida && DataConclusaoSis != "0")
            {
                campo = "Data Acionamento Pronto Atendimento";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, DataConclusaoSis, dataConclusaoSisConvertida, ocorrencia.Id);
            }

            string dataReagendamentoSisConvertida = string.Format("{0:dd/MM/yyyy}", ocorrencia.DataReagendamentoSis);
            if (DataReagendamentoSis != dataReagendamentoSisConvertida && DataReagendamentoSis != "0")
            {
                campo = "Data Reagendamento Sis";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, DataReagendamentoSis, dataReagendamentoSisConvertida, ocorrencia.Id);
            }

            string dataConclusaoConvertida = string.Format("{0:dd/MM/yyyy}", ocorrencia.DataConclusao);
            if (DataConclusao != dataConclusaoConvertida && DataConclusao != "0")
            {
                campo = "Data Conclusão";
                _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}{Campo}{ConteudoAnterior}{ConteudoAtual}{ROV}", $"{userId} alterou a ocorrência {ocorrencia.Id}", userId, IpAndHostname[0], IpAndHostname[1], campo, DataConclusao, dataConclusaoConvertida, ocorrencia.Id);
            }

        }


        // GET: Ocorrencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ocorrencia == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .Include(o => o.AcionadoProntoAtendimento)
                .Include(o => o.AlarmeRealAcidente)
                .Include(o => o.AnaliseConclusao)
                .Include(o => o.AreaInterna)
                .Include(o => o.AreaSaude)
                .Include(o => o.AreaTratamento)
                .Include(o => o.AtendimentoSLA)
                .Include(o => o.BombeiroCivil)
                .Include(o => o.BombeiroMilitar)
                .Include(o => o.Cmc)
                .Include(o => o.Condutor)
                .Include(o => o.Detentora)
                .Include(o => o.EmpresaChamadoSis)
                .Include(o => o.EmpresaProntoAtendimento)
                .Include(o => o.EquipamentoSis)
                .Include(o => o.EventoERB)
                .Include(o => o.FornecimentoAcessoFisico)
                .Include(o => o.FornecimentoEventoAlarme)
                .Include(o => o.FornecimentoImagem)
                .Include(o => o.Inbox)
                .Include(o => o.InformacaoComplementar)
                .Include(o => o.Local)
                .Include(o => o.Manutencao)
                .Include(o => o.OrgaoPublico)
                .Include(o => o.Placa)
                .Include(o => o.PlanoDeEmergencia)
                .Include(o => o.Qualificacao)
                .Include(o => o.RegistroPolicial)
                .Include(o => o.SistemaFechaduraBluetooth)
                .Include(o => o.SistemaRastreamento)
                .Include(o => o.SistemaSis)
                .Include(o => o.TipoAcesso)
                .Include(o => o.TipoAlarme)
                .Include(o => o.TipoOcorrencia)
                .Include(o => o.TipoSite)
                .Include(o => o.Transportadora)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            return View(ocorrencia);
        }

        // POST: Ocorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ocorrencia == null)
            {
                return Problem("Entity set 'RovDbContext.Ocorrencia'  is null.");
            }
            var ocorrencia = await _context.Ocorrencia.FindAsync(id);
            if (ocorrencia != null)
            {
                _context.Ocorrencia.Remove(ocorrencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcorrenciaExists(int id)
        {
            return _context.Ocorrencia.Any(e => e.Id == id);
        }

        [HttpGet]
        public JsonResult GetSites(int id)
        {
            string query = $"SELECT Id, UF, Municipio, Endereco, CEP FROM Site WHERE Id = {id}";

            var userId = User.Identity.Name.Split("\\")[1];

            var database = new Database(_configuration);
            var command = database.GetCommand(query);

            Site item = new Site();

            try
            {
                var reader = command.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {

                    item.Id = Convert.ToInt32(reader["Id"].ToString());
                    item.UF = reader["UF"].ToString();
                    item.Municipio = reader["Municipio"].ToString();
                    item.Endereco = reader["Endereco"].ToString();
                    item.CEP = reader["CEP"].ToString();
                }
                reader.Close();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                command.Connection.Close();
            }

            var json = JsonConvert.SerializeObject(item);

            //return Json(json, new Newtonsoft.Json.JsonSerializerSettings());
            return Json(new { site = item });
        }

        public JsonResult GetSitesByTipoSite(int id)

        {
            var item = _context.Site.Where(s => s.TipoSiteId == id).Select(s => s.NomeSite).ToList();
            var ids = _context.Site.Where(s => s.TipoSiteId == id).Select(s => s.Id).ToList();

            return Json(new { site = item, ids });
        }

        public void AdicionarSite(int tipoSite, string nomeSite, string uf, string municipio, string endereco, string cep, int sistemaBluetooth, int sistemaRastreamento, int statusSite)
        {
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var ufMaiusculo = uf.ToUpper();
            var municipioMaiusculo = municipio.ToUpper();
            var enderecoMaiusculo = endereco.ToUpper();


            var site = new Site(tipoSite, nomeSite, ufMaiusculo, municipioMaiusculo, enderecoMaiusculo, cep, sistemaBluetooth, sistemaRastreamento, statusSite);

            _context.Add(site);
            _context.SaveChangesAsync();

            _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} adicionou um novo site com nome {nomeSite}", userId, IpAndHostname[0], IpAndHostname[1]);

        }

        public JsonResult GetNomeSiteAoCarregarEdit(int idOcorrencia)
        {
            var item = _context.Ocorrencia.Where(s => s.Id == idOcorrencia).Select(s => s.SiteId).FirstOrDefault();

            return Json(new { site = item });
        }

        public DateTime FormatacaoDataSemMilissegundos(DateTime dataAgora)
        {
            string dataFormatada = dataAgora.ToString();
            dataFormatada = dataFormatada.Remove(dataFormatada.Length - 4);
            var DataSemMilissegundos = Convert.ToDateTime(dataFormatada);
            return DataSemMilissegundos;
        }

        public JsonResult GetIdTipoSiteTipoOcorrencia(int idTipoSite)
        {
            var listaDeTipoOcorrencia = _context.TipoOcorrenciaTipoSite.Where(t => t.TipoSiteId == idTipoSite).Select(t => t.TipoOcorrenciaId).ToList();
            List<string> listaDeNomesTipoOcorrencia = new List<string> { };

            foreach (var item in listaDeTipoOcorrencia)
            {
                listaDeNomesTipoOcorrencia.Add(_context.TipoOcorrencia.Where(t => t.Id == item).Select(t => t.NomeTipoOcorrencia).FirstOrDefault());
            }

            return Json(new { listaDeTipoOcorrencia, listaDeNomesTipoOcorrencia });
        }

        public JsonResult GetIdTipoOcorrencia(int idOcorrencia)
        {
            var idTipoOcorrencia = _context.Ocorrencia.Where(o => o.Id == idOcorrencia).Select(o => o.TipoOcorrenciaId).FirstOrDefault();
            return Json(  idTipoOcorrencia );
        }

        public FileResult ExportFile()
        {
            var userId = User.Identity.Name.Split("\\")[1];
            List<string> IpAndHostname = GetIpAndHostname();

            var ocorrencias = _context.Ocorrencia
                .Include(o => o.Status)
                .Include(o => o.Cmc)
                .Include(o => o.Inbox)
                .Include(o => o.UsuarioAlteracaoOcorrencia)
                .Include(o => o.TipoSite)
                .Include(o => o.Site)
                .Include(o => o.TipoOcorrencia)
                .Include(o => o.Qualificacao)
                .Include(o => o.InformacaoComplementar)
                .Include(o => o.SistemaRastreamento)
                .Include(o => o.SistemaFechaduraBluetooth)
                .Include(o => o.Detentora)
                .Include(o => o.Local)
                .Include(o => o.Transportadora)
                .Include(o => o.EventoERB)
                .Include(o => o.AlarmeRealAcidente)
                .Include(o => o.AreaTratamento)
                .ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Ocorrencias");

                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Data Ocorrencia";
                worksheet.Cell(currentRow, 3).Value = "Data Registro";
                worksheet.Cell(currentRow, 4).Value = "Status";
                worksheet.Cell(currentRow, 5).Value = "Cmc";
                worksheet.Cell(currentRow, 6).Value = "Inbox";
                worksheet.Cell(currentRow, 7).Value = "Usuário Operador";
                worksheet.Cell(currentRow, 8).Value = "Area Tratamento";
                worksheet.Cell(currentRow, 9).Value = "Última Alteração";
                worksheet.Cell(currentRow, 10).Value = "Informação da Origem";
                worksheet.Cell(currentRow, 11).Value = "Cargo função";
                worksheet.Cell(currentRow, 12).Value = "Tipo Site";
                worksheet.Cell(currentRow, 13).Value = "Nome Site";
                worksheet.Cell(currentRow, 14).Value = "Estado";
                worksheet.Cell(currentRow, 15).Value = "Município";
                worksheet.Cell(currentRow, 16).Value = "CEP";
                worksheet.Cell(currentRow, 17).Value = "Endereço";
                worksheet.Cell(currentRow, 18).Value = "Tipo Ocorrência";
                worksheet.Cell(currentRow, 19).Value = "Qualificação";
                worksheet.Cell(currentRow, 20).Value = "Informação Complementar";
                worksheet.Cell(currentRow, 21).Value = "Sistema Rastreamento";
                worksheet.Cell(currentRow, 22).Value = "Sistema fechadura Bluetooth";
                worksheet.Cell(currentRow, 23).Value = "Detentora";
                worksheet.Cell(currentRow, 24).Value = "Local";
                worksheet.Cell(currentRow, 25).Value = "Ambiente";
                worksheet.Cell(currentRow, 26).Value = "Transportadora";
                worksheet.Cell(currentRow, 27).Value = "Evento EBR";
                worksheet.Cell(currentRow, 28).Value = "Alarme Real Acidental";
                worksheet.Cell(currentRow, 29).Value = "Tipo de Alarme";
                worksheet.Cell(currentRow, 30).Value = "Placa";
                worksheet.Cell(currentRow, 31).Value = "Condutor";
                worksheet.Cell(currentRow, 32).Value = "Histórico";
                worksheet.Cell(currentRow, 33).Value = "Data Conclusão";
                worksheet.Cell(currentRow, 34).Value = "Data Reagendamento";
                worksheet.Cell(currentRow, 35).Value = "Observação";


                foreach (var ocorrencia in ocorrencias)
                {
                    currentRow++;


                    worksheet.Cell(currentRow, 1).Value = ocorrencia.Id;
                    worksheet.Cell(currentRow, 2).Value = ocorrencia.DataOcorrencia;
                    worksheet.Cell(currentRow, 3).Value = ocorrencia.DataRegistro;
                    worksheet.Cell(currentRow, 4).Value = ocorrencia.Status != null ? ocorrencia.Status.NomeStatus : "";
                    worksheet.Cell(currentRow, 5).Value = ocorrencia.Cmc != null ? ocorrencia.Cmc.NomeCmc : "";
                    worksheet.Cell(currentRow, 6).Value = ocorrencia.Inbox != null ? ocorrencia.Inbox.NomeInbox : "";
                    worksheet.Cell(currentRow, 7).Value = ocorrencia.UsuarioOperadorId;
                    worksheet.Cell(currentRow, 8).Value = ocorrencia.AreaTratamento != null ? ocorrencia.AreaTratamento.NomeAreaTratamento : "";
                    worksheet.Cell(currentRow, 9).Value = ocorrencia.UsuarioAlteracaoOcorrenciaId;
                    worksheet.Cell(currentRow, 10).Value = ocorrencia.InformacaoOrigem;
                    worksheet.Cell(currentRow, 11).Value = ocorrencia.CargoFuncao;
                    worksheet.Cell(currentRow, 12).Value = ocorrencia.TipoSite != null ? ocorrencia.TipoSite.NomeTipoSite : "";
                    worksheet.Cell(currentRow, 13).Value = ocorrencia.Site != null ? ocorrencia.Site.NomeSite : "";
                    worksheet.Cell(currentRow, 14).Value = ocorrencia.Estado;
                    worksheet.Cell(currentRow, 15).Value = ocorrencia.Municipio;
                    worksheet.Cell(currentRow, 16).Value = ocorrencia.CEP;
                    worksheet.Cell(currentRow, 17).Value = ocorrencia.Endereco;
                    worksheet.Cell(currentRow, 18).Value = ocorrencia.TipoOcorrencia != null ? ocorrencia.TipoOcorrencia.NomeTipoOcorrencia : "";
                    worksheet.Cell(currentRow, 19).Value = ocorrencia.Qualificacao != null ? ocorrencia.Qualificacao.NomeQualificacao : "";
                    worksheet.Cell(currentRow, 20).Value = ocorrencia.InformacaoComplementar != null ? ocorrencia.InformacaoComplementar.NomeInformacaoComplementar : "";
                    worksheet.Cell(currentRow, 21).Value = ocorrencia.SistemaRastreamento != null ? ocorrencia.SistemaRastreamento.NomeSistemaRastreamento : "";
                    worksheet.Cell(currentRow, 22).Value = ocorrencia.SistemaFechaduraBluetooth != null ? ocorrencia.SistemaFechaduraBluetooth.NomeSistemaFechaduraBluetooth : "";
                    worksheet.Cell(currentRow, 23).Value = ocorrencia.Detentora != null ? ocorrencia.Detentora.NomeDetentora : "";
                    worksheet.Cell(currentRow, 24).Value = ocorrencia.Local != null ? ocorrencia.Local.NomeLocal : "";
                    worksheet.Cell(currentRow, 25).Value = ocorrencia.Ambiente;
                    worksheet.Cell(currentRow, 26).Value = ocorrencia.Transportadora != null ? ocorrencia.Transportadora.NomeTransportadora : "";
                    worksheet.Cell(currentRow, 27).Value = ocorrencia.EventoERB != null ? ocorrencia.EventoERB.NomeEventoERB : "";
                    worksheet.Cell(currentRow, 28).Value = ocorrencia.AlarmeRealAcidente != null ? ocorrencia.AlarmeRealAcidente.NomeAlarmeRealAcidente : "";
                    worksheet.Cell(currentRow, 29).Value = ocorrencia.TipoAlarme;
                    worksheet.Cell(currentRow, 30).Value = ocorrencia.Placa;
                    worksheet.Cell(currentRow, 31).Value = ocorrencia.Condutor;
                    worksheet.Cell(currentRow, 32).Value = ocorrencia.Historico;
                    worksheet.Cell(currentRow, 33).Value = ocorrencia.DataConclusao;
                    worksheet.Cell(currentRow, 34).Value = ocorrencia.DataReagendamentoSis;
                    worksheet.Cell(currentRow, 35).Value = ocorrencia.ObservacaoSis;

                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    _logger.LogWarning("{Acao}{UsuarioOperador}{IpOperador}{Hostname}", $"{userId} exportou o relatório de todas as ocorrências", userId, IpAndHostname[0], IpAndHostname[1]);
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"ocorrencias-{DateTime.Now:dd/MM/yyyy}.xlsx");
                }

            }
            
        }

        public async Task<IActionResult> GeneratePdfReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .Include(o => o.AcionadoProntoAtendimento)
                .Include(o => o.AlarmeRealAcidente)
                .Include(o => o.AreaInterna)
                .Include(o => o.AreaSaude)
                .Include(o => o.AtendimentoSLA)
                .Include(o => o.BombeiroCivil)
                .Include(o => o.Cmc)
                .Include(o => o.EmpresaProntoAtendimento)
                .Include(o => o.EventoERB)
                .Include(o => o.FornecimentoAcessoFisico)
                .Include(o => o.FornecimentoEventoAlarme)
                .Include(o => o.FornecimentoImagem)
                .Include(o => o.Local)
                .Include(o => o.Manutencao)
                .Include(o => o.PlanoDeEmergencia)
                .Include(o => o.Qualificacao)
                .Include(o => o.TipoAcesso)
                .Include(o => o.TipoOcorrencia)
                .Include(o => o.TipoSite)
                .Include(o => o.Site)
                .Include(o => o.Empresa)
                .Include(o => o.Status)
                .Include(o => o.Perda)
                .FirstOrDefaultAsync(c => c.Id == id);

            PdfService pdfService = new PdfService();
            byte[] ocorrenciaReportInBytes = pdfService.PrepareReport(ocorrencia);
            return File(ocorrenciaReportInBytes, "application/pdf", $"ocorrencia-{ocorrencia.Id}-{DateTime.Now}.pdf");
        }
    }
}
