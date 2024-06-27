using Dispatch.Api.Extensions;
using Dispatch.Api.Model.Responses;
using Dispatch.Api.Services.ProductManagement;
using Dispatch.Api.Services.SupplierManagement;
using Dispatch.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dispatch.Api.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly ISupplierManagementService _supplierManagement;
        private readonly IProductManagementService _productManagement;
        public StoreController(IProductManagementService productManagement, ISupplierManagementService supplierManagement)
        {
            _productManagement = productManagement;
            _supplierManagement = supplierManagement;
        }
        [HttpGet]
        [EnableCors("AllowAnyOrigins")]
        public StoreResponse Get()
        {
            var suppliers = _supplierManagement.GetSuppliers();
            var products = _productManagement.GetProducts();
            var storeSuppliers = suppliers
                .Select(s => s.ConvertToStoreSupplier(products
                                                        .Where(p => p.SupplierId == s.SupplierId)
                                                        .ToList())
                )
                .ToList();
            return new StoreResponse { Suppliers = storeSuppliers };
        }
    }
}
