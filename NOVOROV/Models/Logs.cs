using System.ComponentModel;

namespace NOVOROV.Models
{
    public class Logs
    {
        public string Message { get; set; }
        public string Level { get; set; }

        [DisplayName("Data Alteração")]
        public string TimeStamp { get; set; }
        public string Properties { get; set; }

        [DisplayName("Ação")]
        public string Acao { get; set; }
        [DisplayName("Usuário Operador")]
        public string UsuarioOperador { get; set; }

        [DisplayName("IP Operador")]
        public string IpOperador { get; set; }
        [DisplayName("Hostname")]
        public string Hostname { get; set; }
        [DisplayName("Conteúdo Anterior")]
        public string ConteudoAnterior { get; set; }
        [DisplayName("Conteúdo Atual")]
        public string ConteudoAtual { get; set; }
        [DisplayName("Campo")]
        public string Campo { get; set; }

        [DisplayName("ROV")]
        public string ROV { get; set; }
    }
}
