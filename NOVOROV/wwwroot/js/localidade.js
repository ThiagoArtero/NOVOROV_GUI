
function esconderCampo() {

    var tabela = document.querySelector("#tableOcorrenciass");
    console.log(tabela);
    var linhas = tabela.getElementsByTagName('tr');

    var checkId = document.getElementById('checkId');
    var checkCmc = document.getElementById('checkCmc');
    var checkStatus = document.getElementById('checkStatus');
    var checkEventoERB = document.getElementById('checkEventoERB');
    var checkDataOcorrencia = document.getElementById('checkDataOcorrencia');
    var checkAcionadoProntoAtendimento = document.getElementById('checkAcionadoProntoAtendimento');
    var checkAlarmeRealAcidental = document.getElementById('checkAlarmeRealAcidental');
    var checkAmbiente = document.getElementById('checkAmbiente');
    var checkAnaliseConclusao = document.getElementById('checkAnaliseConclusao');
    var checkAreaInterna = document.getElementById('checkAreaInterna');
    var checkAreaSaude = document.getElementById('checkAreaSaude');
    var checkAreaTratamento = document.getElementById('checkAreaTratamento');
    var checkAtendeuSLA = document.getElementById('checkAtendeuSLA');
    var checkBombeiroCivil = document.getElementById('checkBombeiroCivil');
    var checkCargoFuncao = document.getElementById('checkCargoFuncao');
    var checkCep = document.getElementById('checkCep');
    var checkConclusao = document.getElementById('checkConclusao');
    var checkCondutor = document.getElementById('checkCondutor');
    var checkDataConclusao = document.getElementById('checkDataConclusao');
    var checkDetentora = document.getElementById('checkDetentora');
    var checkDataReagendamentoSis = document.getElementById('checkDataReagendamentoSis');
    var checkDiasConclusao = document.getElementById('checkDiasConclusao');
    var checkEmpresa = document.getElementById('checkEmpresa');
    var checkEndereco = document.getElementById('checkEndereco');
    var checkLocal = document.getElementById('checkLocal');
    var checkManutencao = document.getElementById('checkManutencao');
    var checkMunicipio = document.getElementById('checkMunicipio');
    var checkNomeSite = document.getElementById('checkNomeSite');
    var checkPlaca = document.getElementById('checkPlaca');
    var checkResponsavelOperacional = document.getElementById('checkResponsavelOperacional');
    var checkSistemaFechaduraBluetooth = document.getElementById('checkSistemaFechaduraBluetooth');
    var checkSistemaRastreamento = document.getElementById('checkSistemaRastreamento');
    var checkTipoAlarme = document.getElementById('checkTipoAlarme');
    var checkTipoSite = document.getElementById('checkTipoSite');
    var checkTransportadora = document.getElementById('checkTransportadora');
    var checkSeguimento = document.getElementById('checkSeguimento');
    var checkObservacao = document.getElementById('checkObservacao');
    var checkUsuarioAlteracaoOcorrencia = document.getElementById('checkUsuarioAlteracaoOcorrencia');
    var checkRecuperacao = document.getElementById('checkRecuperacao');
    var checkPerda = document.getElementById('checkPerda');
    var checkRegistroPolicial = document.getElementById('checkRegistroPolicial');
    var checkMotivoSis = document.getElementById('checkMotivoSis');
    var checkQuantidadePerda = document.getElementById('checkQuantidadePerda');
    var checkPlanoDeEmergencia = document.getElementById('checkPlanoDeEmergencia');


    var arrayDeCheck = [checkId, checkDataOcorrencia, checkCmc, checkStatus, checkEventoERB, checkHistorico,
        checkinformacaoComplementar, checkLocal, checkManutencao, checkMunicipio, checkNomeSite, checkPlaca,
        checkSistemaFechaduraBluetooth, checkSistemaRastreamento, checkEstado, checkTipoSite, checkDataRegistro,
        checkTipoOcorrencia, checkInbox, checkResponsavelOperacional, checkSeguimento, checkAcionadoProntoAtendimento,
        checkAlarmeRealAcidental, checkAmbiente, checkAnaliseConclusao, checkAreaInterna, checkAreaSaude, checkAreaTratamento,
        checkAtendeuSLA, checkBombeiroCivil, checkCargoFuncao, checkCep, checkConclusao, checkCondutor, checkDataConclusao, checkDetentora, checkDataReagendamentoSis,
        checkDiasConclusao, checkEmpresa, checkEndereco, checkTipoAlarme, checkTransportadora, checkObservacao, checkUsuarioAlteracaoOcorrencia,
        checkRecuperacao, checkPerda, checkRegistroPolicial, checkMotivoSis, checkQuantidadePerda, checkPlanoDeEmergencia];


    for (var i = 0; i < arrayDeCheck.length; i++) {
        if (arrayDeCheck[i].checked == false) {
            var nomeElemento = arrayDeCheck[i].value;

            for (var j = 1; j < linhas.length; j++) {
                linhaStatus = linhas[j].querySelector(`#${nomeElemento}Linha`);
                linhaStatus.setAttribute('style', 'display:none');

            }
            var header = document.getElementById(`${nomeElemento}Header`);
            header.setAttribute('style', 'display:none');
        }
    }
    
}

const urlUF = 'https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome';
const ufFiltro = document.getElementById("filtroUF")

window.addEventListener('load', async () => {
    const request = await fetch(urlUF)
    const response = await request.json()

    const options = document.createElement("optgroup")
    response.forEach(function (uf) {
        options.innerHTML += `<option value="${uf.sigla}"> ${uf.sigla} </option>`;
    })

    ufFiltro.append(options)

})