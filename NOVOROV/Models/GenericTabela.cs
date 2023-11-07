using NOVOROV.Interfaces;

namespace NOVOROV.Models
{
    public class GenericTabela : ITabelas
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
