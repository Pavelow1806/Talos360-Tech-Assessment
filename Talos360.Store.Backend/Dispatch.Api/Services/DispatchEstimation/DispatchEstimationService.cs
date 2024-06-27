using Dispatch.Api.Extensions;
using Dispatch.Api.Model.Responses;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Api.Services.SupplierManagement;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatch.Api.Services.DispatchEstimation
{
    public class DispatchEstimationService : IDispatchEstimationService
    {
        public readonly IProductManagementService _productManagement;
        private readonly ISupplierManagementService _supplierManagement;
        public DispatchEstimationService(IProductManagementService productManagement, ISupplierManagementService supplierManagement)
        {
            _productManagement = productManagement;
            _supplierManagement = supplierManagement;
        }
        public async Task<DispatchDateResponse> EstimateDispatchDate(List<int> productIds, DateTimeOffset orderDate, CancellationToken cancellationToken)
        {
            var maxLeadDays = await FindMaxLeadTime(productIds, cancellationToken);
            var maxLeadTime = orderDate.AddDays(maxLeadDays);
            return new DispatchDateResponse { Date = maxLeadTime.AvoidWeekend() };
        }
        private async Task<int> FindMaxLeadTime(List<int> productIds, CancellationToken cancellationToken)
        {
            DateTimeOffset result;
            var uniqueSupplierIds = await _productManagement.GetUniqueSupplierIds(productIds, cancellationToken);
            return await _supplierManagement.FindMaxLeadTime(uniqueSupplierIds, cancellationToken);
        }
    }
}
