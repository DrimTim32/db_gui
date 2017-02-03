using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy.Functions
{
    using System.Data.Entity;
    using DatabaseConnector;
    using Entities;
    using Extensions;

    public static class ProductsFunctions
    {
        public static IEnumerable<ShowableSimpleProduct> GetProductView()
        {
            using (var db = new BarProjectEntities())
            {
                return db.productSimples.ToAnotherType<productSimple, ShowableSimpleProduct>().ToList();
            }
        }

        public static IEnumerable<ShowableSoldProduct> GetSoldProductsView(int id)
        {
            using (var db = new BarProjectEntities())
            {
                return
                    db.soldProductDetails(id).ToAnotherType<soldProductDetails_Result, ShowableSoldProduct>().ToList();
            }
        }
    }
}
