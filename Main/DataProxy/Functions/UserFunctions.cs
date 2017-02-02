namespace DataProxy.Functions
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using DatabaseConnector;
    using Entities;
    using Extensions;

    public static class UserFunctions
    {
        public static UserPrivileges GetPrivileges(string username, string password)
        {
            var toReturn = UserPrivileges.NoUser;
            using (var db = new BarProjectEntities())
            {
                db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                var parameter = new ObjectParameter("tmp_credentials", typeof(short));
                db.checkCredentials(username, password, parameter);
                var tmp = parameter.Value as short?;
                if (tmp.HasValue)
                {
                    return tmp.Value.ToUserPrivledges();
                }
            }
            return toReturn;
        }

        public static IEnumerable<ShowableUser> GetAllUsers()
        {
            using (var db = new BarProjectEntities())
            {
                return db.Users.Select(x => x).ToAnotherType<User, ShowableUser>().ToList();//.ToShowableUsers().ToList();
            }
        }

        public static void AddUser(string password, string username, string name, string surname, byte permission)
        {
            using (var db = new BarProjectEntities())
            {
                db.addUser(password, username, name, surname, permission);
            }
        }
    }
}
