namespace Dispatch.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;
    using Dispatch.Api.Model.Requests;
    using Dispatch.Api.Model.Responses;
    using Dispatch.Api.Services.DispatchEstimation;
    using Microsoft.AspNetCore.Mvc;
    using Model;

    [Route("api/[controller]")]
    public class DispatchDateController : Controller
    {
        private readonly IDispatchEstimationService _dispatchEestimation;
        public DispatchDateController(IDispatchEstimationService dispatchEstimation)
        {
            _dispatchEestimation = dispatchEstimation;
        }
        [HttpPost]
        public DispatchDateResponse Post([FromBody]EstimateDispatchDateRequest request)
        {
            if (request == null || request.ProductIds == null || request.ProductIds.Count == 0)
                return new DispatchDateResponse { Success = false, Message = "Invalid request, please ensure an array of Product Ids is provided." };
            return _dispatchEestimation.EstimateDispatchDate(request.ProductIds, request.OrderDate);
        }
    }
}
