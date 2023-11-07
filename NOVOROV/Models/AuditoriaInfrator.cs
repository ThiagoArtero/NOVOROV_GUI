using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class AuditoriaInfrator
    {
        public int Id { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

        [Column(TypeName = "varchar(15)")]
        [DisplayName("CPF do Infrator")]
        public string CPF { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nome do Infrator")]
        public string Nome { get; set; }

        [DisplayName("Recincidência")]
        public bool Reincidencia { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Justificativa")]
        public string Justificativa { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
