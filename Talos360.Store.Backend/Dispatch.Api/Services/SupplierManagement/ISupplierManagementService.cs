using Dispatch.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Dispatch.Api.Services.SupplierManagement
{
    public interface ISupplierManagementService
    {
        List<Supplier> GetSuppliers();
        int FindMaxLeadTime(List<int> supplierIds);
    }
}
