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
    /// <summary>
    /// Interaction logic for AllUsers.xaml
    /// </summary>
    public partial class AllUsers : UserControl
    {
        public AllUsers()
        {
            InitializeComponent();
            this.Loaded += AllUsers_Loaded;
        }

        private void AllUsers_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid.DataContext = DataProxy.Functions.UserFunctions.GetAllUsers();
        }
    }
}
