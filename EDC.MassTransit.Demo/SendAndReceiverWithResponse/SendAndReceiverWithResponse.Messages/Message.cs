using System;

namespace SendAndReceiverWithResponse.Messages
{
    public interface IRequestMessage
    {
        int MessageId { get; set; }
        string Content { get; set; }
    }

    public class RequestMessage : IRequestMessage
    {
        public int MessageId { get; set; }
        public string Content { get; set; }

        public int RequestId { get; set; }
    }

    public interface IResponseMessage
    {
        int MessageCode { get; set; }
        string Content { get; set; }
    }

    public class ResponseMessage : IResponseMessage
    {
        public int MessageCode { get; set; }
        public string Content { get; set; }

        public int RequestId { get; set; }
    }
}
