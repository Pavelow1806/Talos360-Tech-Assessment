namespace Dispatch.Tests.Controllers.DispatchDateController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Api.Controllers;
    using Shouldly;
    using Xunit;

    public class DispatchTests : DispatchTestingBase
    {
        public DispatchTests() : base() { }

        [Theory(DisplayName = "Lead time added to dispatch date")]
        [InlineData(new[] { 1 }, 2024, 1, 1, 2024, 1, 2)]
        [InlineData(new[] { 2 }, 2024, 1, 1, 2024, 1, 3)]
        public void LeadTimeAddedToDispatchDate(int[] leadTimes, int orderYear, int orderMonth, int orderDay, int expectedYear, int expectedMonth, int expectedDay)
        {
            // Arrange
            var data = leadTimes
                .Select(lt => GenerateProductAndSupplierWithLeadTime(1, 1, lt));
            var productIds = data
                .Select(d => d.product.ProductId)
                .ToList();
            var uniqueSupplierIds = data
                .Select(d => d.product.SupplierId)
                .Distinct()
                .ToList();
            var orderDate = new DateTimeOffset(orderYear, orderMonth, orderDay, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = new DateTimeOffset(expectedYear, expectedMonth, expectedDay, 0, 0, 0, TimeSpan.Zero);
            _mockProductManagement
                .Setup(pm => pm.GetUniqueSupplierIds(productIds))
                .Returns(uniqueSupplierIds);
            _mockSupplierManagement
                .Setup(sm => sm.FindMaxLeadTime(uniqueSupplierIds))
                .Returns(leadTimes.Max());
            var controller = new DispatchDateController(_dispatchEstimation);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }
        [Theory(DisplayName = "Supplier with longest lead time is used for calculation")]
        [InlineData(new[] { 1, 2 }, 2024, 1, 1, 2024, 1, 3)]
        public void SupplierWithLongestLeadTimeIsUsedForCalculation(int[] leadTimes, int orderYear, int orderMonth, int orderDay, int expectedYear, int expectedMonth, int expectedDay)
        {
            // Arrange
            var data = leadTimes
                .Select(lt => GenerateProductAndSupplierWithLeadTime(1, 1, lt));
            var productIds = data
                .Select(d => d.product.ProductId)
                .ToList();
            var uniqueSupplierIds = data
                .Select(d => d.product.SupplierId)
                .Distinct()
                .ToList();
            var orderDate = new DateTimeOffset(orderYear, orderMonth, orderDay, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = new DateTimeOffset(expectedYear, expectedMonth, expectedDay, 0, 0, 0, TimeSpan.Zero);
            _mockProductManagement
                .Setup(pm => pm.GetUniqueSupplierIds(productIds))
                .Returns(uniqueSupplierIds);
            _mockSupplierManagement
                .Setup(sm => sm.FindMaxLeadTime(uniqueSupplierIds))
                .Returns(leadTimes.Max());
            var controller = new DispatchDateController(_dispatchEstimation);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }
        [Theory(DisplayName = "Lead time is not counted over a weekend")]
        [InlineData(new[] { 1 }, 2024, 1, 5, 2024, 1, 8)]
        [InlineData(new[] { 1 }, 2024, 1, 6, 2024, 1, 9)]
        [InlineData(new[] { 1 }, 2024, 1, 7, 2024, 1, 9)]
        public void LeadTimeIsNotCountedOverAWeekend(int[] leadTimes, int orderYear, int orderMonth, int orderDay, int expectedYear, int expectedMonth, int expectedDay)
        {
            // Arrange
            var data = leadTimes
                .Select(lt => GenerateProductAndSupplierWithLeadTime(1, 1, lt));
            var productIds = data
                .Select(d => d.product.ProductId)
                .ToList();
            var uniqueSupplierIds = data
                .Select(d => d.product.SupplierId)
                .Distinct()
                .ToList();
            var orderDate = new DateTimeOffset(orderYear, orderMonth, orderDay, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = new DateTimeOffset(expectedYear, expectedMonth, expectedDay, 0, 0, 0, TimeSpan.Zero);
            _mockProductManagement
                .Setup(pm => pm.GetUniqueSupplierIds(productIds))
                .Returns(uniqueSupplierIds);
            _mockSupplierManagement
                .Setup(sm => sm.FindMaxLeadTime(uniqueSupplierIds))
                .Returns(leadTimes.Max());
            var controller = new DispatchDateController(_dispatchEstimation);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }
        [Theory(DisplayName = "Lead time is not counted over a weekend")]
        [InlineData(new[] { 6 }, 2024, 1, 5, 2024, 1, 15)]
        [InlineData(new[] { 11 }, 2024, 1, 5, 2024, 1, 22)]
        public void LeadTimeOverMultipleWeeks(int[] leadTimes, int orderYear, int orderMonth, int orderDay, int expectedYear, int expectedMonth, int expectedDay)
        {
            // Arrange
            var data = leadTimes
                .Select(lt => GenerateProductAndSupplierWithLeadTime(1, 1, lt));
            var productIds = data
                .Select(d => d.product.ProductId)
                .ToList();
            var uniqueSupplierIds = data
                .Select(d => d.product.SupplierId)
                .Distinct()
                .ToList();
            var orderDate = new DateTimeOffset(orderYear, orderMonth, orderDay, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = new DateTimeOffset(expectedYear, expectedMonth, expectedDay, 0, 0, 0, TimeSpan.Zero);
            _mockProductManagement
                .Setup(pm => pm.GetUniqueSupplierIds(productIds))
                .Returns(uniqueSupplierIds);
            _mockSupplierManagement
                .Setup(sm => sm.FindMaxLeadTime(uniqueSupplierIds))
                .Returns(leadTimes.Max());
            var controller = new DispatchDateController(_dispatchEstimation);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }
    }
}
