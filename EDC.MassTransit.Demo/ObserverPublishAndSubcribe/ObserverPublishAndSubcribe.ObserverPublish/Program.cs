using ObserverPublishAndSubcribe.Messages;
using System;
using System.Text;
using System.Threading.Tasks;
using MassTransit;

namespace ObserverPublishAndSubcribe.ObserverPublish
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Masstransit Observer Publisher";

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://192.168.0.148"), hst =>
                {
                    hst.Username("mdsd");
                    hst.Password("mdsd@2021");
                });
            });

            var observer1 = new SendObserver();
            var handle1 = bus.ConnectSendObserver(observer1);

            var observer2 = new PublishObserver();
            var handle2 = bus.ConnectPublishObserver(observer2);

            bus.Start();

            do
            {
                Console.WriteLine("Presss q if you want to exit this program.");
                string message = Console.ReadLine();
                if (message.ToLower().Equals("q"))
                {
                    break;
                }

                bus.Publish(new TestMessage
                {
                    MessageId = 10001,
                    Content = message,
                    Time = DateTime.Now
                });
            } while (true);

            bus.Stop();
        }
    }
}
