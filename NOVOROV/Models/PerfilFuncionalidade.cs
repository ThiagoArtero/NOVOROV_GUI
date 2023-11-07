using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NOVOROV.Models.DropDownLists;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace NOVOROV.Models
{
    public class PerfilFuncionalidade
    {
        public int Id { get; set; }

        public int FuncionalidadeId { get; set; }
        public Funcionalidade? Funcionalidade { get; set; }
            
        public int PerfilId  { get; set; }
        public Perfil? Perfil { get; set; }

       
    }
}
