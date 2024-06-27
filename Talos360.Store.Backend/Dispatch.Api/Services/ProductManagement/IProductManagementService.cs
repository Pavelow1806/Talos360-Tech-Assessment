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
        List<Product> GetProducts(List<int> productIds);
        Product GetProduct(int productId);
    }
}
