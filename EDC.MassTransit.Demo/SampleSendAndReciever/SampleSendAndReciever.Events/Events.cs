﻿using System;
using System.Threading.Tasks;
using MassTransit;

namespace FirstDemo.EVENTS
{
    public class TestConsumerClient : IConsumer<Client>
    {
        public async Task Consume(ConsumeContext<Client> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"Receive message:{context.Message.Message}, {context.Message.Id}, {context.Message.Name}, {context.Message.Birthdate.ToString()}}}");
            Console.ResetColor();
        }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Message { get; set; }
    }

    public class TestConsumerAgent : IConsumer<Agent>
    {
        public async Task Consume(ConsumeContext<Agent> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"Receive message: {context.Message.AgentCode}, {context.Message.AgentName}, {context.Message.AgentRole}");
            Console.ResetColor();
        }
    }

    public class Agent
    {
        public int AgentCode { get; set; }
        public string AgentName { get; set; }
        public string AgentRole { get; set; }
        public string Message { get; set; }
    }
}
