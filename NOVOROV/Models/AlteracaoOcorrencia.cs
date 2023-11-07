using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class AlteracaoOcorrencia
    {
        public int Id { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string IPUsuario { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string NomeHost { get; set; }
        public DateTime DataAlteracao { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeCampo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ConteudoAtual { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ConteudoAnterior { get; set; }

    }
}
