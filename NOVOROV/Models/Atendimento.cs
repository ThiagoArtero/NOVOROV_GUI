using NOVOROV.Models.DropDownLists;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int? ChamadoId { get; set; }
        public Chamado? Chamado { get; set; }

        [DisplayName("Resposta")]
        public string? Resposta { get; set; }

        public int? StatusAtendimentoChamadoId { get; set; }
        public StatusAtendimentoChamado? StatusAtendimentoChamado { get; set; }

        public string? UsuarioRespostaId { get; set; }
        public Usuario? UsuarioResposta { get; set; }

        public DateTime? DataAtendimento { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Nome Anexo")]
        public string? NomeAnexoAtendimento { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? ContentType { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[]? Bytes { get; set; }

        public int? StatusChamadoId { get; set; }
        public StatusChamado? StatusChamado { get; set; }

    }
}
