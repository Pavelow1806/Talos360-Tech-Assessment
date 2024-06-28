using Dispatch.Api.Services.DispatchEstimation;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Api.Services.SupplierManagement;
using Dispatch.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dispatch.Tests.Controllers.DispatchDateController
{
    public abstract class DispatchTestingBase
    {
        internal readonly Mock<IProductManagementService> _mockProductManagement = new Mock<IProductManagementService>();
        internal readonly Mock<ISupplierManagementService> _mockSupplierManagement = new Mock<ISupplierManagementService>();
        internal readonly IDispatchEstimationService _dispatchEstimation;

        public DispatchTestingBase()
        {
            _dispatchEstimation = new DispatchEstimationService(_mockProductManagement.Object, _mockSupplierManagement.Object);
        }

        internal (Product product, Supplier supplier) GenerateProductAndSupplierWithLeadTime(int productId, int supplierId, int leadTime)
        {
            var product = new Product
            {
                ProductId = productId,
                Name = "Test Product",
                SupplierId = supplierId,
            };
            var supplier = new Supplier
            {
                SupplierId = supplierId,
                LeadTime = leadTime,
                Name = "Test Supplier",
            };
            return (product, supplier);
        }
    }
}
