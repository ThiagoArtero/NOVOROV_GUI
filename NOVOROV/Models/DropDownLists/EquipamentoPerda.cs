using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class EquipamentoPerda
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nome Equipamento Perda")]
        public string NomeEquipamentoPerda { get; set; }


        public int TipoEquipamentoId { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }

        //public string UsuarioId { get; set; }
        //public Usuario Usuario { get;set; }
    }
}
