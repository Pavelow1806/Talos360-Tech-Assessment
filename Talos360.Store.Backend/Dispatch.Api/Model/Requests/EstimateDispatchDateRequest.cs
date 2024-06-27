using System;
using System.Collections.Generic;

namespace Dispatch.Api.Model.Requests
{
    public class EstimateDispatchDateRequest
    {
        public List<int> ProductIds { get; set; } = new List<int>();
        public DateTimeOffset OrderDate { get; set; }
    }
}
