using System;
using System.Collections.Generic;
using System.Text;

namespace Dispatch.Data
{
    public class StoreSupplier : Supplier
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
