using System;
using System.Collections.Generic;
using System.Text;

namespace Dispatch.Data
{
    public class BasketItem : Product
    {
        public Guid BasketItemId { get; set; }
        public DateTimeOffset DateAdded { get; set; }
    }
}
