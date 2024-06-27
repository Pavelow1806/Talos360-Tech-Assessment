using Dispatch.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatch.Api.Services.SupplierManagement
{
    public class SupplierManagementService : ISupplierManagementService
    {
        private readonly IDbContext _dbContext;
        public SupplierManagementService(IDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<int> FindMaxLeadTime(List<int> supplierIds, CancellationToken cancellationToken)
        {
            return await _dbContext.Suppliers
                .Where(s => supplierIds.Contains(s.SupplierId))
                .Select(s => s.LeadTime)
                .MaxAsync(cancellationToken);
        }
    }
}
