using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NOVOROV.Models;
using System.Net;

namespace NOVOROV.Controllers
{
    public class BaseController : Controller
    {
        public void Notify(string message, string title = "Atenção!",
        Notification notificationType = Notification.warning)
        {
            var msg = new
            {
                message,
                title,
                icon = notificationType.ToString(),
                type = notificationType.ToString(),
                provider = ""
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        public List<string> GetIpAndHostname()
        {
            List<string> IpHostname = new List<string>();
            string nomeMaquina = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostAddresses(nomeMaquina);
            var listaIps = new List<string> { };
            try
            {
                for (int i = 0; i < ip.Length; i++)
                {
                    string elementoDaIpAdress = ip[i].ToString();
                    if (!elementoDaIpAdress.Contains(':'))
                    {
                        listaIps.Add(elementoDaIpAdress);
                    }
                }
            }
            catch(Exception ex)
            {

            }


            IpHostname.Add(listaIps[0]);
            IpHostname.Add(nomeMaquina);

            return IpHostname;
        }
    }
}
