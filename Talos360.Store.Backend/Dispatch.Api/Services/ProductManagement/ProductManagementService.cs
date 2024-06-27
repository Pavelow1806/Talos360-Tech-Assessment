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

        public async Task<Product> GetProduct(int productId, CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                .FirstOrDefaultAsync(p => p.ProductId == productId, cancellationToken);
        }

        public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                .ToListAsync(cancellationToken);
        }

        public async Task<List<int>> GetUniqueSupplierIds(List<int> productIds, CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                .Where(p => productIds.Contains(p.ProductId))
                .Select(p => p.SupplierId)
                .Distinct()
                .ToListAsync(cancellationToken);
        }
    }
}
