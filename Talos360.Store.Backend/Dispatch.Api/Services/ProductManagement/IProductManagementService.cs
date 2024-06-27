using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dispatch.Data;

namespace Dispatch.Api.Services.ProductManagement
{
    public interface IProductManagementService
    {
        Task<List<int>> GetUniqueSupplierIds(List<int> productIds, CancellationToken cancellationToken);
        Task<List<Product>> GetProducts(CancellationToken cancellationToken);
        Task<Product> GetProduct(int productId, CancellationToken cancellationToken);
    }
}
