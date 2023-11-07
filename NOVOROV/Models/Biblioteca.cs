using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NOVOROV.Models.DropDownLists;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }

        [DisplayName("Data")]
        public DateTime? DataAtualizacao { get; set; }


        [Column(TypeName = "varchar(300)")]
        [DisplayName("Descrição")]
        public string? DescricaoAnexo { get; set; }

        [Column(TypeName = "varchar(2)")]
        public string? UF { get; set; }

        [DisplayName("Analista Solicitante")]
        public string? AnalistaSolicitanteId { get; set; }
        public Usuario? AnalistaSolicitante { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Nome")]
        public string? NomeAnexo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ContentType { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Bytes { get; set; }

        [DisplayName("Tipo Biblioteca")]
        public int TipoBibliotecaId { get; set; }
        public TipoBiblioteca TipoBiblioteca { get; set; }

    }
}
