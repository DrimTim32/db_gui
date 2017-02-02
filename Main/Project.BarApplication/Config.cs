using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BarApplication
{
    using System.IO;

    static class Config
    {
        public static class Pages
        {
            public static class PagesGroupNames
            {
                public const string Welcome = "Welcome";
                public const string Administration = "Administration";
                public const string Warehouse = "Warehouse";
            }
            public static class PageNames
            {
                public const string Settings = "Settings";
                public const string Login = "Login";
                public const string Main = "Introduction";

                public const string Users = "Users";
                public const string Taxes = "Taxes";
                public const string Units = "Units";

                public const string Recipies = "Recipies";
                public const string Prices = "Prices";
                public const string Categories = "Categories";
            }

            public static class PageUrls
            {
                private static readonly string PagesSource = "/Pages";

                public class Uncategorized
                {
                    public static readonly Uri Settings = new Uri(Path.Combine(PagesSource, "Settings/Settings.xaml"), UriKind.Relative);
                    public static readonly Uri Login = new Uri(Path.Combine(PagesSource, "Login.xaml"), UriKind.Relative);
                    public static readonly Uri Main = new Uri(Path.Combine(PagesSource, "Uncategorized/Main.xaml"), UriKind.Relative);

                }
                public class Administration
                {
                    private static readonly string Source = Path.Combine(PagesSource, "Administration");
                    public static readonly Uri Users = new Uri(Path.Combine(Source, "Users.xaml"), UriKind.Relative);
                    public static readonly Uri Taxes = new Uri(Path.Combine(Source, "Taxes.xaml"), UriKind.Relative);
                    public static readonly Uri Units = new Uri(Path.Combine(Source, "Units.xaml"), UriKind.Relative);

                }

                public class Warehouse
                {
                    private static readonly string Source = Path.Combine(PagesSource, "Warehouse");
                    public static readonly Uri Recipies = new Uri(Path.Combine(Source, "Recipies.xaml"), UriKind.Relative);
                    public static readonly Uri Prices = new Uri(Path.Combine(Source, "Prices.xaml"), UriKind.Relative);
                    public static readonly Uri Categories = new Uri(Path.Combine(Source, "Categories.xaml"), UriKind.Relative);
                }
            }

        }
    }
}
