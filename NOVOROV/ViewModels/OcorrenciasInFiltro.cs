using NOVOROV.Models;

namespace NOVOROV.ViewModels
{
    public class OcorrenciasInFiltro
    {
        public Ocorrencia Ocorrencia { get; set; }
        public ICollection<Ocorrencia> OcorrenciasFiltradas { get; set; }
        public ModeloRelatorio ModeloRelatorio { get; set; }
        public ICollection<ModeloRelatorio> ModelosRelatorios { get; set; }
    }
}
