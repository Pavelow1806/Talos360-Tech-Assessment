using Dispatch.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Dispatch.Api.Services.SupplierManagement
{
    public interface ISupplierManagementService
    {
        Task<int> FindMaxLeadTime(List<int> supplierIds, CancellationToken cancellationToken);
    }
}
