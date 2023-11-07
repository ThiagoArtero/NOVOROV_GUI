using NOVOROV.Models;
using NOVOROV.Services.Interfaces;
using System.Diagnostics;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace NOVOROV.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string subject, List<string> recipients, string attachPath)
        {
            try
            {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;

                // Recipient
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                foreach (String recipient in recipients)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }

                //Add Subject
                oMailItem.Subject = subject;

                // body, bcc etc...
                oMailItem.Attachments.Add(attachPath, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);

                //Display the mailbox
                oMailItem.Display(true);
            }
            catch (Exception objEx)
            {
                Debug.WriteLine(objEx.ToString());
            }
        }
    }
}
