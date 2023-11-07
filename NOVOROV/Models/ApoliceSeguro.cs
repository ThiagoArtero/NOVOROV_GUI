using NOVOROV.Models.DropDownLists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NOVOROV.Models
{
    public class ApoliceSeguro
    {
        public int Id { get; set; }
        public int? TipoApoliceSeguroId { get; set; }
        public TipoApoliceSeguro? TipoApoliceSeguro { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string DescricaoApoliceSeguro { get; set; }

        [DisplayName("Valor Apolice Seguro")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorApoliceSeguro { get; set; }

        public int TipoSiteId { get; set; }
        public TipoSite TipoSite { get; set; }

        public int TipoOcorrenciaId { get; set; }
        public TipoOcorrencia TipoOcorrencia { get; set; }


    }
}
