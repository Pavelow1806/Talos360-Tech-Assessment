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
        public async Task<BasketItem> AddToBasket(int productId, CancellationToken cancellationToken)
        {
            var product = await _productManagement.GetProduct(productId, cancellationToken);
            var newItem = new BasketItem
            {
                BasketItemId = Guid.NewGuid(),
                DateAdded = DateTime.UtcNow,
                Name = product.Name,
                ProductId = product.ProductId,
                SupplierId = product.SupplierId,
            };
            _dbContext.BasketItems
                .Add(newItem);
            return newItem;
        }

        public ClearBasketResponse ClearBasket()
        {
            _dbContext.BasketItems
                .Clear();
            return new ClearBasketResponse { Success = true };
        }

        public List<BasketItem> GetBasket()
        {
            return _dbContext.BasketItems;
        }

        public RemoveFromBasketResponse RemoveFromBasket(Guid basketItemId)
        {
            var item = _dbContext.BasketItems
                .FirstOrDefault(bi => bi.BasketItemId == basketItemId);
            if (item != null)
                _dbContext.BasketItems
                    .Remove(item);
            return new RemoveFromBasketResponse { Success = true };
        }
    }
}
