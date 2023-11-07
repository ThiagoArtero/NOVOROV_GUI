using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class TipoRelatorio
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? NomeTipoRelatorio { get; set; }
    }
}
