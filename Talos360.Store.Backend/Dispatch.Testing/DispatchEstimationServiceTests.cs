using Dispatch.Api.Services.DispatchEstimation;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Api.Services.SupplierManagement;
using Dispatch.Data;

namespace Dispatch.Testing
{
    public class DispatchEstimationServiceTests
    {
        [Theory]
        [InlineData(new[] {1}, 2024, 1, 1, 2024, 1, 2)]
        public void LeadTimeAddedToDispatchDate(int[] productIdsArray, int orderYear, int orderMonth, int orderDay, int expectedYear, int expectedMonth, int expectedDay)
        {
            // Arrange
            var productIds = productIdsArray.ToList();
            var orderDate = new DateTimeOffset(orderYear, orderMonth, orderDay, 0, 0, 0, TimeSpan.Zero);
            var expectedDispatchDate = new DateTimeOffset(expectedYear, expectedMonth, expectedDay, 0, 0, 0, TimeSpan.Zero);
            var dbContext = new DbContext();
            var productManagementService = new ProductManagementService(dbContext);
            var supplierManagementService = new SupplierManagementService(dbContext);
            var dispatchEstimationService = new DispatchEstimationService(productManagementService, supplierManagementService);

            // Act
            var response = dispatchEstimationService.EstimateDispatchDate(productIds, orderDate);

            // Assert
            Assert.Equal(expectedDispatchDate, response.Date);
        }
    }
}