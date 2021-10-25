using MassTransit;
using System;

namespace SubcribeA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "MassTransit SubscriberA";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.0.148"), hst =>
                {
                    hst.Username("mdsd");
                    hst.Password("mdsd@2021");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTestv2.CA", e => { e.Consumer<ConsumerA>(); });
            });

            bus.Start();
            Console.ReadKey(); // press Enter to Stop
            bus.Stop();
        }
    }
}
