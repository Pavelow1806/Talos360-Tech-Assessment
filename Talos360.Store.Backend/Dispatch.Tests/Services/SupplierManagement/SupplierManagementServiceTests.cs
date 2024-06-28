using Dispatch.Api.Services.ProductManagement;
using Dispatch.Api.Services.SupplierManagement;
using Dispatch.Data;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Dispatch.Tests.Services.SupplierManagement
{
    public class SupplierManagementServiceTests : SupplierManagementServiceTestingBase
    {
        [Fact]
        public void GetSuppliersReturnsListOfSuppliers()
        {
            // Arrange
            var expected = new List<Supplier>
            {
                new Supplier { SupplierId = 1, Name = "Test Supplier 1", LeadTime = 1 }
            };
            _mockDbContext.Setup(db => db.Suppliers)
                .Returns(expected.AsQueryable());
            var service = new SupplierManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetSuppliers();

            // Assert
            result.Count.ShouldBe(expected.Count);
        }
        [Fact]
        public void FindMaxLeadTimeReturnsMaxLeadTimeForSupplierWithIdProvided()
        {
            // Arrange
            var expected = new List<Supplier>
            {
                new Supplier { SupplierId = 1, Name = "Test Supplier 1", LeadTime = 1 }
            };
            var supplierIds = new List<int> { 1 };
            _mockDbContext.Setup(db => db.Suppliers)
                .Returns(expected.AsQueryable());
            var service = new SupplierManagementService(_mockDbContext.Object);

            // Act
            var result = service.FindMaxLeadTime(supplierIds);

            // Assert
            result.ShouldBe(expected[0].LeadTime);
        }
        [Fact]
        public void FindMaxLeadTimeReturnsMaxLeadTimeForSuppliersWithIdsProvided()
        {
            // Arrange
            var expected = new List<Supplier>
            {
                new Supplier { SupplierId = 1, Name = "Test Supplier 1", LeadTime = 1 },
                new Supplier { SupplierId = 2, Name = "Test Supplier 2", LeadTime = 2 },
                new Supplier { SupplierId = 3, Name = "Test Supplier 3", LeadTime = 3 },
                new Supplier { SupplierId = 4, Name = "Test Supplier 4", LeadTime = 1 },
            };
            var expectedLeadTime = expected.Max(d => d.LeadTime);
            var supplierIds = new List<int> { 1, 2, 3, 4 };
            _mockDbContext.Setup(db => db.Suppliers)
                .Returns(expected.AsQueryable());
            var service = new SupplierManagementService(_mockDbContext.Object);

            // Act
            var result = service.FindMaxLeadTime(supplierIds);

            // Assert
            result.ShouldBe(expectedLeadTime);
        }
    }
}
