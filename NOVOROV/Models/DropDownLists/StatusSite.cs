using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace NOVOROV.Models.DropDownLists
{
    public class StatusSite
    {

        public int Id { get; set; }

        [DisplayName("Nome Status Site")]
        [Column(TypeName = "varchar(20)")]
        public string NomeStatusSite { get; set; }

        public ICollection<Site> Site { get; set; }

    }
}
