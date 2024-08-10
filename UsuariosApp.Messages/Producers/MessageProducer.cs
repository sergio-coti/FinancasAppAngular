using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Messages.Connections;
using UsuariosApp.Messages.Settings;

namespace UsuariosApp.Messages.Producers
{
    /// <summary>
    /// Classe para gravar conteúdo na fila
    /// </summary>
    public class MessageProducer
    {
        /// <summary>
        /// Método para adicionar uma mensagem na fila
        /// </summary>
        public void AddMessage(string message)
        {
            var connection = new RabbitMQConnection(); //conectando no servidor
            var queue = connection.GetQueue(); //acessando a fila

            //gravando a mensagem
            queue.BasicPublish(
                exchange: string.Empty,
                routingKey: RabbitMQSettings.Queue,
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(message),
                mandatory: false
                );
        }
    }
}
