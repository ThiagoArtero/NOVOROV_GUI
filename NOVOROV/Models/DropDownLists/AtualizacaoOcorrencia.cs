using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models.DropDownLists
{
    public class AtualizacaoOcorrencia
    {
        public int Id { get; set; }

        [DisplayName("Data Solicitação")]
        public DateTime DataSolicitacao { get; set; }

        [DisplayName("Data Conclusão")]
        public DateTime DataConclusao { get; set; }

        public int InformanteId { get; set; }

        public int MotivoId { get; set; }
        public Motivo Motivo { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nome Formulário")]
        public string NomeFormulario { get; set; }

        [DisplayName("Status Prioridade")]
        public bool StatusPrioridade { get; set; }

        [DisplayName("Status Atualizacao")]
        public bool StatusAtualizacao { get; set; }

        [DisplayName("Descricao História")]
        public string DescricaoHistoria { get; set; }

        [DisplayName("Descrição Atualização")]
        public string DescricaoAtualizacao { get; set; }

        [DisplayName("Numero Versão Ocorrência")]
        public int NumeroVersaoOcorrencia { get; set; }

    }
}
