using NOVOROV.Models;

namespace NOVOROV.Services.Interfaces
{
    public interface IEmailService
    {
        public void SendEmail(string subject, List<string> recipients, string attachPath);
    }
}
