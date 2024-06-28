using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Dispatch.Api.Model.Responses;
using System.Threading;

namespace Dispatch.Api.Services.DispatchEstimation
{
    public interface IDispatchEstimationService
    {
        DispatchDateResponse EstimateDispatchDate(List<int> productIds, DateTime orderDate);
    }
}
