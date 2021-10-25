/**************************************************************************
*
*   =================================
*   CLR版本     ：4.0.30319.42000
*   命名空间    ：ObserverPublishAndSubcribe.Messages
*   文件名称    ：Observer
*   =================================
*   创 建 者     ：朱登高
*   创建日期    ：2021/10/25 16:04:32
*   邮箱           ：40970433@qq.com
*   个人主站    ：
*   功能描述    ：
*   使用说明    ：
*   =================================
*   修改者       ：
*   修改日期    ：
*   修改内容    ：
*   =================================
*
***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;

namespace ObserverPublishAndSubcribe.Messages
{
    public class PublishObserver : IPublishObserver
    {
        public Task PrePublish<T>(PublishContext<T> context) where T : class
        {
            Console.WriteLine("------------------PrePublish--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("----------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task PostPublish<T>(PublishContext<T> context) where T : class
        {
            Console.WriteLine("------------------PostPublish--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("----------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task PublishFault<T>(PublishContext<T> context, Exception exception) where T : class
        {
            Console.WriteLine("------------------PublishFault--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("------------------------------------------------------");

            return Task.CompletedTask;
        }
    }

    public class SendObserver : ISendObserver
    {
        public Task PreSend<T>(SendContext<T> context) where T : class
        {
            Console.WriteLine("------------------PreSend--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("-------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task PostSend<T>(SendContext<T> context) where T : class
        {
            Console.WriteLine("------------------PostSend-------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("-------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task SendFault<T>(SendContext<T> context, Exception exception) where T : class
        {
            Console.WriteLine("------------------SendFault-----------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("-------------------------------------------------");

            return Task.CompletedTask;
        }
    }

    public class ReceiveObserver : IReceiveObserver
    {
        public Task PreReceive(ReceiveContext context)
        {
            Console.WriteLine("------------------PreReceive--------------------");
            Console.WriteLine(Encoding.Default.GetString(context.GetBody()));
            Console.WriteLine("--------------------------------------");

            return Task.CompletedTask;
        }

        public Task PostReceive(ReceiveContext context)
        {
            Console.WriteLine("------------------PostReceive--------------------");
            Console.WriteLine(Encoding.Default.GetString(context.GetBody()));
            Console.WriteLine("------------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task ReceiveFault(ReceiveContext context, Exception exception)
        {
            Console.WriteLine("------------------ReceiveFault--------------------");
            Console.WriteLine(Encoding.Default.GetString(context.GetBody()));
            Console.WriteLine("-------------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task PostConsume<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType) where T : class
        {
            Console.WriteLine("------------------PostConsume--------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("--------------------------------------------------------");

            return Task.CompletedTask;
        }

        public Task ConsumeFault<T>(ConsumeContext<T> context, TimeSpan duration, string consumerType, Exception exception) where T : class
        {
            Console.WriteLine("------------------ConsumeFault-------------------");
            var message = context.Message as TestMessage;
            Console.WriteLine($"ID={message.MessageId}, Content={message.Content},Time={message.Time}");
            Console.WriteLine("--------------------------------------------------------");

            return Task.CompletedTask;
        }
    }
}
