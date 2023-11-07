using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NOVOROV.Context;
using NOVOROV.DatabaseHelper;
using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;
using NOVOROV.ViewModels;
using System.IO;
using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace NOVOROV.Controllers
{
    public class RelatoriosController : BaseController
    {

        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OcorrenciasController> _logger;


        public RelatoriosController(RovDbContext context, IConfiguration configuration,
            ILogger<OcorrenciasController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: RelatoriosController
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult PainelDeControle()
        {
            //List<OcorrenciasInFiltro> listaFiltrada = new List<OcorrenciasInFiltro>();

            //var filtroOcorrencia = _context.Ocorrencia.Include(f => f.UsuarioOperador);

            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "NomeStatus");
            ViewData["CmcId"] = new SelectList(_context.Cmc, "Id", "NomeCmc");
            ViewData["TipoOcorrenciaId"] = new SelectList(_context.TipoOcorrencia, "Id", "NomeTipoOcorrencia");
            ViewData["ResponsavelOperacionalId"] = new SelectList(_context.Usuario, "UsuarioId", "NomeUsuario");
            ViewData["TipoSiteId"] = new SelectList(_context.TipoSite, "Id", "NomeTipoSite");
            ViewData["SeguimentoId"] = new SelectList(_context.Seguimento, "Id", "NomeSeguimento");
            ViewData["InboxId"] = new SelectList(_context.Inbox, "Id", "NomeInbox");
            ViewData["TipoRelatorioId"] = new SelectList(_context.TipoRelatorio, "Id", "NomeTipoRelatorio");
            ViewData["ModeloRelatorioId"] = new SelectList(_context.ModeloRelatorio, "Id", "NomeModelo");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarModeloRelatorio(ModeloRelatorio modeloRelatorio)
        {
            try
            {
                _context.Add(modeloRelatorio);
                _context.SaveChangesAsync();
                return RedirectToAction("PainelDeControle", "RelatoriosController");
            }
            catch(Exception ex)
            {
                return RedirectToAction("PainelDeControle", "RelatoriosController");
            }

        }

        //GET
        public IActionResult Filtro(int idStatus, int idCmc, int idInbox, int idTipoOcorrencia, int idTipoSite,
            int idSeguimento, int numeroOcorrencia, string idResponsavelOperacional,
            string primeiraData, string segundaData)
        {
            //fazer verificações de null

            string query = $"SELECT O.Id, O.StatusId, DataOcorrencia, DataRegistro, NomeStatus, NomeCmc," +
                            $" NomeTipoOcorrencia, ResponsavelOperacionalId, NomeInbox, NomeTipoSite, NomeAreaTratamento, " +
                            $" UsuarioOperadorId, InformacaoOrigem, CargoFuncao, NomeSite, O.Estado, O.Municipio, O.CEP, O.Endereco, " +
                            $" NomeQualificacao, NomeInformacaoComplementar, NomeSistemaRastreamento, NomeSistemaFechaduraBluetooth, " +
                            $" NomeDetentora, NomeLocal, Ambiente, NomeTransportadora, NomeEventoERB, NomeAlarmeRealAcidente, " +
                            $" TipoAlarme, Placa, Condutor, Historico, NomeSeguimento, NomeManutencao, NomeAcionadoProntoAtendimento, " +
                            $" NomeAnaliseConclusao, NomeAreaInterna, NomeAreaSaude, NomeAtendimentoSLA, NomeBombeiroCivil, NomeEmpresa " +
                            $" FROM Ocorrencia O" +
                            $" FULL JOIN Status S ON O.StatusId = S.Id" +
                            $" FULL JOIN Cmc C ON O.CmcId = C.Id" +
                            $" FULL JOIN TipoOcorrencia T ON O.TipoOcorrenciaId = T.Id" +
                            $" FULL JOIN Inbox I ON O.InboxId = I.Id" +
                            $" FULL JOIN Usuario U ON O.ResponsavelOperacionalId = U.UsuarioId" +
                            $" FULL JOIN TipoSite TS ON O.TipoSiteId = TS.Id " +
                            $" FULL JOIN AreaTratamento AT ON O.AreaTratamentoId = AT.Id " +
                            $" FULL JOIN Site NS ON O.SiteId = NS.Id " +
                            $" FULL JOIN Qualificacao QU ON O.QualificacaoId = QU.Id " +
                            $" FULL JOIN InformacaoComplementar IC ON O.InformacaoComplementarId = IC.Id " +
                            $" FULL JOIN SistemaRastreamento SR ON O.SistemaRastreamentoId = SR.Id " +
                            $" FULL JOIN SistemaFechaduraBluetooth SFB ON O.SistemaFechaduraBluetoothId = SFB.Id " +
                            $" FULL JOIN Detentora DT ON O.DetentoraId = DT.Id " +
                            $" FULL JOIN Local LC ON O.LocalId = LC.Id " +
                            $" FULL JOIN Transportadora TRA ON O.TransportadoraId = TRA.Id " +
                            $" FULL JOIN EventoERB ERB ON O.EventoERBId = ERB.Id " +
                            $" FULL JOIN AlarmeRealAcidente ARA ON O.AlarmeRealAcidenteId = ARA.Id " +
                            $" FULL JOIN Seguimento SEG ON O.SeguimentoId = SEG.Id" +
                            $" FULL JOIN Manutencao MAN ON O.ManutencaoId = MAN.Id" +
                            $" FULL JOIN AcionadoProntoAtendimento APA ON O.AcionadoProntoAtendimentoId = APA.Id" +
                            $" FULL JOIN AnaliseConclusao ACO ON O.AnaliseConclusaoId = ACO.Id" +
                            $" FULL JOIN AreaInterna AI ON O.AreaInternaId = AI.Id" +
                            $" FULL JOIN AtendimentoSLA ASLA ON O.AtendimentoSLAId = ASLA.Id" +
                            $" FULL JOIN BombeiroCivil BC ON O.BombeiroCivilid = BC.Id" +
                            $" FULL JOIN AreaSaude ASD ON O.AreaSaudeId = ASD.Id" +
                            $" FULL JOIN Empresa E ON O.EmpresaId = E.Id";


            if (numeroOcorrencia != 0)
                query += " AND O.Id = " + numeroOcorrencia;

            if (idStatus != 0)
                query += " AND O.StatusId = " + idStatus;

            if (idCmc != 0)
                query += " AND O.CmcId = " + idCmc;

            if (idInbox != 0)
                query += " AND O.InboxId = " + idInbox;

            if (idTipoOcorrencia != 0)
                query += " AND O.TipoOcorrenciaId = " + idTipoOcorrencia;

            if (idResponsavelOperacional != "0")
                query += " AND O.ResponsavelOperacionalId = " + idResponsavelOperacional;

            if (idTipoSite != 0)
                query += " AND O.TipoSiteId = " + idTipoSite;

            //if (idSeguimento != 0)
            //    query += " WHERE O.SeguimentoId = " + idSeguimento;

            if (primeiraData != "0" && segundaData != "0")
            {
                query += $" AND CONVERT(DATE, DataRegistro, 103) BETWEEN CONVERT(DATE, '{primeiraData}', 103) AND CONVERT(DATE, '{segundaData}', 103); ";
            }


            List<Ocorrencia> ocorrencias = new List<Ocorrencia>();


            var database = new Database(_configuration);
            var command = database.GetCommand(query);

            try

            {
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ocorrencia item = new Ocorrencia();
                    var status = new Status();
                    var cmc = new Cmc();
                    var tipoOcorrencia = new TipoOcorrencia();
                    var inbox = new Inbox();
                    var responsavelOperacional = new Usuario();
                    var tipoSite = new TipoSite();
                    var seguimento = new Seguimento();
                    var areaTratamento = new AreaTratamento();
                    var usuarioOperador = new Usuario();
                    var site = new Site();
                    var qualificacao = new Qualificacao();
                    var informacaoComplementar = new InformacaoComplementar();
                    var sistemaRastreamento = new SistemaRastreamento();
                    var sistemaFechaduraBluetooth = new SistemaFechaduraBluetooth();
                    var detentora = new Detentora();
                    var local = new Local();
                    var transportadora = new Transportadora();
                    var eventoERB = new EventoERB();
                    var alarmeRealAcidente = new AlarmeRealAcidente();
                    var manutencao = new Manutencao();
                    var acionadoProntoAtendimento = new AcionadoProntoAtendimento();
                    var analiseConclusao = new AnaliseConclusao();
                    var atendimentoSLA = new AtendimentoSLA();
                    var bombeiroCivil = new BombeiroCivil();
                    var empresa = new Empresa();
                    var areaSaude = new AreaSaude();
                    var areaInterna = new AreaInterna();

                    item.Status = status;
                    item.Cmc = cmc;
                    item.TipoOcorrencia = tipoOcorrencia;
                    item.Inbox = inbox;
                    item.TipoSite = tipoSite;
                    item.Seguimento = seguimento;
                    item.AreaTratamento = areaTratamento;
                    item.Site = site;
                    item.Qualificacao = qualificacao;
                    item.InformacaoComplementar = informacaoComplementar;
                    item.SistemaRastreamento = sistemaRastreamento;
                    item.SistemaFechaduraBluetooth = sistemaFechaduraBluetooth;
                    item.Detentora = detentora;
                    item.Local = local;
                    item.Transportadora = transportadora;
                    item.EventoERB = eventoERB;
                    item.AlarmeRealAcidente = alarmeRealAcidente;
                    item.Manutencao = manutencao;
                    item.AcionadoProntoAtendimento = acionadoProntoAtendimento;
                    item.AnaliseConclusao = analiseConclusao;
                    item.AtendimentoSLA = atendimentoSLA;
                    item.BombeiroCivil = bombeiroCivil;
                    item.Empresa = empresa;
                    item.AreaSaude = areaSaude;
                    item.AreaInterna = areaInterna;

                    item.Id = Convert.ToInt32(reader["Id"].ToString());
                    item.DataOcorrencia = Convert.ToDateTime(reader["DataOcorrencia"].ToString());
                    item.DataRegistro = Convert.ToDateTime(reader["DataRegistro"].ToString());
                    item.Status.NomeStatus = reader["NomeStatus"].ToString();
                    item.Cmc.NomeCmc = reader["NomeCmc"].ToString();
                    item.TipoOcorrencia.NomeTipoOcorrencia = reader["NomeTipoOcorrencia"].ToString();
                    item.Inbox.NomeInbox = reader["NomeInbox"].ToString();
                    item.TipoSite.NomeTipoSite = reader["NomeTipoSite"].ToString();
                    item.AreaTratamento.NomeAreaTratamento = reader["NomeAreaTratamento"].ToString();
                    item.UsuarioOperadorId = reader["UsuarioOperadorId"].ToString();
                    item.InformacaoOrigem = reader["InformacaoOrigem"].ToString();
                    item.CargoFuncao = reader["CargoFuncao"].ToString();
                    item.Site.NomeSite = reader["NomeSite"].ToString();
                    item.Estado = reader["Estado"].ToString();
                    item.Municipio = reader["Municipio"].ToString();
                    item.CEP = reader["CEP"].ToString();
                    item.Endereco = reader["Endereco"].ToString();
                    item.Qualificacao.NomeQualificacao = reader["NomeQualificacao"].ToString();
                    item.InformacaoComplementar.NomeInformacaoComplementar = reader["NomeInformacaoComplementar"].ToString();
                    item.SistemaRastreamento.NomeSistemaRastreamento = reader["NomeSistemaRastreamento"].ToString();
                    item.SistemaFechaduraBluetooth.NomeSistemaFechaduraBluetooth = reader["NomeSistemaFechaduraBluetooth"].ToString();
                    item.Detentora.NomeDetentora = reader["NomeDetentora"].ToString();
                    item.Local.NomeLocal = reader["NomeLocal"].ToString();
                    item.Ambiente = reader["Ambiente"].ToString();
                    item.Transportadora.NomeTransportadora = reader["NomeTransportadora"].ToString();
                    item.EventoERB.NomeEventoERB = reader["NomeEventoERB"].ToString();
                    item.AlarmeRealAcidente.NomeAlarmeRealAcidente = reader["NomeAlarmeRealAcidente"].ToString();
                    item.TipoAlarme = reader["TipoAlarme"].ToString();
                    item.Placa = reader["Placa"].ToString();
                    item.Condutor = reader["Condutor"].ToString();
                    item.Historico = reader["Historico"].ToString();
                    item.Seguimento.NomeSeguimento = reader["NomeSeguimento"].ToString();
                    item.Manutencao.NomeManutencao = reader["NomeManutencao"].ToString();
                    item.AcionadoProntoAtendimento.NomeAcionadoProntoAtendimento = reader["NomeAcionadoProntoAtendimento"].ToString();
                    item.AnaliseConclusao.NomeAnaliseConclusao = reader["NomeAnaliseConclusao"].ToString();
                    item.AtendimentoSLA.NomeAtendimentoSLA = reader["NomeAtendimentoSLA"].ToString();
                    item.BombeiroCivil.NomeBombeiroCivil = reader["NomeBombeiroCivil"].ToString();
                    item.AreaSaude.NomeAreaSaude = reader["NomeAreaSaude"].ToString();
                    item.AreaInterna.NomeAreaInterna = reader["NomeAreaInterna"].ToString();
                    item.Empresa.NomeEmpresa = reader["NomeEmpresa"].ToString();
                    //item.DataConclusao = reader["DataConclusao"];
                    //item.DataReagendamentoSis = reader["DataReagendamentoSis"].ToString();


                    ocorrencias.Add(item);
                }

                reader.Close();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                command.Connection.Close();
            }

            return PartialView("_Filtro", ocorrencias);

        }

        [HttpPost]
        public ModeloRelatorio selecionarModeloRelatorio(int idModeloRelatorio)
        {
            var modeloRelatorio = _context.ModeloRelatorio.Where(m => m.Id == idModeloRelatorio).FirstOrDefault();
            return modeloRelatorio;
        }



        public ActionResult ExportFile(int idOcorrencia, int idStatus, int idCmc, int idInbox, 
            int idTipoOcorrencia, int idEstado, string idResponsavelOperacional,
            int idTipoSite, int idSeguimento, string primeiraData, string segundaData,
            string checkId, string checkDataOcorrencia, string checkDataRegistro, string checkStatus,
            string checkCmc, string checkInbox, string checkUsuarioOperador, string checkAreaTratamento,
            string checkUsuarioAlteracaoOcorrencia, string checkInformacaoOrigem, string checkCargoFuncao,
            string checkTipoSite, string checkNomeSite, string checkEstado, string checkMunicipio, 
            string checkCep, string checkEndereco, string checkTipoOcorrencia, string checkQualificacao,
            string checkInformacaoComplementar, string checkSistemaRastreamento, string checkSistemaFechaduraBluetooth,
            string checkDetentora, string checkLocal, string checkAmbiente, string checkTransportadora,
            string checkEventoERB, string checkAlarmeRealAcidental, string checkTipoAlarme, string checkPlaca,
            string checkCondutor, string checkHistorico, string checkDataConclusao, string checkDataReagendamento,
            string checkObservacao, string checkAcionadoProntoAtendimento, string modeloRelatorioAtivo, string checkAnaliseConclusao,
            string checkAreaInterna, string checkAreaSaude, string checkAtendeuSLA, string checkBombeiroCivil, string checkCodigoSinistro,
            string checkConclusao, string checkDataConclusaoChamado, string checkDataReagendamentoSis, string checkDiasConclusao,
            string checkEmSeguimento, string checkEmpresa, string checkManutencao, string checkResponsavelOperacional,
            string checkSeguimento, string checkEnvolvido, string checkPerda, string checkRecuperacao, string checkRegistroPolicial,
            string checkOrgaoPublico, string checkQuantidadePerda, string checkValorPerdaEvitada ,  string checkPlanoDeEmergencia,
            string checkAnexo, string nomeModelo, int idTipoModelo)
        {

            if (modeloRelatorioAtivo != null)
            {
                var modeloRelatorio = new ModeloRelatorio();
                modeloRelatorio.NomeModelo = nomeModelo;
                modeloRelatorio.TipoRelatorioId = idTipoModelo;


                modeloRelatorio.NumeroRov = checkId == null ? false : true;
                modeloRelatorio.AcionadoProntoAtendimento = checkAcionadoProntoAtendimento == null ? false : true;
                modeloRelatorio.AlarmeRealAcidental = checkAlarmeRealAcidental == null ? false : true;
                modeloRelatorio.Ambiente = checkAmbiente == null ? false : true;
                modeloRelatorio.AnaliseConclusao = checkAnaliseConclusao == null ? false : true;
                modeloRelatorio.AreaInterna = checkAreaInterna == null ? false : true;
                modeloRelatorio.AreaSaude = checkAreaSaude == null ? false : true;
                modeloRelatorio.AreaTratamento = checkAreaTratamento == null ? false : true;
                modeloRelatorio.AtendeuSla = checkAtendeuSLA == null ? false : true;
                modeloRelatorio.BombeiroCivil = checkBombeiroCivil == null ? false : true;
                modeloRelatorio.CargoFuncao = checkCargoFuncao == null ? false : true;
                modeloRelatorio.CEP = checkCep == null ? false : true;
                modeloRelatorio.Cmc = checkCmc == null ? false : true;
                modeloRelatorio.CodigoSinistro = checkCodigoSinistro == null ? false : true;
                modeloRelatorio.Conclusao = checkConclusao == null ? false : true;
                modeloRelatorio.Condutor = checkCondutor == null ? false : true;
                modeloRelatorio.DataConclusao = checkDataConclusao == null ? false : true;
                modeloRelatorio.DataConclusaoChamado = checkDataConclusaoChamado == null ? false : true;
                modeloRelatorio.DataOcorrencia = checkDataOcorrencia == null ? false : true;
                modeloRelatorio.DataConclusao = checkDataOcorrencia == null ? false : true;
                modeloRelatorio.DataReagendamentoSis = checkDataReagendamentoSis == null ? false : true;
                modeloRelatorio.DataRegistro = checkDataRegistro == null ? false : true;
                modeloRelatorio.Detentora = checkDetentora == null ? false : true;
                modeloRelatorio.DiasConclusao = checkDiasConclusao == null ? false : true;
                modeloRelatorio.EmSeguimento = checkEmSeguimento == null ? false : true;
                modeloRelatorio.Empresa = checkEmpresa == null ? false : true;
                modeloRelatorio.Endereco = checkEndereco == null ? false : true;
                modeloRelatorio.EventoErb = checkEventoERB == null ? false : true;
                modeloRelatorio.Historico = checkEmSeguimento == null ? false : true;
                modeloRelatorio.Inbox = checkInbox == null ? false : true;
                modeloRelatorio.InformacaoComplementar = checkInformacaoComplementar == null ? false : true;
                modeloRelatorio.Local = checkLocal == null ? false : true;
                modeloRelatorio.Manutencao = checkManutencao == null ? false : true;
                modeloRelatorio.Municipio = checkMunicipio == null ? false : true;
                modeloRelatorio.NomeSite = checkNomeSite == null ? false : true;
                modeloRelatorio.Placa = checkPlaca == null ? false : true;
                modeloRelatorio.Qualificacao = checkQualificacao == null ? false : true;
                modeloRelatorio.ResponsavelOperacional = checkResponsavelOperacional == null ? false : true;
                modeloRelatorio.Seguimento = checkSeguimento == null ? false : true;
                modeloRelatorio.SistemaFechaduraBluetooth = checkSistemaFechaduraBluetooth == null ? false : true;
                modeloRelatorio.SistemaRastreamento = checkSistemaRastreamento == null ? false : true;
                modeloRelatorio.Status = checkStatus == null ? false : true;
                modeloRelatorio.TipoSite = checkTipoSite == null ? false : true;
                modeloRelatorio.TipoOcorrencia = checkTipoOcorrencia == null ? false : true;
                modeloRelatorio.Transportadora = checkTransportadora == null ? false : true;
                modeloRelatorio.Observacao = checkObservacao == null ? false : true;
                modeloRelatorio.UF = checkEstado == null ? false : true;
                modeloRelatorio.UsuarioAlteracaoOcorrencia = checkUsuarioAlteracaoOcorrencia == null ? false : true;

                _context.ModeloRelatorio.Add(modeloRelatorio);
                _context.SaveChanges();

                return RedirectToAction("PainelDeControle", "Relatorios");
            }

            var userId = User.Identity.Name.Split("\\")[1];

            string query = @"
                        SELECT O.Id, DataOcorrencia, DataRegistro, S.NomeStatus, NomeCmc, NomeTipoOcorrencia, 
                        ResponsavelOperacionalId, NomeInbox, NomeTipoSite, NomeAreaTratamento,  UsuarioOperadorId, InformacaoOrigem,
                        CargoFuncao, NomeSite, O.Estado, O.Municipio, O.CEP, O.Endereco,  NomeQualificacao, NomeInformacaoComplementar,
                        NomeSistemaRastreamento, NomeSistemaFechaduraBluetooth,  NomeDetentora, NomeLocal, Ambiente, NomeTransportadora,
                        NomeEventoERB, NomeAlarmeRealAcidente,  TipoAlarme, Placa, Condutor, Historico, NomeAreaInterna, NomeAreaSaude,
                        NomeAtendimentoSLA, DiasConclusao,  NomeAcionadoProntoAtendimento, NomeBombeiroCivil, CargoFuncao, 
                        NomeSeguimento, ObservacaoSis, UsuarioAlteracaoOcorrenciaId, ENV.NomeEnvolvido,  DataAcionamentoProntoAtendimento, 
                        DataReagendamentoSis, DataRecuperacao, DataValorRecuperadoPassivo, NomeEmpresaProntoAtendimento, NomeEnvolvido, 
                        LV.DataAlteracaoValor, FEA.NomeFornecimentoEventoAlarme, FAF.NomeFornecimentoAcessoFisico, RP.NomeRegistroPolicial
                        FI.NomeFornecimentoImagem, MotivoSis, NumeroAntigo, PD.ValorPerda, RE.ValorRecuperadoPassivo, RE.Passivo
                        NomeEquipamentoPerda, UsuarioOperadorId,  NumeroBOSinistroRede, NomeOrgaoPublico, ProvidenciaConclusao, 
                        TR.NomeTipoRessarcimento, ValorPerda, ValorPerdaEvitada, EM.NomeEmpresa, CodigoSinistro, QuantidadePerda 
                         FROM Ocorrencia O
                         FULL JOIN Status S ON O.StatusId = S.Id
                         FULL JOIN Cmc C ON O.CmcId = C.Id 
                         FULL JOIN TipoOcorrencia T ON O.TipoOcorrenciaId = T.Id 
                         FULL JOIN Inbox I ON O.InboxId = I.Id 
                         FULL JOIN Usuario U ON O.ResponsavelOperacionalId = U.UsuarioId 
                         FULL JOIN TipoSite TS ON O.TipoSiteId = TS.Id  
                         FULL JOIN AreaTratamento AT ON O.AreaTratamentoId = AT.Id  
                         FULL JOIN Site NS ON O.SiteId = NS.Id  
                         FULL JOIN Qualificacao QU ON O.QualificacaoId = QU.Id  
                         FULL JOIN InformacaoComplementar IC ON O.InformacaoComplementarId = IC.Id  
                         FULL JOIN SistemaRastreamento SR ON O.SistemaRastreamentoId = SR.Id  
                         FULL JOIN SistemaFechaduraBluetooth SFB ON O.SistemaFechaduraBluetoothId = SFB.Id  
                         FULL JOIN Detentora DT ON O.DetentoraId = DT.Id  
                         FULL JOIN Local LC ON O.LocalId = LC.Id  
                         FULL JOIN Transportadora TRA ON O.TransportadoraId = TRA.Id 
                         FULL JOIN EventoERB ERB ON O.EventoERBId = ERB.Id  
                         FULL JOIN AlarmeRealAcidente ARA ON O.AlarmeRealAcidenteId = ARA.Id  
                         FULL JOIN AcionadoProntoAtendimento APA ON O.AcionadoProntoAtendimentoId = APA.Id  
                         FULL JOIN AreaInterna AI ON O.AreaInternaId = AI.Id  
                         FULL JOIN AreaSaude ASD ON O.AreaSaudeId = ASD.Id  
                         FULL JOIN AtendimentoSLA ASLA ON O.AtendimentoSLAId = ASLA.Id  
                         FULL JOIN BombeiroCivil BCL ON O.BombeiroCivilId = BCL.Id  
                         FULL JOIN Empresa E ON O.EmpresaId = E.Id  
                         FULL JOIN Seguimento SEG ON O.SeguimentoId = SEG.Id  
                         FULL JOIN Envolvido ENV ON O.Id = ENV.OcorrenciaId  
                         FULL JOIN EmpresaProntoAtendimento EPA ON EmpresaProntoAtendimentoId = EPA.Id  
                         FULL JOIN FornecimentoAcessoFisico FAF ON FornecimentoAcessoFisicoId = FAF.Id  
                         FULL JOIN FornecimentoEventoAlarme FEA ON FornecimentoEventoAlarmeId = FEA.Id  
                         FULL JOIN FornecimentoImagem FI ON FornecimentoImagemId = FI.Id  
                         FULL JOIN RegistroPolicial RP ON RegistroPolicialId = RP.Id  
                         FULL JOIN OrgaoPublico OP ON OrgaoPublicoId = OP.Id
                         FULL JOIN Recuperacao RE ON RE.OcorrenciaId = O.Id  
                         FULL JOIN TipoRessarcimento TR ON RE.TipoRessarcimentoId = TR.Id
                         FULL JOIN Perda PD ON PD.OcorrenciaId = O.Id
                         FULL JOIN LogValor LV ON LV.OcorrenciaId = O.Id
                         FULL JOIN Empresa EM ON O.EmpresaId = EM.Id";

            int contagemDeFiltros = 0;

            if (idOcorrencia != 0 && contagemDeFiltros == 0)
            {
                query += " WHERE O.Id = " + idOcorrencia; 
                contagemDeFiltros += 1;
            }

            if (idStatus != 0 && contagemDeFiltros == 0)
            {
                query += " WHERE O.StatusId = " + idStatus; 
                contagemDeFiltros += 1;
            }

            if (idCmc != 0 && contagemDeFiltros == 0)
            {
                query += " WHERE O.CmcId = " + idCmc; 
                contagemDeFiltros += 1;
            }

            if (idInbox != 0 && contagemDeFiltros == 0)
            {
                query += " WHERE O.InboxId = " + idInbox; 
                contagemDeFiltros += 1;
            }

            if (idTipoOcorrencia != 0 && contagemDeFiltros == 0)
            {
                query += " WHERE O.TipoOcorrenciaId = " + idTipoOcorrencia; 
                contagemDeFiltros += 1;
            }

            if (idResponsavelOperacional != "0" && contagemDeFiltros == 0)
            {
                query += " WHERE O.ResponsavelOperacionalId = " + idResponsavelOperacional; 
                contagemDeFiltros += 1;
            }

            if (idTipoSite != 0 && contagemDeFiltros == 0)
            {
                query += " WHERE O.TipoSiteId = " + idTipoSite; 
                contagemDeFiltros += 1;
            }


            if (primeiraData != null && segundaData != null && contagemDeFiltros == 0)
            {
                query += $" WHERE CONVERT(DATE, DataRegistro, 103) BETWEEN CONVERT(DATE, '{primeiraData.Replace('-', '.')}', 102) AND CONVERT(DATE, '{segundaData.Replace('-', '.')}', 102); "; contagemDeFiltros += 1;
            }
                

            if (idOcorrencia != 0 && contagemDeFiltros > 0)
                query += " AND O.Id = " + idOcorrencia;

            if (idStatus != 0 && contagemDeFiltros > 0)
                query += " AND O.StatusId = " + idStatus;

            if (idCmc != 0 && contagemDeFiltros > 0)
                query += " AND O.CmcId = " + idCmc;

            if (idInbox != 0 && contagemDeFiltros > 0)
                query += " AND O.InboxId = " + idInbox;

            if (idTipoOcorrencia != 0 && contagemDeFiltros > 0)
                query += " AND O.TipoOcorrenciaId = " + idTipoOcorrencia;

            if (idResponsavelOperacional != "0" && contagemDeFiltros > 0)
                query += " AND O.ResponsavelOperacionalId = " + idResponsavelOperacional;

            if (idTipoSite != 0 && contagemDeFiltros > 0)
                query += " AND O.TipoSiteId = " + idTipoSite;

            //if (idRecuperação != 0 && contagemDeFiltros > 0)
            //    query += " AND O.RecuperacaoId = " + idRecuperacao;

            //if (idSeguimento != 0)
            //    query += " WHERE O.SeguimentoId = " + idSeguimento;

            if (primeiraData != null && segundaData != null && contagemDeFiltros > 0)
                query += $" AND CONVERT(DATE, DataRegistro, 103) BETWEEN CONVERT(DATE, '{primeiraData.Replace('-', '.')}', 102) AND CONVERT(DATE, '{segundaData.Replace('-', '.')}', 102); ";

            List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

            var database = new Database(_configuration);
            var command = database.GetCommand(query);

            try

            {
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ocorrencia item = new Ocorrencia();
                    var status = new Status();
                    var cmc = new Cmc();
                    var tipoOcorrencia = new TipoOcorrencia();
                    var inbox = new Inbox();
                    var responsavelOperacional = new Usuario();
                    var tipoSite = new TipoSite();
                    var seguimento = new Seguimento();
                    var areaTratamento = new AreaTratamento();
                    var usuarioOperador = new Usuario();
                    var site = new Site();
                    var qualificacao = new Qualificacao();
                    var informacaoComplementar = new InformacaoComplementar();
                    var sistemaRastreamento = new SistemaRastreamento();
                    var sistemaFechaduraBluetooth = new SistemaFechaduraBluetooth();
                    var detentora = new Detentora();
                    var local = new Local();
                    var transportadora = new Transportadora();
                    var eventoERB = new EventoERB();
                    var alarmeRealAcidente = new AlarmeRealAcidente();
                    var acionadoProntoAtendimento = new AcionadoProntoAtendimento();
                    var analiseConclusao = new AnaliseConclusao();
                    var areaInterna = new AreaInterna();
                    var areaSaude = new AreaSaude();
                    var atendimentoSLA = new AtendimentoSLA();
                    var bombeiroCivil = new BombeiroCivil();
                    var empresa = new Empresa();
                    var fornecimentoAcessoFisico = new FornecimentoAcessoFisico();
                    var fornecimentoEventoAlarme = new FornecimentoEventoAlarme();
                    var fornecimentoImagem = new FornecimentoImagem();
                    var registroPolicial = new RegistroPolicial();
                    var orgaoPublico = new OrgaoPublico();
                    var tipoAcesso = new TipoAcesso();
                    var tipoRessarcimento = new TipoRessarcimento();
                    var planoDeEmergencia = new PlanoDeEmergencia();
                    var recuperacao = new Recuperacao();

                    item.Status = status;
                    item.Cmc = cmc;
                    item.TipoOcorrencia = tipoOcorrencia;
                    item.Inbox = inbox;
                    item.TipoSite = tipoSite;
                    item.Seguimento = seguimento;
                    item.AreaTratamento = areaTratamento;
                    item.Site = site;
                    item.Qualificacao = qualificacao;
                    item.InformacaoComplementar = informacaoComplementar;
                    item.SistemaRastreamento = sistemaRastreamento;
                    item.SistemaFechaduraBluetooth = sistemaFechaduraBluetooth;
                    item.Detentora = detentora;
                    item.Local = local;
                    item.Transportadora = transportadora;
                    item.EventoERB = eventoERB;
                    item.AlarmeRealAcidente = alarmeRealAcidente;
                    item.AcionadoProntoAtendimento = acionadoProntoAtendimento;
                    item.AnaliseConclusao = analiseConclusao;
                    item.AreaInterna = areaInterna;
                    item.AreaSaude = areaSaude;
                    item.AtendimentoSLA = atendimentoSLA;
                    item.BombeiroCivil = bombeiroCivil;
                    item.Empresa = empresa;
                    item.FornecimentoAcessoFisico = fornecimentoAcessoFisico;
                    item.FornecimentoEventoAlarme = fornecimentoEventoAlarme;
                    item.FornecimentoImagem = fornecimentoImagem;
                    item.RegistroPolicial = registroPolicial;
                    item.OrgaoPublico = orgaoPublico;
                    item.TipoAcesso = tipoAcesso;
                    item.PlanoDeEmergencia = planoDeEmergencia;

                    item.Id = Convert.ToInt32(reader["Id"].ToString());
                    item.DataOcorrencia = Convert.ToDateTime(reader["DataOcorrencia"].ToString());
                    item.DataRegistro = Convert.ToDateTime(reader["DataRegistro"].ToString());
                    item.Status.NomeStatus = reader["NomeStatus"].ToString();
                    item.Cmc.NomeCmc = reader["NomeCmc"].ToString();
                    item.TipoOcorrencia.NomeTipoOcorrencia = reader["NomeTipoOcorrencia"].ToString();
                    item.Inbox.NomeInbox = reader["NomeInbox"].ToString();
                    item.TipoSite.NomeTipoSite = reader["NomeTipoSite"].ToString();
                    item.AreaTratamento.NomeAreaTratamento = reader["NomeAreaTratamento"].ToString();
                    item.UsuarioOperadorId = reader["UsuarioOperadorId"].ToString();
                    item.InformacaoOrigem = reader["InformacaoOrigem"].ToString();
                    item.CargoFuncao = reader["CargoFuncao"].ToString();
                    item.Site.NomeSite = reader["NomeSite"].ToString();
                    item.Estado = reader["Estado"].ToString();
                    item.Municipio = reader["Municipio"].ToString();
                    item.CEP = reader["CEP"].ToString();
                    item.Endereco = reader["Endereco"].ToString();
                    item.Qualificacao.NomeQualificacao = reader["NomeQualificacao"].ToString();
                    item.InformacaoComplementar.NomeInformacaoComplementar = reader["NomeInformacaoComplementar"].ToString();
                    item.SistemaRastreamento.NomeSistemaRastreamento = reader["NomeSistemaRastreamento"].ToString();
                    item.SistemaFechaduraBluetooth.NomeSistemaFechaduraBluetooth = reader["NomeSistemaFechaduraBluetooth"].ToString();
                    item.Detentora.NomeDetentora = reader["NomeDetentora"].ToString();
                    item.Local.NomeLocal = reader["NomeLocal"].ToString();
                    item.Ambiente = reader["Ambiente"].ToString();
                    item.Transportadora.NomeTransportadora = reader["NomeTransportadora"].ToString();
                    item.EventoERB.NomeEventoERB = reader["NomeEventoERB"].ToString();
                    item.AlarmeRealAcidente.NomeAlarmeRealAcidente = reader["NomeAlarmeRealAcidente"].ToString();
                    item.TipoAlarme = reader["TipoAlarme"].ToString();
                    item.Placa = reader["Placa"].ToString();
                    item.Condutor = reader["Condutor"].ToString();
                    item.Historico = reader["Historico"].ToString();
                    item.AcionadoProntoAtendimento.NomeAcionadoProntoAtendimento = reader["NomeAcionadoProntoAtendimento"].ToString();
                    item.AreaInterna.NomeAreaInterna = reader["NomeAreaInterna"].ToString();
                    item.AreaSaude.NomeAreaSaude = reader["NomeAreaSaude"].ToString();
                    item.AtendimentoSLA.NomeAtendimentoSLA = reader["NomeAtendimentoSLA"].ToString();
                    item.BombeiroCivil.NomeBombeiroCivil = reader["NomeBombeiroCivil"].ToString();
                    item.CargoFuncao = reader["CargoFuncao"].ToString();
                    item.Empresa.NomeEmpresa = reader["NomeEmpresa"].ToString();
                    item.ResponsavelOperacionalId = reader["ResponsavelOperacionalId"].ToString();
                    item.Seguimento.NomeSeguimento = reader["NomeSeguimento"].ToString();
                    item.UsuarioAlteracaoOcorrenciaId = reader["UsuarioAlteracaoOcorrenciaId"].ToString();
                    item.ObservacaoSis = reader["ObservacaoSis"].ToString();
                    item.FornecimentoAcessoFisico.NomeFornecimentoAcessoFisico = reader["NomeFornecimentoAcessoFisico"].ToString();
                    item.FornecimentoEventoAlarme.NomeFornecimentoEventoAlarme = reader["NomeFornecimentoEventoAlarme"].ToString();
                    item.FornecimentoImagem.NomeFornecimentoImagem = reader["NomeFornecimentoImagem"].ToString();
                    item.MotivoSis = reader["MotivoSis"].ToString();
                    item.RegistroPolicial.NomeRegistroPolicial = reader["NomeRegistroPolicial"].ToString();
                    item.OrgaoPublico.NomeOrgaoPublico = reader["NomeOrgaoPublico"].ToString();
                    item.TipoAcesso.NomeTipoAcesso = reader["NomeTipoAcesso"].ToString();
                    item.PlanoDeEmergencia.NomePlanoDeEmergencia = reader["NomePlanoDeEmergencia"].ToString();

                    if (checkEnvolvido != null)
                    {
                        item.Envolvido = new List<Envolvido>()
                        {
                            new Envolvido() { Id = Convert.ToInt32(reader["envolvidoId"]?.ToString()),
                            NomeEnvolvido = reader["NomeEnvolvido"]?.ToString(),},
                        };
                    }

                    if(checkPerda != null)
                    {
                        item.Perda = new List<Perda>()
                        {
                            new Perda() { Id = Convert.ToInt32(reader["Id"]?.ToString()),
                                            ValorPerda = Convert.ToInt32(reader["ValorPerda"]?.ToString()),
                                            CodigoSinistro = reader["CodigoSinistro"]?.ToString(),
                                            QuantidadePerda = Convert.ToInt32(reader["QuantidadePerda"]?.ToString()),
                                            ValorPerdaEvitada = Convert.ToInt32(reader["ValorPerdaEvitada"]?.ToString()),
                            },
                        };
                    }

                    if (checkAnexo != null)
                    {
                        item.Anexo = new List<Anexo>()
                        {
                            new Anexo() { Id = Convert.ToInt32(reader["Id"]?.ToString()),

                            },
                        };
                    }

                    ocorrencias.Add(item);

                }

                reader.Close();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                command.Connection.Close();
                Notify(title: "Oops!", message: "Erro ao gerar relatório!", notificationType: Notification.warning);
                return RedirectToAction("PainelDeControle");
            }

            //teste
            //try
            //{
            //    command.Connection.Close();
            //    Notify(title: "Oops!", message: "Erro ao gerar relatório!", notificationType: Notification.warning);
            //}
            //catch(Exception ex)
            //{
            //    return RedirectToAction("PainelDeControle");
            //}

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Ocorrencias");

                var currentRow = 1;
                var currentColumn = 1;

                if (checkId != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Id";
                    currentColumn += 1;
                }

                if (checkDataOcorrencia != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Data Ocorrencia";
                    currentColumn += 1;
                }

                if (checkDataRegistro != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Data Registro";
                    currentColumn += 1;
                }

                if (checkStatus != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Status";
                    currentColumn += 1;
                }

                if (checkCmc != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Cmc";
                    currentColumn += 1;
                }

                if (checkAcionadoProntoAtendimento != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Acionado Pronto Atendimento";
                    currentColumn += 1;
                }

                if (checkAnaliseConclusao != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Análise Conclusão";
                    currentColumn += 1;
                }

                if (checkAreaInterna != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Área Interna";
                    currentColumn += 1;
                }

                if (checkAreaSaude != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Área Saúde";
                    currentColumn += 1;
                }

                if (checkInbox != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Inbox";
                    currentColumn += 1;
                }

                if (checkUsuarioOperador != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Usuário Operador";
                    currentColumn += 1;
                }

                if (checkAreaTratamento != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Area Tratamento";
                    currentColumn += 1;
                }

                if(checkUsuarioAlteracaoOcorrencia != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Última Alteração";
                    currentColumn += 1;
                }

                if(checkInformacaoOrigem != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Informação da Origem";
                    currentColumn += 1;
                } 

                if(checkCargoFuncao != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Cargo função";
                    currentColumn += 1;
                }


                if (checkEnvolvido != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Nº Envolvido";
                    currentColumn += 1;
                }

                if (checkTipoSite != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Tipo Site";
                    currentColumn += 1;
                }
                
                if(checkNomeSite != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Nome Site";
                    currentColumn += 1;
                }
                
                if(checkEstado != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Estado";
                    currentColumn += 1;
                }

                if(checkMunicipio != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Município";
                    currentColumn += 1;
                }

                if(checkCep != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "CEP";
                    currentColumn += 1;
                }
                
                if(checkEndereco != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Endereço";
                    currentColumn += 1;
                }

                if(checkTipoOcorrencia != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Tipo Ocorrência";
                    currentColumn += 1;
                }

                if(checkQualificacao != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Qualificação";
                    currentColumn += 1;
                }

                if(checkInformacaoComplementar != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Informação Complementar";
                    currentColumn += 1;
                }

                if(checkSistemaRastreamento != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Sistema Rastreamento";
                    currentColumn += 1;
                }

                if(checkSistemaFechaduraBluetooth != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Sistema fechadura Bluetooth";
                    currentColumn += 1;
                }
                
                if(checkDetentora != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Detentora";
                    currentColumn += 1;
                }

                if(checkLocal != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Local";
                    currentColumn += 1;
                }

                if(checkAmbiente != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Ambiente";
                    currentColumn += 1;
                }

                if(checkTransportadora != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Transportadora";
                    currentColumn += 1;
                }

                if(checkEventoERB != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Evento EBR";
                    currentColumn += 1;
                }

                if(checkAlarmeRealAcidental != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Alarme Real Acidental";
                    currentColumn += 1;
                }

                if(checkTipoAlarme != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Tipo de Alarme";
                    currentColumn += 1;
                }

                if(checkPlaca != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Placa";
                    currentColumn += 1;
                }

                if(checkCondutor != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Condutor";
                    currentColumn += 1;
                }

                if(checkHistorico != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Histórico";
                    currentColumn += 1;
                }

                if(checkDataConclusao != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Data Conclusão";
                    currentColumn += 1;
                }

                if(checkDataReagendamento != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Data Reagendamento";
                    currentColumn += 1;
                }

                if(checkObservacao != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Observação";
                    currentColumn += 1;
                }

                if (checkAtendeuSLA != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Atendimento SLA";
                    currentColumn += 1;
                }


                if (checkBombeiroCivil != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Bombeiro Civil";
                    currentColumn += 1;
                }

                if (checkEmpresa != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Empresa";
                    currentColumn += 1;
                }

                if (checkDiasConclusao != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Dias Conclusão";
                    currentColumn += 1;
                }

                if (checkResponsavelOperacional != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Responsável Operacional";
                    currentColumn += 1;
                }

                if (checkSeguimento != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Seguimento";
                    currentColumn += 1;
                }


                if (checkRegistroPolicial != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Registro Policial";
                    currentColumn += 1;
                }

                if (checkOrgaoPublico != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Órgão Público";
                    currentColumn += 1;
                }

                if (checkPlanoDeEmergencia != null)
                {
                    worksheet.Cell(currentRow, currentColumn).Value = "Plano De Emergência";
                    currentColumn += 1;
                }

                //if (checkQuantidadePerda != null)
                //{
                //    worksheet.Cell(currentRow, currentColumn).Value = "Quantidade Perda";
                //    currentColumn += 1;
                //}

                //if (checkValorPerdaEvitada != null)
                //{
                //    worksheet.Cell(currentRow, currentColumn).Value = "Valor Perda Evitada";
                //    currentColumn += 1;
                //}



                foreach (var ocorrencia in ocorrencias)
                {

                    currentRow++;
                    currentColumn = 1;

                    if (checkId != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Id;
                        currentColumn += 1;
                    }

                    if (checkDataOcorrencia != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.DataOcorrencia;
                        currentColumn += 1;
                    }

                    if (checkDataRegistro != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.DataRegistro;
                        currentColumn += 1;
                    }

                    if (checkStatus != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Status != null ? ocorrencia.Status.NomeStatus : "";
                        currentColumn += 1;
                    }

                    if (checkCmc != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Cmc != null ? ocorrencia.Cmc.NomeCmc : "";
                        currentColumn += 1;
                    }

                    if (checkAcionadoProntoAtendimento != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.AcionadoProntoAtendimento != null ? ocorrencia.AcionadoProntoAtendimento.NomeAcionadoProntoAtendimento : "";
                        currentColumn += 1;
                    }

                    if (checkAnaliseConclusao != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.AnaliseConclusao != null ? ocorrencia.AnaliseConclusao.NomeAnaliseConclusao : "";
                        currentColumn += 1;
                    }

                    if (checkAreaInterna != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.AreaInterna != null ? ocorrencia.AreaInterna.NomeAreaInterna : "";
                        currentColumn += 1;
                    }

                    if (checkAreaSaude != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.AreaSaude != null ? ocorrencia.AreaSaude.NomeAreaSaude : "";
                        currentColumn += 1;
                    }

                    if (checkInbox != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Inbox != null ? ocorrencia.Inbox.NomeInbox : "";
                        currentColumn += 1;
                    }

                    if(checkUsuarioOperador != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.UsuarioOperadorId;
                        currentColumn += 1;
                    }

                    if(checkAreaTratamento != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.AreaTratamento != null ? ocorrencia.AreaTratamento.NomeAreaTratamento : "";
                        currentColumn += 1;
                    }
                    
                    if(checkUsuarioAlteracaoOcorrencia != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.UsuarioAlteracaoOcorrenciaId;
                        currentColumn += 1;
                    }

                    if (checkInformacaoOrigem != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.InformacaoOrigem;
                        currentColumn += 1;
                    }

                    if(checkCargoFuncao != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.CargoFuncao;
                        currentColumn += 1;
                    }

                    if (checkEnvolvido != null)
                    {
                        foreach (var envolvido in ocorrencia.Envolvido)
                        {
                            worksheet.Cell(currentRow, currentColumn).Value = envolvido.Id;
                            currentColumn += 1;
                        }

                    }


                    if (checkTipoSite != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.TipoSite != null ? ocorrencia.TipoSite.NomeTipoSite : "";
                        currentColumn += 1;
                    }
                    
                    if(checkNomeSite != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Site != null ? ocorrencia.Site.NomeSite : "";
                        currentColumn += 1;
                    }

                    if (checkEstado != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Estado;
                        currentColumn += 1;
                    }

                    if (checkMunicipio != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Municipio;
                        currentColumn += 1;
                    }

                    if (checkCep != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.CEP;
                        currentColumn += 1;
                    }

                    if(checkEndereco != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Endereco;
                        currentColumn += 1;
                    }

                    if(checkTipoOcorrencia != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.TipoOcorrencia != null ? ocorrencia.TipoOcorrencia.NomeTipoOcorrencia : "";
                        currentColumn += 1;
                    }

                    if(checkQualificacao != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Qualificacao != null ? ocorrencia.Qualificacao.NomeQualificacao : "";
                        currentColumn += 1;
                    }
                    
                    if(checkInformacaoComplementar != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.InformacaoComplementar != null ? ocorrencia.InformacaoComplementar.NomeInformacaoComplementar : "";
                        currentColumn += 1;
                    }

                    if(checkSistemaRastreamento != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.SistemaRastreamento != null ? ocorrencia.SistemaRastreamento.NomeSistemaRastreamento : "";
                        currentColumn += 1;
                    }

                    if(checkSistemaFechaduraBluetooth != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.SistemaFechaduraBluetooth != null ? ocorrencia.SistemaFechaduraBluetooth.NomeSistemaFechaduraBluetooth : "";
                        currentColumn += 1;
                    }
                    
                    if(checkDetentora != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Detentora != null ? ocorrencia.Detentora.NomeDetentora : "";
                        currentColumn += 1;
                    }
                    
                    if(checkLocal != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Local != null ? ocorrencia.Local.NomeLocal : "";
                        currentColumn += 1;
                    }

                    if(checkAmbiente != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Ambiente;
                        currentColumn += 1;
                    }

                    if(checkTransportadora != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Transportadora != null ? ocorrencia.Transportadora.NomeTransportadora : "";
                        currentColumn += 1;
                    }

                    if(checkEventoERB != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.EventoERB != null ? ocorrencia.EventoERB.NomeEventoERB : "";
                        currentColumn += 1;
                    }

                    if(checkAlarmeRealAcidental != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.AlarmeRealAcidente != null ? ocorrencia.AlarmeRealAcidente.NomeAlarmeRealAcidente : "";
                        currentColumn += 1;
                    }

                    if(checkTipoAlarme != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.TipoAlarme;
                        currentColumn += 1;
                    }

                    if(checkPlaca != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Placa;
                        currentColumn += 1;
                    }

                    if(checkCondutor != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Condutor;
                        currentColumn += 1;
                    }

                    if(checkHistorico != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Historico;
                        currentColumn += 1;
                    }

                    if (checkDataConclusao != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.DataConclusao;
                        currentColumn += 1;
                    }

                    if(checkDataReagendamento != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.DataReagendamentoSis;
                        currentColumn += 1;
                    }

                    if(checkObservacao != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.ObservacaoSis;
                        currentColumn += 1;
                    }

                    if (checkAtendeuSLA != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.AtendimentoSLA?.NomeAtendimentoSLA ;
                        currentColumn += 1;
                    }

                    if (checkBombeiroCivil != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.BombeiroCivil?.NomeBombeiroCivil;
                        currentColumn += 1;
                    }

                    if (checkEmpresa != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Empresa?.NomeEmpresa;
                        currentColumn += 1;
                    }

                    if (checkDiasConclusao != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.DiasConclusao;
                        currentColumn += 1;
                    }

                    if (checkResponsavelOperacional != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.ResponsavelOperacionalId;
                        currentColumn += 1;
                    }

                    if (checkSeguimento != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.Seguimento?.NomeSeguimento;
                        currentColumn += 1;
                    }

                    if (checkRegistroPolicial != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.RegistroPolicial?.NomeRegistroPolicial;
                        currentColumn += 1;
                    }

                    if (checkOrgaoPublico != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.OrgaoPublico?.NomeOrgaoPublico;
                        currentColumn += 1;
                    }

                    if (checkPlanoDeEmergencia != null)
                    {
                        worksheet.Cell(currentRow, currentColumn).Value = ocorrencia.PlanoDeEmergencia?.NomePlanoDeEmergencia;
                        currentColumn += 1;
                    }

                    //if (checkQuantidadePerda != null)
                    //{
                    //    foreach (var perda in ocorrencia?.Perda)
                    //    {
                    //        worksheet.Cell(currentRow, currentColumn).Value = perda.QuantidadePerda;
                    //        currentColumn += 1;
                    //    }

                    //}

                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();


                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"filtroDeOcorrencias-{DateTime.Now:dd/MM/yyyy}.xlsx");
                }
            }

        }

    }
}
