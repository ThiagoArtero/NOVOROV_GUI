using NOVOROV.Models.DropDownLists;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace NOVOROV.Models
{
    public class Espelho
    {
        public int Id { get; set; }


        public string? AnalistaCriadorId { get; set; }
        [DisplayName("Analista Criador")]
        public Usuario? AnalistaCriador { get; set; }

        [Column(TypeName = "varchar(300)")]
        [DisplayName("Nome Espelho")]
        public string? NomeEspelho { get; set; }

        [DisplayName("Data")]
        public DateTime? DataEspelho { get; set; }

        [DisplayName("Data Envio Financeiro")]
        public DateTime? DataEnvioFinanceiro { get; set; }

        [DisplayName("Data Envio Analise")]
        public DateTime? DataEnvioAnalise { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ContentType { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Bytes { get; set; }

    }
}
