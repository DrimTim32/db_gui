using System.Windows;
using System.Windows.Threading; // DispatcherUnhandledExceptionEventArgs
namespace Project.BarApplication
{
    using System;
    using System.Security.Permissions;
    using FirstFloor.ModernUI.Windows.Controls;

    [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
    public partial class App : Application
    {
        public App()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

        }
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            var message = e.Message;
            if (!string.IsNullOrEmpty(e.InnerException?.Message))
            {
                message += "\nInner exception:\n" + e.InnerException.Message;
            }
            ModernDialog.ShowMessage(
                $"Problem occured within an application, please report this message to administrator : {message}",
                "Error occured", MessageBoxButton.OK);
            MessageBox.Show("Application will now be terminated", "Problem", MessageBoxButton.OK);
            Environment.Exit(0);

        }
    }
}
