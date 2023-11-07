using NOVOROV.Models.DropDownLists;

namespace NOVOROV.ViewModels
{
    public class AlteracaoTabelaViewModel
    {
        public IEnumerable<AcaoTomada> AcaoTomada { get; set; }
        public IEnumerable<AcionadoProntoAtendimento> AcionadoProntoAtendimento { get; set; }
        public IEnumerable<AnaliseConclusao> AnaliseConclusao { get; set; }
        public IEnumerable<TipoRessarcimento> TipoRessarcimento { get; set; }
        public IEnumerable<AlarmeRealAcidente> AlarmeRealAcidente { get; set; }
        public IEnumerable<Detentora> Detentora { get; set; }
        public IEnumerable<Empresa> Empresa { get; set; }
        public IEnumerable<EventoERB> EventoERB { get; set; }
        public IEnumerable<GestaoPerda> GestaoPerda { get; set; }

        ////public IEnumerable<AreaDemandante> AreaDemandantes { get; set; }
        ////public IEnumerable<Ambiente> Ambientes { get; set; }
        ////public IEnumerable<MaterialEquipamento> Equipamentos { get; set; }
    }
}
