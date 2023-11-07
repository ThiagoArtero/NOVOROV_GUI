function toggleNotificationPanel() {
    $('#divNotificationContainer').toggleClass('openNotifPanel');
}


//function esconderCampo() {


//    var tabela = document.querySelector("#tableOcorrencias");
//    var linhas = tabela.getElementsByTagName('tr');

//    var checkId = document.getElementById('checkId');
//    var checkCmc = document.getElementById('checkCmc');
//    var checkStatus = document.getElementById('checkStatus');
//    var checkEventoERB = document.getElementById('checkEventoERB');
//    var checkDataOcorrencia = document.getElementById('checkDataOcorrencia');
//    var checkAcionadoProntoAtendimento = document.getElementById('checkAcionadoProntoAtendimento');


//    var arrayDeCheck = [checkId, checkDataOcorrencia, checkCmc, checkStatus, checkEventoERB, checkHistorico,
//        checkinformacaoComplementar, checkLocal, checkManutencao, checkMunicipio, checkNomeSite, checkPlaca,
//        checkSistemaFechaduraBluetooth, checkSistemaRastreamento, checkEstado, checkTipoSite, checkDataRegistro,
//        checkTipoOcorrencia, checkInbox, checkResponsavelOperacional, checkSeguimento, checkAcionadoProntoAtendimento];

//    for (var i = 0; i < arrayDeCheck.length; i++) {
//        if (arrayDeCheck[i].checked == false) {
//            var nomeElemento = arrayDeCheck[i].value;
//            console.log(nomeElemento)

//            for (var j = 1; j < linhas.length; j++) {
//                linhaStatus = linhas[j].querySelector(`#${nomeElemento}Linha`);
//                linhaStatus.setAttribute('style', 'display:none');
//            }
//            var header = document.getElementById(`${nomeElemento}Header`);
//            header.setAttribute('style', 'display:none');
//        }
//    }

//}


//const urlUF = 'https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome';

//const cidade = document.getElementById("siteMunicipio")
//const uf = document.getElementById("siteUF")

//uf.addEventListener('change', async function () {
//    const urlCidades = 'https://servicodados.ibge.gov.br/api/v1/localidades/estados/' + uf.value + '/municipios';
//    const request = await fetch(urlCidades)
//    const response = await request.json()

//    let options = '';
//    response.forEach(function (cidades) {
//        options += `<option value="${cidades.nome}"> ${cidades.nome} </option>`
//    })
//    cidade.innerHTML = options
//})

//window.addEventListener('load', async () => {
//    const request = await fetch(urlUF)
//    const response = await request.json()

//    const options = document.createElement("optgroup")
//    response.forEach(function (uf) {
//        options.innerHTML += `<option value="${uf.sigla}"> ${uf.sigla} </option>`;
//    })

//    uf.append(options)

//})





