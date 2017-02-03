using System;
using System.Collections.Generic;

namespace DataProxy.Functions
{
    using System.Linq;
    using DatabaseConnector;
    using Entities;
    using Extensions;

    public static class TaxesFunctions
    {
        public static IEnumerable<ShowableTax> GetAllTaxes()
        {
            using (var db = new BarProjectEntities())
            {
                return db.Taxes.Select(x => x).ToAnotherType<Tax, ShowableTax>().ToList();
            }
        }
        public static string AddTax(ShowableTax tax)
        {
            try
            {
                using (var db = new BarProjectEntities())
                {
                    db.addTax(tax.TaxName, tax.TaxValue);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message += "\nInner:" + ex.InnerException.Message;
                return message;
            }
            return "";

        }

        public static string RemoveTax(int id)
        {
            try
            {
                using (var db = new BarProjectEntities())
                {
                    db.removeTax(id);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                    message += "\nInner:" + ex.InnerException.Message;
                return message;
            }
            return "";
        }
    }
}
