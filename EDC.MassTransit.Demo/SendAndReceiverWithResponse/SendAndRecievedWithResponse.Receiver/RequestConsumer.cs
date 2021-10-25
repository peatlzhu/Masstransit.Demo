/**************************************************************************
*
*   =================================
*   CLR版本     ：4.0.30319.42000
*   命名空间    ：SendAndReceiverWithResponse.Messages
*   文件名称    ：RequestConsumer
*   =================================
*   创 建 者     ：朱登高
*   创建日期    ：2021/10/25 15:30:52
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

using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SendAndReceiverWithResponse.Messages;

namespace SendAndReceiverWithResponse.Receiver
{
    public class RequestConsumer : IConsumer<IRequestMessage>
    {
        public async Task Consume(ConsumeContext<IRequestMessage> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"Received message: Id={context.Message.MessageId}, Content={context.Message.Content}");
            Console.ResetColor();

            var response = new ResponseMessage
            {
                MessageCode = 200,
                Content = $"Success",
                RequestId = context.Message.MessageId
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Response message: Code={response.MessageCode}, Content={response.Content}, RequestId={response.RequestId}");
            Console.ResetColor();
            await context.RespondAsync(response);
        }
    }
}
