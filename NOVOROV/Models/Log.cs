using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class Log
    {
        public int Id { get; set; }


        public int? OcorrenciaId { get; set; }
        public Ocorrencia? Ocorrencia { get; set; }

        public string OperadorId { get; set; }

        public Usuario Operador { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? IpOperador { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Hostname { get; set; }

        public DateTime? DataAlteracao { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? NomeCampo { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? ConteudoAnterior { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? ConteudoAtual { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Acao { get; set; }
    }
}
