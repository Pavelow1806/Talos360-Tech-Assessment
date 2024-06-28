namespace Dispatch.Api.Model.Responses
{
    using System;

    public class DispatchDateResponse : ResponseBase
    {
        public DateTimeOffset EstimatedDispatchDate { get; set; }
    }
}