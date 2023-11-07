using Newtonsoft.Json;

namespace NOVOROV.Models
{
    public class PrismaData
    {
        [JsonProperty("workorder")]
        public string NumeroOrdemServico { get; set; }

        [JsonProperty("incidentTypeFV")]
        public string TipoIncidente { get; set; }

        [JsonProperty("SiteTypeFV")]
        public string TipoSite { get; set; }

        [JsonProperty("S-008 - Sigla Site")]
        public string SiglaSite { get; set; }

        [JsonProperty("S-009 - Nome do Site")]
        public string NomeSite { get; set; }

        [JsonProperty("S-014 - Logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("S-012 - Municipio")]
        public string Municipio { get; set; }

        [JsonProperty("S-010 - UF")]
        public string UF { get; set; }

        [JsonProperty("S-017 - CEP")]
        public string CEP { get; set; }

        public bool HasReasonForNotReportingFV { get; set; }
        public string PoliceReportNumberFV { get; set; }
        public string PoliceReportUrlFV { get; set; }
        public string WorkOrderState { get; set; }

        [JsonProperty("WorkOrderStateName")]
        public string StatusOrdemServico { get; set; }
        public int? TotalAmount { get; set; }
        public DateTime EntityLastUpdateData { get; set; }
        public string Item { get; set; }
        public string ItemName { get; set; }
        public int? Quantity { get; set; }
        public float? UnitAmount { get; set; }
        public int? ATUALIZAR { get; set; }
    }
}
