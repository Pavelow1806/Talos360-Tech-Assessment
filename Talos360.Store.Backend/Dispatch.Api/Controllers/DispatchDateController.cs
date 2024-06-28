namespace Dispatch.Api.Controllers
{
    using Dispatch.Api.Model.Requests;
    using Dispatch.Api.Model.Responses;
    using Dispatch.Api.Services.DispatchEstimation;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    public class DispatchDateController : Controller
    {
        private readonly IDispatchEstimationService _dispatchEestimation;
        public DispatchDateController(IDispatchEstimationService dispatchEstimation)
        {
            _dispatchEestimation = dispatchEstimation;
        }
        [HttpGet]
        public DispatchDateResponse Get(List<int> productIds, DateTime orderDate)
        {
            if (productIds == null || productIds.Count() == 0)
                return new DispatchDateResponse { Success = false, Message = "Invalid request, please ensure an array of Product Ids is provided." };
            return _dispatchEestimation.EstimateDispatchDate(productIds, orderDate);
        }
    }
}
