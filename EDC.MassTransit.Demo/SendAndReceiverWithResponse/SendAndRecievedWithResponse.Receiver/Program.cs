using System;
using MassTransit;
using SendAndReceiverWithResponse.Messages;


namespace SendAndReceiverWithResponse.Receiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit Response Side";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.0.148"), hst =>
                {
                    hst.Username("mdsd");
                    hst.Password("mdsd@2021");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTestv3", e =>
                {
                    e.Consumer<RequestConsumer>();
                });
            });

            bus.Start();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
