using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Settings
{
    /// <summary>
    /// Parametros para conexão com o servidor do Outlook
    /// </summary>
    public class MailSettings
    {
        public static string Email => "sergiojavaarq@outlook.com";
        public static string Senha => "@Admin12345";
        public static string Smtp => "smtp-mail.outlook.com";
        public static int Port => 587;
    }
}
