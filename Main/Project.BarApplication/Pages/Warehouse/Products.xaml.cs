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

namespace Project.BarApplication.Pages.Warehouse
{
    using System.Collections.ObjectModel;
    using Content.Warehouse;
    using DataProxy.Entities;
    using DataProxy.Functions;
    using FirstFloor.ModernUI.Windows.Controls;

    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        private ObservableCollection<ShowableSimpleProduct> _productsList;

        public ObservableCollection<ShowableSimpleProduct> ProductLists
        {
            get
            {
                if (_productsList == null)
                    _productsList = new ObservableCollection<ShowableSimpleProduct>(ProductsFunctions.GetProductView());
                return _productsList;
            }
            set { _productsList = value; }
        }

        public Products()
        {
            InitializeComponent();
            DataGrid.MouseDoubleClick += DataGrid_MouseDoubleClick;
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg != null)
            {
                DataGridRow dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                var product = (ShowableSimpleProduct)dgr.Item;
                if (product.IsSold)
                {
                    var url = $"../../Content/Warehouse/SoldProductPage.xaml?id={Guid.NewGuid()}";
                    BBCodeBlock bs = new BBCodeBlock();
                    try
                    { 
                        Application.Current.Properties["product_id"] = product.Id;
                        bs.LinkNavigator.Navigate(new Uri(url, UriKind.Relative), this);
                    }
                    catch (Exception error)
                    {
                        ModernDialog.ShowMessage(error.Message, FirstFloor.ModernUI.Resources.NavigationFailed, MessageBoxButton.OK);
                    }
                }
                else if (product.IsStored)
                {
                }
            }
        }
    }
}
