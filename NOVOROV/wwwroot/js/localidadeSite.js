const urlUF = 'https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome';

const cidade = document.getElementById("siteMunicipio")
const uf = document.getElementById("siteUF")

uf.addEventListener('change', async function () {
    const urlCidades = 'https://servicodados.ibge.gov.br/api/v1/localidades/estados/' + uf.value + '/municipios';
    const request = await fetch(urlCidades)
    const response = await request.json()

    let options = '';
    response.forEach(function (cidades) {
        options += `<option value="${cidades.nome}"> ${cidades.nome} </option>`
    })
    cidade.innerHTML = options
})

window.addEventListener('load', async () => {
    const request = await fetch(urlUF)
    const response = await request.json()

    const options = document.createElement("optgroup")
    response.forEach(function (uf) {
        options.innerHTML += `<option value="${uf.sigla}"> ${uf.sigla} </option>`;
    })

    uf.append(options)

})