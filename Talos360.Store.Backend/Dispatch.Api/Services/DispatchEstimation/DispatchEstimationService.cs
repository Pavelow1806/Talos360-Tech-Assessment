﻿using Dispatch.Api.Extensions;
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
        private readonly IProductManagementService _productManagement;
        private readonly ISupplierManagementService _supplierManagement;
        public DispatchEstimationService(IProductManagementService productManagement, ISupplierManagementService supplierManagement)
        {
            _productManagement = productManagement;
            _supplierManagement = supplierManagement;
        }
        public DispatchDateResponse EstimateDispatchDate(List<int> productIds, DateTime orderDate)
        {
            var maxLeadDays = FindMaxLeadTime(productIds);
            var maxLeadTime = orderDate.AddWorkingDays(maxLeadDays);
            return new DispatchDateResponse { EstimatedDispatchDate = maxLeadTime };
        }
        private int FindMaxLeadTime(List<int> productIds)
        {
            DateTime result;
            var uniqueSupplierIds = _productManagement.GetUniqueSupplierIds(productIds);
            return _supplierManagement.FindMaxLeadTime(uniqueSupplierIds);
        }
    }
}
