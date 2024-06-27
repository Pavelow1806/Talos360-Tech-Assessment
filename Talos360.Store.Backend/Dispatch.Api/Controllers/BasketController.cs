using Dispatch.Api.Model.Requests;
using Dispatch.Api.Model.Responses;
using Dispatch.Api.Services.Basket;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatch.Api.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        [Route("get")]
        public BasketResponse Get()
        {
            var items = _basketService.GetBasket();

            return new BasketResponse
            {
                Success = true,
                BasketItems = items
            };
        }
        [HttpPost]
        [Route("add")]
        public AddToBasketResponse Add([FromBody]AddToBasketRequest request)
        {
            _basketService.AddToBasket(request.ProductId);
            return new AddToBasketResponse { Success = true };
        }
        [HttpPost]
        [Route("remove")]
        public RemoveFromBasketResponse Remove([FromBody]RemoveFromBasketRequest request)
        {
            return _basketService.RemoveFromBasket(request.BasketItemId);
        }
        [HttpGet]
        [Route("clear")]
        public ClearBasketResponse Clear()
        {
            return _basketService.ClearBasket();
        }
    }
}
