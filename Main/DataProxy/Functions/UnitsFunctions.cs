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

    public static class UnitsFunctions
    {
        public static List<ShowableUnit> GetAllUnits()
        {
            using (var db = new BarProjectEntities())
            {
                return db.Units.Select(x => x).ToAnotherType<Unit, ShowableUnit>().ToList();
            }
        }
        public static List<string> GetTypes()
        {
            using (var db = new BarProjectEntities())
            {
                return db.UnitTypes.Select(x => x.type_name).ToList();
            }
        }

        public static string AddUnit(ShowableUnit unit)
        {
            try
            {
                using (var db = new BarProjectEntities())
                {
                    var q = db.UnitTypes.FirstOrDefault(x => x.type_name == unit.Type);
                    if (q != null)
                    {
                        db.addUnit(unit.Name, unit.Factor, q.id);
                    }
                    else
                    {
                        throw new ArgumentException("Problem with type name!");
                    }
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

        public static string RemoveUnit(int id)
        {
            try
            {
                using (var db = new BarProjectEntities())
                {
                    db.removeUnit(id);
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
