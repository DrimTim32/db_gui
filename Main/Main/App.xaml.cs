using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GuiBase;

namespace Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            OpenPopUp();
        }

        private LoginForm _currentLoginForm;
        private void OpenPopUp()
        {
            if (_currentLoginForm != null)
            {
                _currentLoginForm.Close();
            }
            _currentLoginForm = new LoginForm(SuccessLogin);
            _currentLoginForm.ShowDialog();
        }
        private void SuccessLogin(UserTypes obj)
        {
            if (!obj.Equals(UserTypes.Admin))
            {
                MessageBox.Show("You do not have permission to login to this application");
                OpenPopUp();
                return;
            }
            var window = new MainWindow();
            window.Show();
        }
         
    }
}
