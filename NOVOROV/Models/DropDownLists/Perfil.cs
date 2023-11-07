using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class Perfil
    {
        public int Id { get; set; }


        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nome Perfil")]
        public string NomePerfil { get; set; }

        public ICollection<Usuario> Usuario { get; set; }

        public ICollection<PerfilFuncionalidade> PerfilFuncionalidade { get; set; }
    }
}
