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
        public static List<ShowableCategory> GetAllCategories()
        {
            using (var db = new BarProjectEntities())
            {
                return (from data in db.Categories
                        orderby data.id
                        select data).ToAnotherType<Category, ShowableCategory>().ToList();
            }
        }

        public static string AddCategory(ShowableCategory cat)
        {
            try
            {
                using (var db = new BarProjectEntities())
                {
                    int? overriding = null;
                    if (cat.Overriding != "")
                    {
                        var q = db.Categories.Where(x => x.category_name == cat.Overriding).Select(x => x).FirstOrDefault();
                        if (q != null)
                        {
                            overriding = q.id;
                        }
                    }
                    db.addCategory(cat.Name, cat.Slug, overriding);
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
        public static string RemoveCategory(int? id)
        {
            try
            {
                using (var db = new BarProjectEntities())
                {
                    db.removeCategory(id);
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
