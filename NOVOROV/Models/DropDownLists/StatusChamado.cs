using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class StatusChamado
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? NomeStatusChamado { get; set; }

        public ICollection<Chamado>? Chamado { get; set; }
        public ICollection<Atendimento>? Atendimento { get; set; }
    }
}
