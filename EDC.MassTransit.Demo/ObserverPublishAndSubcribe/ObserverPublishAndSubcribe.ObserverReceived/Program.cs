using System;
using MassTransit;
using ObserverPublishAndSubcribe.Messages;

namespace ObserverPublishAndSubcribe.ObserverReceived
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Masstransit Observer Receiver";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.0.148"), hst =>
                {
                    hst.Username("mdsd");
                    hst.Password("mdsd@2021");
                });

                cfg.ReceiveEndpoint(host, "Qka.MassTransitTestv4", e =>
                {
                    e.Consumer<TestMessageConsumer>();
                });
            });

            var observer = new ReceiveObserver();
            var handle = bus.ConnectReceiveObserver(observer);

            bus.Start();
            Console.ReadKey();
            bus.Stop();
        }
    }
}
