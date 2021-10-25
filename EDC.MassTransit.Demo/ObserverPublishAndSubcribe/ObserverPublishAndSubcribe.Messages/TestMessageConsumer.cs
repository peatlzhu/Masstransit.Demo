using System;
using System.Threading.Tasks;
using MassTransit;

namespace ObserverPublishAndSubcribe.Messages
{
    public class TestMessageConsumer : IConsumer<TestMessage>
    {
        public async Task Consume(ConsumeContext<TestMessage> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"TestMessageConsumer => Type:{context.Message.GetType()}, ID:{context.Message.MessageId}, Content:{context.Message.Content}");
            Console.ResetColor();
        }
    }
}
