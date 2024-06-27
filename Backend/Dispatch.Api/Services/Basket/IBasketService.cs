using Dispatch.Api.Model.Responses;
using Dispatch.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatch.Api.Services.Basket
{
    public interface IBasketService
    {
        Task<BasketItem> AddToBasket(int productId, CancellationToken cancellationToken);
        RemoveFromBasketResponse RemoveFromBasket(Guid basketItemId);
        ClearBasketResponse ClearBasket();
        List<BasketItem> GetBasket();
    }
}
