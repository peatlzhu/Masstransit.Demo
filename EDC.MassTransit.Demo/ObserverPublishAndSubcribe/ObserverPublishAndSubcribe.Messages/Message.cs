/**************************************************************************
*
*   =================================
*   CLR版本     ：4.0.30319.42000
*   命名空间    ：ObserverPublishAndSubcribe.Messages
*   文件名称    ：Message
*   =================================
*   创 建 者     ：朱登高
*   创建日期    ：2021/10/25 16:00:58
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

namespace ObserverPublishAndSubcribe.Messages
{
   public class TestMessage
    {
        public int MessageId { get; set; }
        public string Content { get; set; }

        public DateTime Time { get; set; }
    }
}
