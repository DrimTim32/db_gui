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

    /// <summary>
    /// Interaction logic for SoldProductPage.xaml
    /// </summary>
    public partial class SoldProductPage : Page
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
            ReloadModel();
            Loaded += SoldProductPage_Loaded;
        }

        private void SoldProductPage_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadModel();
        }

        private void ReloadModel()
        {
            Progress.IsIndeterminate = true;
            productId = (int)Application.Current.Properties["product_id"];
            MainTitle = $"Product number {productId}, with name {SoldProduct.Name}";
            SoldProduct = ProductsFunctions.GetSoldProductsView(productId).First();  
            Progress.IsIndeterminate = false;
        } 
    }
}
