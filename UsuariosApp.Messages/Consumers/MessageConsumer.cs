using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Messages.Connections;
using UsuariosApp.Messages.Helpers;
using UsuariosApp.Messages.Models;
using UsuariosApp.Messages.Settings;

namespace UsuariosApp.Messages.Consumers
{
    /// <summary>
    /// Classe para ler e processar os itens da fila
    /// </summary>
    public class MessageConsumer : BackgroundService
    {
        private readonly IServiceProvider? _serviceProvider;

        public MessageConsumer(IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connection = new RabbitMQConnection();
            var queue = connection.GetQueue();

            //ler o conteúdo da fila
            var consumer = new EventingBasicConsumer(queue);
            consumer.Received += (sender, args) =>
            {
                //ler os dados do usuário contido na fila
                var content = Encoding.UTF8.GetString(args.Body.ToArray());
                var usuario = JsonConvert.DeserializeObject<UsuarioModel>(content);

                //escrevendo o conteúdo do email
                var mailTo = usuario.Email;
                var subject = "Seja bem vindo ao Sistema - COTI Informática!";
                var body = $"Olá, {usuario.Nome}\nSua conta foi criada com sucesso!\nAtt\nEquipe COTI Informática";

                //enviando o email
                using (var scope = _serviceProvider.CreateScope())
                {                    
                    var mailHelper = new MailHelper();
                    mailHelper.SendMail(mailTo, subject, body);
                }

                //retirando a mensagem da fila
                queue.BasicAck(args.DeliveryTag, false);
            };

            //finalizando o processo
            queue.BasicConsume(RabbitMQSettings.Queue, false, consumer);
            return Task.CompletedTask;
        }
    }
}
