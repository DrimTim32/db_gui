using System;
using System.Collections.Generic;

namespace DataProxy.Functions
{
    using System.Linq;
    using DatabaseConnector;
    using Extensions;

    public static class TaxesFunctions
    {
        public static IEnumerable<Entities.Tax> GetTaxes()
        {
            using (var db = new BarProjectEntities())
            {
                return db.Taxes.Select(x => x).ToAnotherType<Tax, Entities.Tax>().ToList();
            }
        }
    }
}
