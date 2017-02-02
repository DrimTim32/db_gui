using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy.Functions
{
    using DatabaseConnector;
    using Entities;
    using Extensions;

    public static class CategoriesFunctions
    {
        public static IEnumerable<ShowableCategory> GetAllCategories()
        {
            using (var db = new BarProjectEntities())
            {
                return (from data in db.Categories
                       orderby data.id
                       select data).ToShowableCategories().ToList();
            }
        }
    }
}
