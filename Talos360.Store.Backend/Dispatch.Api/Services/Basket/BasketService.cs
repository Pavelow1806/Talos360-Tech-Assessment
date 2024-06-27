using Dispatch.Api.Model.Responses;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatch.Api.Services.Basket
{
    public class BasketService : IBasketService
    {
        private readonly IDbContext _dbContext;
        private readonly IProductManagementService _productManagement;
        public BasketService(IDbContext dbContext, IProductManagementService productManagement) 
        { 
            _dbContext = dbContext;
            _productManagement = productManagement;
        }
        public AddToBasketResponse AddToBasket(int productId)
        {
            if (!_dbContext.BasketItems.ContainsKey(productId))
                _dbContext.BasketItems.Add(productId, 1);
            else
                _dbContext.BasketItems[productId]++;
            return new AddToBasketResponse { Success = true };
        }

        public ClearBasketResponse ClearBasket()
        {
            _dbContext.BasketItems.Clear();
            return new ClearBasketResponse { Success = true };
        }

        public List<GroupedBasketItem> GetBasket()
        {
            var basketItemIds = _dbContext.BasketItems.Keys.ToList();
            var products = _productManagement.GetProducts(basketItemIds);
            return products
                .Select(p => new GroupedBasketItem
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    SupplierId = p.SupplierId,
                    Quantity = _dbContext.BasketItems[p.ProductId]
                })
                .GroupBy(p => p.ProductId)
                .Select(g => new GroupedBasketItem
                {
                    ProductId = g.First().ProductId,
                    Name = g.First().Name,
                    SupplierId = g.First().SupplierId,
                    Quantity = g.Sum(p => p.Quantity)
                })
                .ToList();
        }

        public RemoveFromBasketResponse RemoveFromBasket(int productId)
        {
            int currentCount = _dbContext.BasketItems[productId];
            if (_dbContext.BasketItems.ContainsKey(productId))
            {
                if (currentCount > 1)
                    _dbContext.BasketItems[productId]--;
                else
                    _dbContext.BasketItems.Remove(productId);
            }                
            return new RemoveFromBasketResponse { Success = true };
        }
    }
}
