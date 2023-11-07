using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class Observacao
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string DescricaoObservacao { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
    }
}
