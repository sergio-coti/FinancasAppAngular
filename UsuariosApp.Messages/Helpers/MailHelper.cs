using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Messages.Settings;

namespace UsuariosApp.Messages.Helpers
{
    /// <summary>
    /// Classe para envio de emails em .NET
    /// </summary>
    public class MailHelper
    {
        public void SendMail(string mailTo, string subject, string body)
        {
            #region Construindo a mensagem

            var mailMessage = new MailMessage(MailSettings.Email, mailTo);
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            #endregion

            #region Enviando a mensagem

            var smtpClient = new SmtpClient(MailSettings.Smtp, MailSettings.Port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(MailSettings.Email, MailSettings.Senha);
            smtpClient.Send(mailMessage);

            #endregion
        }
    }
}
