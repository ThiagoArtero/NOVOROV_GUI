using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;

namespace NOVOROV.ViewModels
{
    public class ChamadoAndAtendimento
    {
        public Chamado Chamado { get; set; }

        public Atendimento Atendimento { get; set; }
        public ICollection<Atendimento> Atendimentos { get; set; }

        public ICollection<StatusAtendimentoChamado> StatusAtendimentoChamado { get; set; }

    }
}
