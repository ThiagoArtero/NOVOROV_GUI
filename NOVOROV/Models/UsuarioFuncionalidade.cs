using NOVOROV.Models.DropDownLists;

namespace NOVOROV.Models
{
    public class UsuarioFuncionalidade
    {
        public int Id { get; set; }

        public int? FuncionalidadeId { get; set; }
        public Funcionalidade? Funcionalidade { get; set; }

        public string? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
