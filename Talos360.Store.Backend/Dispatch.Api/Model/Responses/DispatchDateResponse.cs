namespace Dispatch.Api.Model.Responses
{
    using System;

    public class DispatchDateResponse : ResponseBase
    {
        public DateTime EstimatedDispatchDate { get; set; }
    }
}