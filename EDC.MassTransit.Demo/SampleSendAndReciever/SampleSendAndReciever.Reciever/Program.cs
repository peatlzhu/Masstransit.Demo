using System;
using FirstDemo.EVENTS;
using MassTransit;

namespace FirstDemoReciever
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit Server";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.0.148"), hst =>
                {
                    hst.Username("mdsd");
                    hst.Password("mdsd@2021");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTest", e =>
                {
                    e.Consumer<TestConsumerClient>();
                    e.Consumer<TestConsumerAgent>();
                });
            });

            bus.Start();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
