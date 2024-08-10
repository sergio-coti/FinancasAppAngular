using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Settings
{
    /// <summary>
    /// Parametros para conexão com o servidor do RabbitMQ
    /// </summary>
    public class RabbitMQSettings
    {
        public static string Hostname => "woodpecker.rmq.cloudamqp.com";
        public static int Port => 5672;
        public static string Username => "oiramqcw";
        public static string Password => "60niUEorJzvaVL6sbHlyTc1Xepy38QH2";
        public static string Queue => "oiramqcw";
    }
}
