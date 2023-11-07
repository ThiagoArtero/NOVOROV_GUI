using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models.DropDownLists
{
    public class TipoApoliceSeguro
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NomeTipoApoliceSeguro { get; set; }
        
        public ICollection<ApoliceSeguro> ApoliceSeguros { get; set; }


    }
}
