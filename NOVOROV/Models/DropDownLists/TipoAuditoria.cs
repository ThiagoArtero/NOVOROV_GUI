using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class TipoAuditoria
    {
        public int TipoAuditoriaId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nome Tipo Auditoria")]
        public string NomeTipoAuditoria { get; set; }
    }
}
