using NOVOROV.Models.DropDownLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class Usuario
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Matrícula")]
        public string UsuarioId { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Nome")]
        public string? NomeUsuario { get; set; }

        [DisplayName("Data Inicio Acesso")]
        public DateTime? DataInicioAcesso { get; set; }

        [DisplayName("Data Fim Acesso")]
        public DateTime? DataFimAcesso { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Email")]
        public string? EmailUsuario { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Telefone")]
        public string? TelefoneUsuario { get; set; }

        [DisplayName("Perfil")]
        public int? PerfilId { get; set; }
        public Perfil? Perfil { get; set; }

        [DisplayName("CMC")]
        public int? CmcId { get; set; }
        public Cmc? Cmc { get; set; }

        [DisplayName("Gestor")]
        public int? GestorId { get; set; }
        public Gestor? Gestor { get; set; }

        public ICollection<Ocorrencia> Ocorrencia { get; set; }
        public ICollection<Anexo> Anexo { get; set; }
        public ICollection<UsuarioFuncionalidade> UsuarioFuncionalidade { get; set; }
    }
}
