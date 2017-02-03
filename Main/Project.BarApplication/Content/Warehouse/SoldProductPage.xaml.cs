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

namespace Project.BarApplication.Content.Warehouse
{
    using System.Windows.Threading;
    using DataProxy.Entities;
    using DataProxy.Functions;
    using FirstFloor.ModernUI.Windows;
    using FirstFloor.ModernUI.Windows.Navigation;

    /// <summary>
    /// Interaction logic for SoldProductPage.xaml
    /// </summary>
    public partial class SoldProductPage : Page, IContent
    {
        private int productId { get; set; }
        public string MainTitle { get; set; }
        private ShowableSoldProduct _soldProduct;

        public ShowableSoldProduct SoldProduct
        {
            get
            {
                if (_soldProduct == null)
                    _soldProduct = ProductsFunctions.GetSoldProductsView(productId).First();
                return _soldProduct;
            }
            set
            {
                _soldProduct = value;
            }
        }
        public SoldProductPage()
        {
            InitializeComponent(); 
        }
         
        private void ReloadModel(string a)
        {
            Progress.IsIndeterminate = true;
            productId = (int)Application.Current.Properties["product_id"];
            MainTitle = $"Product number {productId}, with name {SoldProduct.Name}";
            SoldProduct.LoadFromAnother(ProductsFunctions.GetSoldProductsView(productId).First());
            Progress.IsIndeterminate = false;
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            var q = e.Content;
            var p = e.NavigationType;
            ReloadModel("navigation");
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
