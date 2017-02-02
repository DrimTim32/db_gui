namespace Project.BarApplication.Pages
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using DataProxy;
    using DataProxy.Functions;

    public partial class Login : Page
    {

        public Login()
        {
            InitializeComponent();
            if(Environment.StackTrace.Contains("back")) 
            LoginBox.Text = "malin";
            PasswordBox.Password = "qwerty";
        }

        private class LoginData
        {
            public string Login;
            public string Password;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var password = PasswordBox.Password;
            var login = LoginBox.Text;
            var newThread = new Thread(LogIn);
            newThread.Start(new LoginData { Password = password, Login = login }); ;
        }

        private void LogIn(object loginData)
        {
            Progress.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DispatcherOperationCallback(delegate
            {
                Progress.IsIndeterminate = true;
                return null;
            }), null);
            var login = ((LoginData)loginData).Login;
            var password = ((LoginData)loginData).Password;
            var data = UserFunctions.GetPrivileges(login, password);
            Progress.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DispatcherOperationCallback(delegate
            {
                Progress.IsIndeterminate = false;
                return null;
            }), null);
            var fnc = Application.Current.Properties["AfterLogin"] as Action<UserPrivileges>;
            fnc?.Invoke(data);
        }
    }
}
