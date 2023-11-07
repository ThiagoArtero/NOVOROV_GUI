using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NOVOROV.Models.DropDownLists;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOVOROV.Models
{
    public class Site
    {
        public Site()
        {}
        public Site(int tipoSite, string nomeSite, string uf, string municipio, string endereco, string cep, int sistemaBluetooth, int sistemaRastreamento, int statusSite)
        {
            TipoSiteId = tipoSite;
            NomeSite = nomeSite;
            UF = uf;
            Municipio = municipio;
            Endereco = endereco;
            CEP = cep;
            SistemaFechaduraBluetoothId = sistemaBluetooth;
            SistemaRastreamentoId = sistemaRastreamento;
            StatusSiteId = statusSite; 
        }

        public int Id { get; set; }

        [DisplayName("Tipo Site")]
        public int? TipoSiteId { get; set; }
        public TipoSite? TipoSite { get; set; }


        [DisplayName("Nome Site")]
        [Column(TypeName = "varchar(100)")]
        public string NomeSite { get; set; }

        [DisplayName("UF")]
        [Column(TypeName = "varchar(2)")]
        public string UF { get; set; }

        [DisplayName("Município")]
        [Column(TypeName = "varchar(100)")]
        public string Municipio { get; set; }

        [DisplayName("Endereço")]
        [Column(TypeName = "varchar(100)")]
        public string? Endereco { get; set; }

        [DisplayName("CEP")]
        [Column(TypeName = "varchar(15)")]
        public string? CEP { get; set; }

        [DisplayName("Sistema Fechadura Bluetooth")]
        public int? SistemaFechaduraBluetoothId { get; set; }
        public SistemaFechaduraBluetooth? SistemaFechaduraBluetooth { get; set; }

        [DisplayName("Sistema Rastreamento")]
        public int? SistemaRastreamentoId { get; set; }
        public SistemaRastreamento? SistemaRastreamento { get; set; }

        [DisplayName("Status")]
        public int? StatusId { get; set; }
        public Status? Status { get; set; }

        [DisplayName("Status Site")]
        public int? StatusSiteId { get; set; }
        public StatusSite? StatusSite { get; set; }

    }
}
