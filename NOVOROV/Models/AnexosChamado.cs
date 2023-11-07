using NOVOROV.Models.DropDownLists;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace NOVOROV.Models
{
    public class AnexosChamado
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Nome Anexo")]
        public string? NomeAnexo { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Produto")]
        public string? Produto { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Quantidade")]
        public int? Quantidade { get; set; }

        [Column(TypeName = "varchar(300)")]
        [DisplayName("Comentário")]
        public string? Comentario { get; set; }

        [Column(TypeName = "varchar(300)")]
        [DisplayName("Código")]
        public string? Codigo { get; set; }

        [DisplayName("Data")]
        public DateTime DataAnexo { get; set; }

        [DisplayName("Autor")]
        public string? AutorId { get; set; }
        public Usuario? Autor { get; set; }

        [Column(TypeName = "varchar(300)")]
        [DisplayName("Descrição")]
        public string? DescricaoAnexo { get; set; }

        [DisplayName("Tipo")]
        public int? TipoAnexoId { get; set; }
        public TipoAnexo? TipoAnexo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ContentType { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Bytes { get; set; }

        [DisplayName("Versão Anexo")]
        public int? NumeroVersaoAnexo { get; set; }

        [DisplayName("Status")]
        public bool? Status { get; set; }

        public int ChamadoId { get; set; }
        public Chamado Chamado { get; set; }
    }
}

