using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class Aviso
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Titulo { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; set; }
    }
}

