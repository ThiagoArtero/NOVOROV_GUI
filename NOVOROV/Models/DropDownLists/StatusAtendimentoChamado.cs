using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class StatusAtendimentoChamado
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? NomeStatusAtendimento { get; set; }


        [Column(TypeName = "varchar(100)")]
        public string? FuncaoStatusAtendimento { get; set; }

        public ICollection<Atendimento> Atendimento { get; set; }
    }
}
