using NOVOROV.Models.DropDownLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class Anexo
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Nome")]
        public string NomeAnexo { get; set; }

        [DisplayName("Data")]
        public DateTime DataAnexo { get; set; }

        [DisplayName("Autor")]
        public string AutorId { get; set; }
        public Usuario Autor { get; set; }

        [Column(TypeName = "varchar(300)")]
        [DisplayName("Descrição")]
        public string DescricaoAnexo { get; set; }

        [DisplayName("Tipo")]
        public int TipoAnexoId { get; set; }
        public TipoAnexo TipoAnexo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ContentType { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Bytes { get; set; }

        [DisplayName("Versão Anexo")]
        public int NumeroVersaoAnexo { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
    }
}
