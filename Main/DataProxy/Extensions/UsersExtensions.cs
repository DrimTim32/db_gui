using System;
using System.Collections.Generic;
using System.Linq;


namespace DataProxy.Extensions
{ 
    using DatabaseConnector;
    using Entities;

    public static class UserExtensions
    {
        public static IEnumerable<ShowableUser> ToShowableUsers(this IEnumerable<User> users)
        {
            return users.Select(x => new ShowableUser(x));
        }
    }
}
