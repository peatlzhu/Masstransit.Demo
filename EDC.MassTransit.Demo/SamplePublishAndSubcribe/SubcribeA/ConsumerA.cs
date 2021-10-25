/**************************************************************************
*
*   =================================
*   CLR版本     ：4.0.30319.42000
*   命名空间    ：SubcribeA
*   文件名称    ：ConsumA
*   =================================
*   创 建 者     ：朱登高
*   创建日期    ：2021/10/25 14:37:12
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
using Messages;

namespace SubcribeA
{
    public class ConsumerA : IConsumer<TestBaseMessage>
    {
        public async Task Consume(ConsumeContext<TestBaseMessage> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"SubscriberA => ConsumerA received message : {context.Message.Name}, {context.Message.Time}, {context.Message.Message}, Type:{context.Message.GetType()}");
            Console.ResetColor();
        }
    }
}
