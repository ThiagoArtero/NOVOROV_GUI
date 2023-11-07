using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Models
{
    public class TipoOcorrenciaTipoSite
    {
        public int Id { get; set; }
        public int? TipoSiteId { get; set; }
        public TipoSite? TipoSite { get; set; }

        public int? TipoOcorrenciaId { get; set; }
        public  TipoOcorrencia? TipoOcorrencia { get; set; }
    
    }
}
