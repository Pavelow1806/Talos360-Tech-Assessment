namespace Dispatch.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IDbContext
    {
        IQueryable<Supplier> Suppliers { get; }

        IQueryable<Product> Products { get; }

        List<BasketItem> BasketItems { get; set; }
    }
}
