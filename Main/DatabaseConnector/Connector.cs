namespace DatabaseConnector
{
    using System;
    using System.Net.Http;

    public enum UserType
    {
        Cook, Waitress, Admin, Owner
    }
    public class Connector
    {
        static HttpClient client = new HttpClient();
        public static UserType GetUserType(string nickname)
        {
            throw new NotImplementedException();
        }
    }
}
