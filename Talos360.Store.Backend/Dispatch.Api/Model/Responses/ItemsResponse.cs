using Dispatch.Data;
using System.Collections.Generic;

namespace Dispatch.Api.Model.Responses
{
    public class ItemsResponse : ResponseBase
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
