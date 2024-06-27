using Dispatch.Data;
using System.Collections.Generic;

namespace Dispatch.Api.Extensions
{
    public static class SupplierExtensions
    {
        public static StoreSupplier ConvertToStoreSupplier(this Supplier supplier, List<Product> products)
        {
            return new StoreSupplier
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                LeadTime = supplier.LeadTime,
                Products = products
            };
        }
    }
}
