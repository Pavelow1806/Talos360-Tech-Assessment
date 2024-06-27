using Dispatch.Api.Model.Responses;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatch.Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IProductManagementService _productManagement;
        public ItemsController(IProductManagementService productManagement)
        {
            _productManagement = productManagement;
        }
        [HttpGet]
        [Route("get")]
        public async Task<ItemsResponse> Get(CancellationToken cancellationToken)
        {
            var products = await _productManagement.GetProducts(cancellationToken);
            return new ItemsResponse { Products = products };
        }
    }
}
