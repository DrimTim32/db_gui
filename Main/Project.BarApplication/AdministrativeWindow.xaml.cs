using System;
using System.Windows;

namespace Project.BarApplication
{
    using System.Linq;
    using System.Windows.Automation.Peers;
    using System.Windows.Input;
    using System.Windows.Navigation;
    using System.Windows.Threading;
    using DataProxy;
    using FirstFloor.ModernUI.Presentation;
    using FirstFloor.ModernUI.Windows.Controls;
    using FirstFloor.ModernUI.Windows.Navigation;
    using Pages.Uncategorized;

    public partial class AdministrativeWindow : ModernWindow
    {
        private LinkGroupCollection MenuLinks { get; set; } = new LinkGroupCollection();
        private UserPrivileges? privileges = null;
        public AdministrativeWindow()
        {
            InitializeComponent();
            Action<UserPrivileges> afterLogin = AfterLogin;
            Application.Current.Properties["AfterLogin"] = afterLogin;
            this.MenuLinkGroups = MenuLinks;
            SetTitleLink();
            SetWelcomeGroup();
        }
        #region Create tabs
        private void SetWelcomeGroup()
        {
            var login = new Link
            {
                DisplayName = Config.Pages.PageNames.Login,
                Source = Config.Pages.PageUrls.Uncategorized.Login
            };
            var introduction = new Link
            {
                DisplayName = Config.Pages.PageNames.Main,
                Source = Config.Pages.PageUrls.Uncategorized.Main
            };
            var group = new LinkGroup();
            group.Links.Add(login);
            group.Links.Add(introduction);
            group.DisplayName = Config.Pages.PagesGroupNames.Welcome;
            MenuLinks.Add(group);
        }
        private void SetAdministrationGroup()
        {
            var users = new Link
            {
                DisplayName = Config.Pages.PageNames.Users,
                Source = Config.Pages.PageUrls.Administration.Users
            };
            var taxes = new Link
            {
                DisplayName = Config.Pages.PageNames.Taxes,
                Source = Config.Pages.PageUrls.Administration.Taxes
            };
            var units = new Link
            {
                DisplayName = Config.Pages.PageNames.Units,
                Source = Config.Pages.PageUrls.Administration.Units
            };
            var group = new LinkGroup();
            group.Links.Add(users);
            group.Links.Add(taxes);
            group.Links.Add(units);
            group.DisplayName = Config.Pages.PagesGroupNames.Administration;
            MenuLinks.Add(group);
        }
        private void SetTitleLink()
        {
            TitleLinkMain.DisplayName = Config.Pages.PageNames.Settings;
            TitleLinkMain.Source = Config.Pages.PageUrls.Uncategorized.Settings;
        }
        private void SetWarehouse()
        {
            var Recipies = new Link
            {
                DisplayName = Config.Pages.PageNames.Recipies,
                Source = Config.Pages.PageUrls.Warehouse.Recipies
            };
            var Prices = new Link
            {
                DisplayName = Config.Pages.PageNames.Prices,
                Source = Config.Pages.PageUrls.Warehouse.Prices
            };
            var Categories = new Link
            {
                DisplayName = Config.Pages.PageNames.Categories,
                Source = Config.Pages.PageUrls.Warehouse.Categories
            };

            var group = new LinkGroup();
            group.Links.Add(Recipies);
            group.Links.Add(Prices);
            group.Links.Add(Categories);
            group.DisplayName = Config.Pages.PagesGroupNames.Warehouse;
            MenuLinks.Add(group);
        }
        #endregion
        private void AfterLogin(UserPrivileges permission)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DispatcherOperationCallback(delegate
            {
                if (privileges == null)
                {
                    if ((permission | UserPrivileges.NoUser) != 0)
                    {
                        if ((permission & UserPrivileges.HighPrivlidges) != 0)
                        {
                            OpenOwner();
                        }
                        if ((permission & UserPrivileges.WarehouseAdministrator) != 0)
                        {
                            OpenWarehouse();
                        }
                        if ((permission == UserPrivileges.Cook))
                        {
                            OpenCook();
                        }
                        if (permission == UserPrivileges.Waitress)
                        {
                            OpenWaitress();
                        }
                        privileges = permission;
                    }
                    else
                    {
                        ModernDialog.ShowMessage("There is no such user in database or wrong password was provided",
                            "Login problem", MessageBoxButton.OK);
                    }
                }
                else
                {
                    RedirectAfterLogin();
                }
                return null;
            }), null);


        }

        private void RedirectAfterLogin()
        {
            ContentSource = Config.Pages.PageUrls.Uncategorized.Main;

        }
        private void OpenWarehouse()
        {
            SetWarehouse();
            ClearLogin();
        }

        private void OpenOwner()
        {
            SetAdministrationGroup();
            ClearLogin();
        }

        private void OpenCook()
        {

        }

        private void OpenWaitress()
        {

        }

        private void ClearLogin()
        {
            var login = MenuLinks[0].Links.FirstOrDefault(x => x.DisplayName == Config.Pages.PageNames.Login);
            if (login != null)
            {
                MenuLinks[0].Links.Remove(login);
                RedirectAfterLogin();
            }

        }

    }
}
