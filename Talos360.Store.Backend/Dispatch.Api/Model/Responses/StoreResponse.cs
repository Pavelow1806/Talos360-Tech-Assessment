using Dispatch.Data;
using System.Collections.Generic;

namespace Dispatch.Api.Model.Responses
{
    public class StoreResponse : ResponseBase
    {
        public List<StoreSupplier> Suppliers { get; set; } = new List<StoreSupplier>();
    }
}
