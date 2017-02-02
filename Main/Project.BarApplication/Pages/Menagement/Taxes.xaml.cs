namespace Project.BarApplication.Pages.Menagement
{
    using System.Collections.Generic;
    using System.Windows.Controls;
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
