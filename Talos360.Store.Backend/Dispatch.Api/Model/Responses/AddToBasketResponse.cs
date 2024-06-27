using Dispatch.Data;

namespace Dispatch.Api.Model.Responses
{
    public class AddToBasketResponse : ResponseBase
    {
        public BasketItem Item { get; set; }
    }
}
