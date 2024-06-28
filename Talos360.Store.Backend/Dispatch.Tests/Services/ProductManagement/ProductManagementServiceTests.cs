using Dispatch.Api.Services.ProductManagement;
using Dispatch.Data;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Dispatch.Tests.Services
{
    public class ProductManagementServiceTests : ProductManagementServiceTestingBase
    {
        [Fact]
        public void GetProductReturnsProductIfAvailable()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 }
            };
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetProduct(expected.First().ProductId);

            // Assert
            result.ProductId.ShouldBe(expected.First().ProductId);
        }
        [Fact]
        public void GetProductWithWrongProductIdReturnsNull()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 }
            };
            var invalidProductId = 2;
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetProduct(invalidProductId);

            // Assert
            result.ShouldBeNull();
        }
        [Fact]
        public void GetProductsReturnsArrayOfProducts()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 },
                new Product { ProductId = 2, Name = "Test Product 2", SupplierId = 2 }
            };
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetProducts();

            // Assert
            result.Count.ShouldBe(expected.Count);
        }
        [Fact]
        public void GetProductsWithProductIdsReturnsFilteredArrayOfProducts()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 },
                new Product { ProductId = 2, Name = "Test Product 2", SupplierId = 2 },
                new Product { ProductId = 3, Name = "Test Product 3", SupplierId = 3 }
            };
            var productIds = new List<int> { 1, 2 };
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetProducts(productIds);

            // Assert
            result.Count.ShouldBe(2);
            result.ShouldContain(expected[0]);
            result.ShouldContain(expected[1]);
            result.ShouldNotContain(expected[2]);
        }
        [Fact]
        public void GetProductsWithProductIdsReturnsEmnptyArrayWhenProductIdsNotFound()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 },
                new Product { ProductId = 2, Name = "Test Product 2", SupplierId = 2 },
                new Product { ProductId = 3, Name = "Test Product 3", SupplierId = 3 }
            };
            var productIds = new List<int> { 4, 5 };
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetProducts(productIds);

            // Assert
            result.Count.ShouldBe(0);
        }
        [Fact]
        public void GetUniqueSupplierIdsReturnsSupplierId()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 }
            };
            var productIds = new List<int> { 1 };
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetUniqueSupplierIds(productIds);

            // Assert
            result.Count.ShouldBe(1);
            result.ShouldContain(expected[0].SupplierId);
        }
        [Fact]
        public void GetUniqueSupplierIdsReturnsFilteredSupplierId()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 },
                new Product { ProductId = 2, Name = "Test Product 2", SupplierId = 2 },
            };
            var productIds = new List<int> { 1 };
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetUniqueSupplierIds(productIds);

            // Assert
            result.Count.ShouldBe(1);
            result.ShouldContain(expected[0].SupplierId);
        }
        [Fact]
        public void GetUniqueSupplierIdsReturnsUniqueFilteredSupplierIds()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 },
                new Product { ProductId = 2, Name = "Test Product 2", SupplierId = 2 },
                new Product { ProductId = 3, Name = "Test Product 3", SupplierId = 2 },
                new Product { ProductId = 4, Name = "Test Product 4", SupplierId = 1 },
            };
            var productIds = new List<int> { 1 };
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetUniqueSupplierIds(productIds);

            // Assert
            result.Count.ShouldBe(1);
            result.ShouldContain(expected[0].SupplierId);
        }
        [Fact]
        public void GetUniqueSupplierIdsReturnsEmptyListWhenProductIdNotFound()
        {
            // Arrange
            var expected = new List<Product>
            {
                new Product { ProductId = 1, Name = "Test Product 1", SupplierId = 1 }
            };
            var productIds = new List<int> { 2 };
            _mockDbContext.Setup(db => db.Products)
                .Returns(expected.AsQueryable());
            var service = new ProductManagementService(_mockDbContext.Object);

            // Act
            var result = service.GetUniqueSupplierIds(productIds);

            // Assert
            result.Count.ShouldBe(0);
        }
    }
}
