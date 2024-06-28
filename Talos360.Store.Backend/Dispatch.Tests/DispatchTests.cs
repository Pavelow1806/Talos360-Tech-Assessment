namespace Dispatch.Tests
{
    using System;
    using System.Collections.Generic;
    using Api.Controllers;
    using Shouldly;
    using Xunit;

    public class DispatchTests: DispatchTestingBase
    {
        [Fact]
        public void OneProductWithLeadTimeOfOneDay()
        {
            // Arrange
            var controller = new DispatchDateController(DispatchEstimation);
            var productIds = new List<int>() { 1 };
            var orderDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = orderDate.AddDays(1);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }

        [Fact]
        public void OneProductWithLeadTimeOfTwoDay()
        {
            // Arrange
            var controller = new DispatchDateController(DispatchEstimation);
            var productIds = new List<int>() { 2 };
            var orderDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = orderDate.AddDays(2);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }

        [Fact]
        public void OneProductWithLeadTimeOfThreeDay()
        {
            // Arrange
            var controller = new DispatchDateController(DispatchEstimation);
            var productIds = new List<int>() { 3 };
            var orderDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = orderDate.AddDays(3);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }

        [Fact]
        public void SaturdayHasExtraTwoDays()
        {
            // Arrange
            var controller = new DispatchDateController(DispatchEstimation);
            var productIds = new List<int>() { 1 };
            var orderDate = new DateTimeOffset(2024, 1, 26, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = orderDate.AddDays(3);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }

        [Fact]
        public void SundayHasExtraDay()
        {
            // Arrange
            var controller = new DispatchDateController(DispatchEstimation);
            var productIds = new List<int>() { 3 };
            var orderDate = new DateTimeOffset(2024, 1, 25, 0, 0, 0, TimeSpan.Zero);
            var expectedDate = orderDate.AddDays(4);

            // Act
            var response = controller.Get(productIds, orderDate);

            // Assert
            response.EstimatedDispatchDate.ShouldBe(expectedDate);
        }
    }
}
