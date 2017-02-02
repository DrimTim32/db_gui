using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy.Extensions
{
    using DatabaseConnector;
    using Entities;

    public static class CategoriesExtensions
    {
        public static IEnumerable<ShowableCategory> ToShowableCategories(this IEnumerable<Category> users)
        {
            return users.Select(x => new ShowableCategory(x));
        }
    }
}
