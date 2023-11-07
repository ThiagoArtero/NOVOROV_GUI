using System;
using System.Diagnostics;
using System.IO;
using DocumentFormat.OpenXml.Bibliography;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Services
{
    public class PdfService
    {
        Document _document;
        PdfPTable _pdfTable = new PdfPTable(3);
        MemoryStream _memoryStream = new MemoryStream();

        public byte[] PrepareReport(Ocorrencia ocorrencia)
        {
            try
            {
                _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
                _document.SetPageSize(PageSize.A4);
                _document.SetMargins(80f, 80f, 30f, 30f);

                _pdfTable.WidthPercentage = 100;
                _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                PdfWriter.GetInstance(_document, _memoryStream);

                _document.Open();
                _pdfTable.SetWidths(new float[] { 20f, 150f, 100f });

                Paragraph titulo = new Paragraph($"Relatório Ocorrência {ocorrencia.Id}");

                titulo.SpacingAfter = 20;
                titulo.Font.Size = 20;
                titulo.Alignment = Element.ALIGN_CENTER;

                string dataRegistro = ocorrencia.DataRegistro.HasValue ? ocorrencia.DataRegistro.Value.ToString("dd:MM:yyyy HH:mm") : "";
                Paragraph pDataRegistro = GenerateParagraph("Data Registro", dataRegistro);

                string dataOcorrencia = ocorrencia.DataOcorrencia.HasValue ? ocorrencia.DataOcorrencia.Value.ToString("dd:MM:yyyy HH:mm") : "";
                Paragraph pDataOcorrencia = GenerateParagraph("Data Corrigido", dataOcorrencia);

                string informacaoOrigem = ocorrencia.InformacaoOrigem != null ? ocorrencia.InformacaoOrigem : "";
                Paragraph pInformacaoOrigem = GenerateParagraph("Informaçao Origem", informacaoOrigem);

                string cargoFuncao = ocorrencia.CargoFuncao != null ? ocorrencia.CargoFuncao : "";
                Paragraph pCargoFuncao = GenerateParagraph("Cargo Funçaõ", cargoFuncao);

                Phrase labelEmpresa = new Phrase("Empresa: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textEmpresa = new Phrase($"{ocorrencia.Empresa?.NomeEmpresa}", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pEmpresa = new Paragraph();
                pEmpresa.Add(labelEmpresa);
                pEmpresa.Add(textEmpresa);
                pEmpresa.SpacingAfter = 5;

                Phrase labelCmc = new Phrase("Cmc: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textCmc = new Phrase($"{ocorrencia.Cmc.NomeCmc}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pCmc = new Paragraph();
                pCmc.Add(labelCmc);
                pCmc.Add(textCmc);
                pCmc.SpacingAfter = 5;

                Phrase labelUsuarioOperador = new Phrase("Usuario Operador: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textUsuarioOperador = new Phrase($"{ocorrencia.UsuarioOperadorId}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pUsuarioOperador = new Paragraph();
                pUsuarioOperador.Add(labelUsuarioOperador);
                pUsuarioOperador.Add(textUsuarioOperador);
                pUsuarioOperador.SpacingAfter = 5;

                Phrase labelTipoOcorrencia = new Phrase("Tipo Ocorrencia: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textTipoOcorrencia = new Phrase($"{ocorrencia.TipoOcorrencia?.NomeTipoOcorrencia}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pTipoOcorrencia = new Paragraph();
                pTipoOcorrencia.Add(labelTipoOcorrencia);
                pTipoOcorrencia.Add(textTipoOcorrencia);
                pTipoOcorrencia.SpacingAfter = 5;

                Phrase labelQualificacao = new Phrase("Qualificacao: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textQualificacao = new Phrase($"{ocorrencia.Qualificacao?.NomeQualificacao}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pQualificacao = new Paragraph();
                pQualificacao.Add(labelQualificacao);
                pQualificacao.Add(textQualificacao);
                pQualificacao.SpacingAfter = 5;

                Phrase labelTipoAcesso = new Phrase("Tipo Acesso: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textTipoAcesso = new Phrase($"{ocorrencia.TipoAcesso?.NomeTipoAcesso}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pTipoAcesso = new Paragraph();
                pTipoAcesso.Add(labelTipoAcesso);
                pTipoAcesso.Add(textTipoAcesso);
                pTipoAcesso.SpacingAfter = 5;

                Phrase labelTipoSite = new Phrase("Tipo Site: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textTipoSite = new Phrase($"{ocorrencia.TipoSite?.NomeTipoSite}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pTipoSite = new Paragraph();
                pTipoSite.Add(labelTipoSite);
                pTipoSite.Add(textTipoSite);
                pTipoSite.SpacingAfter = 5;


                Phrase labelSite = new Phrase("Nome Site: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textSite = new Phrase($"{ocorrencia.Site?.NomeSite}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pSite = new Paragraph();
                pSite.Add(labelSite);
                pSite.Add(textSite);
                pSite.SpacingAfter = 5;

                string estado = ocorrencia.Estado != null ? ocorrencia.Estado : "";
                Paragraph pEstado = GenerateParagraph("Estado", estado);

                string municipio = ocorrencia.Municipio != null ? ocorrencia.Municipio : "";
                Paragraph pMunicipio = GenerateParagraph("Municipio", municipio);

                string cep = ocorrencia.CEP != null ? ocorrencia.CEP : "";
                Paragraph pCEP = GenerateParagraph("CEP", cep);

                string endereco = ocorrencia.Endereco != null ? ocorrencia.Endereco : "";
                Paragraph pEndereco = GenerateParagraph("Endereco", endereco);

                string ambiente = ocorrencia.Ambiente != null ? ocorrencia.Ambiente : "";
                Paragraph pAmbiente = GenerateParagraph("Ambiente", ambiente);

                Phrase labelLocal = new Phrase("Local: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textLocal = new Phrase($"{ocorrencia.Local.NomeLocal}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pLocal = new Paragraph();
                pLocal.Add(labelLocal);
                pLocal.Add(textLocal);
                pLocal.SpacingAfter = 5;

                Phrase labelAlarmeRealAcidente = new Phrase("Alarme Real Acidente: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textAlarmeRealAcidente = new Phrase($"{ocorrencia.AlarmeRealAcidente.NomeAlarmeRealAcidente}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pAlarmeRealAcidente = new Paragraph();
                pAlarmeRealAcidente.Add(labelAlarmeRealAcidente);
                pAlarmeRealAcidente.Add(textAlarmeRealAcidente);
                pAlarmeRealAcidente.SpacingAfter = 5;

                string tipoAlarme = ocorrencia.TipoAlarme != null ? ocorrencia.TipoAlarme : "";
                Paragraph pTipoAlarme = GenerateParagraph("Tipo Alarme", tipoAlarme);

                string placa = ocorrencia.Placa != null ? ocorrencia.Placa : "";
                Paragraph pPlaca = GenerateParagraph("Placa", placa);

                string condutor = ocorrencia.Condutor != null ? ocorrencia.Condutor : "";
                Paragraph pCondutor = GenerateParagraph("Condutor", condutor);


                Phrase labelEventoERB = new Phrase("Evento ERB: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textEventoERB = new Phrase($"{ocorrencia.EventoERB.NomeEventoERB}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pEventoERB = new Paragraph();
                pEventoERB.Add(labelEventoERB);
                pEventoERB.Add(textEventoERB);
                pEventoERB.SpacingAfter = 5;

                Phrase labelResponsavelOperacional = new Phrase("Responsavel Operacional: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textResponsavelOperacional = new Phrase($"{ocorrencia.ResponsavelOperacionalId}", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pResponsavelOperacional = new Paragraph();
                pResponsavelOperacional.Add(labelResponsavelOperacional);
                pResponsavelOperacional.Add(textResponsavelOperacional);
                pResponsavelOperacional.SpacingAfter = 5;

                //string dataAcionamentoOperacional = ocorrencia.DataAcionamentoOperacional.HasValue ? ocorrencia.DataAcionamentoOperacional.Value.ToString("dd:MM:yyyy HH:mm") : "";
                //Paragraph pDataAcionamentoOperacional = GenerateParagraph("Data Acionamento Pronto Atendimento", dataAcionamentoOperacional);

                Phrase labelAcionadoProntoAtendimento = new Phrase("Acionado Pronto Atendimento: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textAcionadoProntoAtendimento = new Phrase($"{ocorrencia.AcionadoProntoAtendimento.NomeAcionadoProntoAtendimento}", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pAcionadoProntoAtendimento = new Paragraph();
                pAcionadoProntoAtendimento.Add(labelAcionadoProntoAtendimento);
                pAcionadoProntoAtendimento.Add(textAcionadoProntoAtendimento);
                pAcionadoProntoAtendimento.SpacingAfter = 5;

                Phrase labelEmpresaProntoAtendimento = new Phrase("Empresa Pronto Atendimento: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textEmpresaProntoAtendimento = new Phrase($"{ocorrencia.EmpresaProntoAtendimento?.NomeEmpresaProntoAtendimento}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pEmpresaProntoAtendimento = new Paragraph();
                pEmpresaProntoAtendimento.Add(labelEmpresaProntoAtendimento);
                pEmpresaProntoAtendimento.Add(textEmpresaProntoAtendimento);
                pEmpresaProntoAtendimento.SpacingAfter = 5;

                string dataAcionamentoProntoAtendimento = ocorrencia.DataAcionamentoProntoAtendimento.HasValue ? ocorrencia.DataAcionamentoProntoAtendimento.Value.ToString("dd:MM:yyyy HH:mm") : "";
                Paragraph pDataAcionamentoProntoAtendimento = GenerateParagraph("Data Acionamento Pronto Atendimento", dataAcionamentoProntoAtendimento);

                Phrase labelPlanoDeEmergencia = new Phrase("PlanoDeEmergencia: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textPlanoDeEmergencia = new Phrase($"{ocorrencia.PlanoDeEmergencia.NomePlanoDeEmergencia}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pPlanoDeEmergencia = new Paragraph();
                pPlanoDeEmergencia.Add(labelPlanoDeEmergencia);
                pPlanoDeEmergencia.Add(textPlanoDeEmergencia);
                pPlanoDeEmergencia.SpacingAfter = 5;

                Phrase labelBombeiroCivil = new Phrase("Bombeiro Civil: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textBombeiroCivil = new Phrase($"{ocorrencia.BombeiroCivil.NomeBombeiroCivil}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pBombeiroCivil = new Paragraph();
                pBombeiroCivil.Add(labelBombeiroCivil);
                pBombeiroCivil.Add(textBombeiroCivil);
                pBombeiroCivil.SpacingAfter = 5;

                Phrase labelManutencao = new Phrase("Manutencao: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textManutencao = new Phrase($"{ocorrencia.Manutencao?.NomeManutencao}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pManutencao = new Paragraph();
                pManutencao.Add(labelManutencao);
                pManutencao.Add(textManutencao);
                pManutencao.SpacingAfter = 5;

                Phrase labelAreaSaude = new Phrase("Area Saude: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textAreaSaude = new Phrase($"{ocorrencia.AreaSaude?.NomeAreaSaude}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pAreaSaude = new Paragraph();
                pAreaSaude.Add(labelAreaSaude);
                pAreaSaude.Add(textAreaSaude);
                pAreaSaude.SpacingAfter = 5;

                Phrase labelAreaInterna = new Phrase("Area Interna: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textAreaInterna = new Phrase($"{ocorrencia.AreaInterna?.NomeAreaInterna}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pAreaInterna = new Paragraph();
                pAreaInterna.Add(labelAreaInterna);
                pAreaInterna.Add(textAreaInterna);
                pAreaInterna.SpacingAfter = 5;

                Phrase labelFornecimentoImagem = new Phrase("Fornecimento Imagem: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textFornecimentoImagem = new Phrase($"{ocorrencia.FornecimentoImagem?.NomeFornecimentoImagem}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pFornecimentoImagem = new Paragraph();
                pFornecimentoImagem.Add(labelFornecimentoImagem);
                pFornecimentoImagem.Add(textFornecimentoImagem);
                pFornecimentoImagem.SpacingAfter = 5;

                Phrase labelFornecimentoAcessoFisico = new Phrase("Fornecimento Acesso Fisico: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textFornecimentoAcessoFisico = new Phrase($"{ocorrencia.FornecimentoAcessoFisico?.NomeFornecimentoAcessoFisico}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pFornecimentoAcessoFisico = new Paragraph();
                pFornecimentoAcessoFisico.Add(labelFornecimentoAcessoFisico);
                pFornecimentoAcessoFisico.Add(textFornecimentoAcessoFisico);
                pFornecimentoAcessoFisico.SpacingAfter = 5;

                Phrase labelFornecimentoEventoAlarme = new Phrase("Fornecimento Evento Alarme: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textFornecimentoEventoAlarme = new Phrase($"{ocorrencia.FornecimentoEventoAlarme?.NomeFornecimentoEventoAlarme}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pFornecimentoEventoAlarme = new Paragraph();
                pFornecimentoEventoAlarme.Add(labelFornecimentoEventoAlarme);
                pFornecimentoEventoAlarme.Add(textFornecimentoEventoAlarme);
                pFornecimentoEventoAlarme.SpacingAfter = 5;

                string numeroRegistroPolicial = ocorrencia.NumeroRegistroPolicial != null ? ocorrencia.NumeroRegistroPolicial : "";
                Paragraph pNumeroRegistroPolicial = GenerateParagraph("Registro", numeroRegistroPolicial);



                Phrase labelAtendimentoSLA = new Phrase("Atendimento SLA ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textAtendimentoSLA = new Phrase($"{ocorrencia.AtendimentoSLA?.NomeAtendimentoSLA}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pAtendimentoSLA = new Paragraph();
                pAtendimentoSLA.Add(labelAtendimentoSLA);
                pAtendimentoSLA.Add(textAtendimentoSLA);
                pAtendimentoSLA.SpacingAfter = 5;

                Paragraph pHistorico = GenerateParagraph("Historico", ocorrencia.Historico);

                Paragraph pProvidenciaConclusao = GenerateParagraph("Providencia", ocorrencia.ProvidenciaConclusao);

                Paragraph pConclusao = GenerateParagraph("Conclusao", ocorrencia.Conclusao);

                string dataConclusao = ocorrencia.DataConclusao.HasValue ? ocorrencia.DataConclusao.Value.ToString("dd:MM:yyyy HH:mm") : "";
                Paragraph pDataConclusao = GenerateParagraph("Data Conclusao", dataConclusao);

                //string diasConclusao = ocorrencia.DiasConclusao.HasValue ? ocorrencia.DiasConclusao.Value.ToString("dd:MM:yyyy HH:mm") : "";
                //Paragraph pDiasConclusao = GenerateParagraph("Dias Conclusao", diasConclusao);

                Paragraph pDiasConclusao = GenerateParagraph("Dias Conclusao", ocorrencia.DiasConclusao.ToString());

                Phrase labelStatus = new Phrase("Status: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                Phrase textStatus = new Phrase($"{ocorrencia.Status?.NomeStatus}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                Paragraph pStatus = new Paragraph();
                pStatus.Add(labelStatus);
                pStatus.Add(textStatus);
                pStatus.SpacingAfter = 5;



                _document.Add(titulo);
                _document.Add(pDataRegistro);
                _document.Add(pDataOcorrencia);
                _document.Add(pInformacaoOrigem);
                _document.Add(pCargoFuncao);
                _document.Add(pEmpresa);
                _document.Add(pCmc);
                _document.Add(pUsuarioOperador);
                _document.Add(pTipoOcorrencia);
                _document.Add(pQualificacao);
                _document.Add(pTipoAcesso);
                _document.Add(pTipoSite);
                _document.Add(pSite);
                _document.Add(pEstado);
                _document.Add(pMunicipio);
                _document.Add(pCEP);
                _document.Add(pEndereco);
                _document.Add(pAmbiente);
                _document.Add(pLocal);
                _document.Add(pAlarmeRealAcidente);
                _document.Add(pTipoAlarme);
                _document.Add(pPlaca);
                _document.Add(pCondutor);
                _document.Add(pEventoERB);
                _document.Add(pResponsavelOperacional);
                //_document.Add(pDataAcionamentoOperacional);
                _document.Add(pAcionadoProntoAtendimento);
                _document.Add(pEmpresaProntoAtendimento);
                _document.Add(pDataAcionamentoProntoAtendimento);
                _document.Add(pPlanoDeEmergencia);
                _document.Add(pBombeiroCivil);
                _document.Add(pManutencao);
                _document.Add(pAreaSaude);
                _document.Add(pAreaInterna);
                _document.Add(pFornecimentoImagem);
                _document.Add(pFornecimentoAcessoFisico);
                _document.Add(pFornecimentoEventoAlarme);
                _document.Add(pNumeroRegistroPolicial);
                _document.Add(pAtendimentoSLA);
                _document.Add(pHistorico);
                _document.Add(pProvidenciaConclusao);
                _document.Add(pConclusao);
                _document.Add(pDataConclusao);
                _document.Add(pDiasConclusao);
                _document.Add(pStatus);

                Paragraph tituloPerda = new Paragraph($"Perdas");
                _document.Add(tituloPerda);

                foreach (var perda in ocorrencia.Perda)
                {

                    Paragraph pId = GenerateParagraph("NumeroPerda", perda.Id.ToString());
                    Phrase labelTipoEquipamentoId = new Phrase("Tipo Equipamento: ", FontFactory.GetFont("arial", 13, Font.BOLD));
                    Phrase textTipoEquipamentoId = new Phrase($"{perda.TipoEquipamentoId}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
                    Paragraph pTipoEquipamentoId = new Paragraph();
                    pTipoEquipamentoId.Add(labelTipoEquipamentoId);
                    pTipoEquipamentoId.Add(textTipoEquipamentoId);
                    pTipoEquipamentoId.SpacingAfter = 5;

                    Paragraph pQuantidadePerda = GenerateParagraph("Quantidade", perda.QuantidadePerda.ToString());

                    Paragraph pValorPerda = GenerateParagraph("Valor Perda", perda.ValorPerda.ToString());

                    Paragraph pValorEfetivamenteRecuperado = GenerateParagraph("Valor Recuperado", perda.ValorEfetivamenteRecuperado.ToString());

                    Paragraph pValorPerdaEvitada = GenerateParagraph("Valor Evitado", perda.ValorPerdaEvitada.ToString());

                    Paragraph pCodigoSinistro = GenerateParagraph("Codigo Sinistro", perda.CodigoSinistro.ToString());

                    _document.Add(pId);
                    _document.Add(pTipoEquipamentoId);
                    _document.Add(pQuantidadePerda);
                    _document.Add(pValorPerda);
                    _document.Add(pValorEfetivamenteRecuperado);
                    _document.Add(pValorPerdaEvitada);
                    _document.Add(pCodigoSinistro);

                    //Paragraph UsuarioDownload = GenerateParagraph("Criado por" + );
                }
                _document.Close();
                return _memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        private Paragraph GenerateParagraph(string label, string value)
        {
            Phrase labelText = new Phrase($"{label}: ", FontFactory.GetFont("arial", 13, Font.BOLD));
            Phrase valueText = new Phrase($"{value}\n", FontFactory.GetFont("arial", 13, Font.NORMAL));
            Paragraph paragraph = new Paragraph();
            paragraph.Add(labelText);
            paragraph.Add(valueText);
            paragraph.SpacingAfter = 5;
            return paragraph;
        }
    }
}
