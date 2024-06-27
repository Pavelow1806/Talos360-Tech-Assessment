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
        AddToBasketResponse AddToBasket(int productId);
        RemoveFromBasketResponse RemoveFromBasket(int productId);
        ClearBasketResponse ClearBasket();
        List<GroupedBasketItem> GetBasket();
    }
}
