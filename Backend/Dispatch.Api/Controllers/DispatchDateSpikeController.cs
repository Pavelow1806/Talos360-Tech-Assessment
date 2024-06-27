//using Dispatch.Api.Model;
//using Dispatch.Data;
//using LanguageExt;
//using static LanguageExt.Prelude;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Dispatch.Api.Controllers
//{
//    public class DispatchDateSpikeController : Controller
//    {
//        [HttpGet]
//        public DispatchDate Get(List<int> productIds, DateTime orderDate)
//        {
//            var arrivalDates =
//            productIds
//            .Select(GetArrivalDateForProduct);

//            return
//            CalculateDispatchDate(arrivalDates);

//            Option<WarehouseArrivalDate> GetArrivalDateForProduct(int productId)
//            {
//                //Assumption - if we can't find the arrival date of any product then we cannot find the dispatch date of the order,
//                //so one missing product or one date that cannot be calculated is an error condition

//                return
//                from product in GetProduct()
//                from productWarhouseArrivalDate in GetWarehouseArrivalDateForProduct(product)
//                select new WarehouseArrivalDate(product, productWarhouseArrivalDate);

//                Option<Product> GetProduct()
//                {
//                    DbContext dbContext = new DbContext();

//                    return
//                    dbContext.Products.Where(x => x.ProductId == productId).HeadOrNone();
//                }

//                Option<DateTime> GetWarehouseArrivalDateForProduct(Product product)
//                {
//                    DbContext dbContext = new DbContext();

//                    return
//                    from supplier in GetSupplierForProduct()
//                    from arrivaldate in GetAllArrivalDateForProduct()
//                    select arrivaldate;

//                    Option<Supplier> GetSupplierForProduct()
//                    {
//                        return
//                        dbContext.Suppliers.Where(x => x.SupplierId == product.SupplierId).HeadOrNone();
//                    }

//                    Option<DateTime> GetAllArrivalDateForProduct()
//                    {
//                    }
//                }
//            }




//        }

//        private struct WarehouseArrivalDate
//        {
//            public WarehouseArrivalDate(Product product, Option<DateTime> arrivalDate)
//            {
//                Product = product;
//                ArrivalDate = arrivalDate;
//            }

//            public Product Product { get; }
//            public DateTime ArrivalDate { get; }
//        }
//    }
//}
