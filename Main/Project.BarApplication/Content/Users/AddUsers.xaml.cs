using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.BarApplication.Content.Users
{
    using DataProxy;
    using DataProxy.Functions;
    using ViewModels;

    /// <summary>
    /// Interaction logic for EditUsers.xaml
    /// </summary>
    public partial class EditUsers : UserControl
    {
        public EditUsers()
        {
            InitializeComponent();
            ComboPermission.ItemsSource = UserPrivlidgesExtensions.GetManagable;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var model = Form.DataContext as UserViewModel;
            if (model != null)
            {
                ProgressUpload.IsIndeterminate = true;
                try
                {
                    UserFunctions.AddUser(this.TextPassword.Password, model.Login, model.Name, model.Surname,
                        (byte) UserPrivlidgesExtensions.GetValueFromDescription(model.Permission));
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occured, please check your inputs.");
                }
                finally
                {
                    ProgressUpload.IsIndeterminate = false;
                }
            }
        }
    }
}
