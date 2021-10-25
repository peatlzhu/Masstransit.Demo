using System;
using MassTransit;

namespace SubcriberB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit SubscriberB";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.0.148"), hst =>
                {
                    hst.Username("mdsd");
                    hst.Password("mdsd@2021");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTestv2.CB", e =>
                {
                    e.Consumer<ConsumerA>();
                });
            });

            bus.Start();
            Console.ReadKey(); // press Enter to Stop
            bus.Stop();
        }
    }
}
