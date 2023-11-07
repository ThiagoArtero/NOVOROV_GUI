using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace NOVOROV.Models.DropDownLists
{
    public class Funcionalidade
    {
        public int Id { get; set; }


        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nome Funcionalidade")]
        public string NomeFuncionalidade { get; set; }


        [Column(TypeName = "varchar(100)")]
        [DisplayName("Descrição Funcionalidade")]
        public string DescricaoFuncionalidade { get; set; }

        public ICollection<PerfilFuncionalidade>  PerfilFuncionalidade  {get; set; }
        public ICollection<UsuarioFuncionalidade> UsuarioFuncionalidade { get; set; }
    }
}
