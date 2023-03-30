using Core.Async.Message;
using Core.Async.RabbitMQ.Publisher.Abstract;
using RabbitMQ.Client;
using System.Text;

namespace Core.Async.RabbitMQ.Publisher
{
    public class MailPublisher : IMailPublisher
    {
        public void Publish(string mail)
        {
            ConnectionFactory factory = new()
            {
                Uri = new("X")
            };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();
            channel.QueueDeclare(queue: "yusuf", exclusive: false, durable: true);
            IMessage message = new ExampleMessage { Mail = mail };
            byte[] byteMessage = Encoding.UTF8.GetBytes(message.Mail);
            channel.BasicPublish(exchange: string.Empty, routingKey: "yusuf", body: byteMessage);
        }
    }
}
