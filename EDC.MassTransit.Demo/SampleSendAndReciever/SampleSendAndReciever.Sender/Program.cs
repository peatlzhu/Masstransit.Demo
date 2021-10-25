using System;
using System.Threading.Tasks;
using FirstDemo.EVENTS;
using MassTransit;

namespace FirstDemo
{
   public class Program
    {
       public static void Main(string[] args)
        {
            Console.Title = "MassTransit Client";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.0.148"), hst =>
                {
                    hst.Username("mdsd");
                    hst.Password("mdsd@2021");
                });
            });

            var uri = new Uri("rabbitmq://192.168.0.148/Qka.MassTransitTest");
            var message = Console.ReadLine();

            while (message != null)
            {
                Task.Run(() => SendCommand(bus, uri, message)).Wait();
                message = Console.ReadLine();
            }

            Console.ReadKey();
        }

        private static async void SendCommand(IBusControl bus, Uri sendToUri, string message)
        {
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            var command = new Client()
            {
                Id = 100001,
                Name = "Edison Zhou",
                Birthdate = DateTime.Now.AddYears(-18),
                Message = message
            };

            await endPoint.Send(command);

            Console.WriteLine($"You Sended : Id = {command.Id}, Name = {command.Name}, Message = {command.Message}");
        }
    }
}
