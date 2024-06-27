using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dispatch.Data;

namespace Dispatch.Api.Services.ProductManagement
{
    public interface IProductManagementService
    {
        List<int> GetUniqueSupplierIds(List<int> productIds);
        List<Product> GetProducts();
        Product GetProduct(int productId);
    }
}
