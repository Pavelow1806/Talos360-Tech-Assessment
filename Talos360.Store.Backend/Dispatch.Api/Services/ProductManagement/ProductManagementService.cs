using Dispatch.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatch.Api.Services.ProductManagement
{
    public class ProductManagementService : IProductManagementService
    {
        private readonly IDbContext _dbContext;
        public ProductManagementService(IDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public Product GetProduct(int productId)
        {
            return _dbContext.Products
                .FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product> GetProducts()
        {
            return _dbContext.Products
                .ToList();
        }
        public List<Product> GetProducts(List<int> productIds)
        {
            return _dbContext.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToList();
        }

        public List<int> GetUniqueSupplierIds(List<int> productIds)
        {
            return _dbContext.Products
                .Where(p => productIds.Contains(p.ProductId))
                .Select(p => p.SupplierId)
                .Distinct()
                .ToList();
        }
    }
}
