using Dispatch.Api.Services.DispatchEstimation;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Api.Services.SupplierManagement;
using Dispatch.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dispatch.Tests
{
    public abstract class DispatchTestingBase
    {
        public IDbContext DbContext => new DbContext();
        public IProductManagementService ProductManagement => new ProductManagementService(DbContext);
        public ISupplierManagementService SupplierManagement => new SupplierManagementService(DbContext);
        public IDispatchEstimationService DispatchEstimation => new DispatchEstimationService(ProductManagement, SupplierManagement);
    }
}
