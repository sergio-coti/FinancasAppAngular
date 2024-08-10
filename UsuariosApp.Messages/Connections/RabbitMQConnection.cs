using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Messages.Settings;

namespace UsuariosApp.Messages.Connections
{
    /// <summary>
    /// Classe para conexão com o servidor da mensageria
    /// </summary>
    public class RabbitMQConnection
    {
        #region Atributos

        private IConnectionFactory? _connectionFactory;
        private IConnection? _connection;
        private IModel? _model;

        #endregion

        #region Método construtor

        public RabbitMQConnection()
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = RabbitMQSettings.Hostname,
                Port = RabbitMQSettings.Port,
                UserName = RabbitMQSettings.Username,
                Password = RabbitMQSettings.Password,
                VirtualHost = RabbitMQSettings.Username
            };

            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
        }

        #endregion

        #region Acessar a fila da mensageria

        public IModel GetQueue()
        {
            _model.QueueDeclare(
                    queue: RabbitMQSettings.Queue, //nome da fila
                    durable: true, //fila permanece mesmo após parar o servidor do amqp
                    exclusive: false, //fila possa ser acessada por outros projetos
                    autoDelete: false, //não exclui mensagens de forma automática
                    arguments: null //nenhum argumento adicional
                );

            return _model;
        }

        #endregion
    }
}
