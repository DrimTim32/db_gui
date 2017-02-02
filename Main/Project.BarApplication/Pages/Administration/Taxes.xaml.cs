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

namespace Project.BarApplication.Pages.Administration
{
    using DataProxy.Entities;
    using DataProxy.Functions;

    /// <summary>
    /// Interaction logic for Taxes.xaml
    /// </summary>
    public partial class Taxes : Page
    {
        public IEnumerable<Tax> TaxesData { get; set; }
        public Taxes()
        {
            InitializeComponent();
            TaxesData = TaxesFunctions.GetTaxes();
            TaxesGrid.ItemsSource = TaxesData;
        }

    }
}
