using NOVOROV.Models;

namespace NOVOROV.ViewModels
{
    public class PerdasAndPassivosViewModel
    {
        public Perda Perda { get; set; }
        public Passivo Passivo { get; set; }
        public ICollection<Passivo> Passivos { get; set; }
    }
}
