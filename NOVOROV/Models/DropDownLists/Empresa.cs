using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class Empresa
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeEmpresa { get; set; }

        public ICollection<Ocorrencia> Ocorrencia { get; set; }
    }
}
