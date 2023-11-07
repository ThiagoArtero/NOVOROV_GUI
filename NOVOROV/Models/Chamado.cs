using NOVOROV.Models.DropDownLists;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class Chamado
    {
        [DisplayName("Chamado")]
        public int Id { get; set; }

        [DisplayName("Usuário operador")]
        public string? UsuarioOperadorId { get; set; }
        public Usuario? UsuarioOperador { get; set; }

        [DisplayName("Solicitante")]
        public string? SolicitanteId { get; set; }
        public Usuario? Solicitante { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayName("Abertura")]
        public DateTime? DataAbertura { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayName("Encerramento")]
        public DateTime? DataEncerramento { get; set; }

        [DisplayName("E-mail Solicitante")]
        public string? EmailSolicitante { get; set; }

        [DisplayName("Estado")]
        [Column(TypeName = "varchar(2)")]
        public string? UF { get; set; }

        [DisplayName("Loja")]
        public string? loja { get; set; }

        [DisplayName("Responsável")]
        public string? ResponsavelTrativa { get; set; }

        [DisplayName("Contato Responsável")]
        public string? ContatoResponsavel { get; set; }

        [DisplayName("E-mail responsável pela tratativa")]
        public string? EmailResponsavelTratativa { get; set; }

        [DisplayName("Solicitação")]
        public string? Solicitacao { get; set; }

        [DisplayName("Status")]
        public int? StatusChamadoId { get; set; }
        public StatusChamado? StatusChamado { get; set; }

        public ICollection<StatusAtendimentoChamado> StatusAtendimentoChamado { get; set; }

        public ICollection<Atendimento> Atendimento { get; set; }

        public ICollection<AnexosChamado> AnexoChamado { get; set; }
    }
}
