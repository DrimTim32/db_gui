using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy.Entities
{
    using DatabaseConnector;

    public class ShowableSimpleProduct
    {
        public ShowableSimpleProduct()
        {

        }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public bool IsSold { get; set; }
        public bool IsStored { get; set; }
        public int Id;
        public ShowableSimpleProduct(productSimple product)
        {
            Name = product.name;
            CategoryName = product.category_name;
            IsSold = product.sold.Value;
            IsStored = product.stored.Value;
            Id = product.id;
        }
    }
}
