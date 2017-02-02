namespace Project.BarApplication.Pages.Menagement
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using DataProxy.Entities;
    using DataProxy.Functions;
    using FirstFloor.ModernUI.Windows.Controls;

    /// <summary>
    /// Interaction logic for Taxes.xaml
    /// </summary>
    public partial class Taxes : Page
    {
        private ObservableCollection<ShowableTax> _taxesData;

        public ObservableCollection<ShowableTax> TaxesData
        {
            get
            {
                if (_taxesData == null)
                {
                    _taxesData = new ObservableCollection<ShowableTax>(TaxesFunctions.GetAllTaxes());
                }
                return _taxesData;
            }
            set { _taxesData = value; }
        }

        public Taxes()
        {
            InitializeComponent();
            DataGrid.RowEditEnding += DataGrid_RowEditEnding;
            DataGrid.PreviewKeyDown += DataGrid_PreviewKeyDown;
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg != null)
            {
                DataGridRow dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                if (e.Key == Key.Delete && !dgr.IsEditing)
                {
                    // User is attempting to delete the row
                    var result = ModernDialog.ShowMessage("About to delete the current row.\n\nProceed?", "Delete",
                        MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.No)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        var tax = (ShowableTax)dgr.Item;
                        var data = TaxesFunctions.RemoveTax(tax.id);
                        RefreshData();
                        if (data != "")
                        {
                            ModernDialog.ShowMessage(data, "Problem with writing to database", MessageBoxButton.OK);
                        }
                    }
                }
            }
        }

        private bool IsTaxEmpty(ShowableTax tax)
        {
            return tax.TaxName == null && tax.TaxValue == null;
        }
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var grid = sender as DataGrid;
            if (DataGrid.SelectedItem != null && grid != null)
            {
                var tax = (ShowableTax)e.Row.Item;
                grid.RowEditEnding -= DataGrid_RowEditEnding;
                grid.CommitEdit();
                string message = "";

                if (IsTaxEmpty(tax))
                    message = "You cannot create empty unit";
                if (string.IsNullOrEmpty(tax.TaxName))
                    message = "You cannot create tax with empty name";
                if (tax.TaxValue == null)
                    message = "You cannot create tax with empty value";
                if (message != "")
                {
                    grid.CancelEdit();
                    grid.RowEditEnding += DataGrid_RowEditEnding;
                    ModernDialog.ShowMessage(message, "Problem with new item!", MessageBoxButton.OK);
                    grid.Items.Refresh();
                    RefreshData();
                    return;
                }
                grid.RowEditEnding += DataGrid_RowEditEnding;
                var q = TaxesFunctions.AddTax(tax);
                if (q != "")
                    ModernDialog.ShowMessage(q, "Problem with writing to database", MessageBoxButton.OK);
                RefreshData();
            }
        }
        private void RefreshData()
        {
            TaxesData.Clear();
            var tmp = TaxesFunctions.GetAllTaxes();
            foreach (var showableCategory in tmp)
            {
                TaxesData.Add(showableCategory);
            }
            DataGrid.Items.Refresh();
        }
    }
}
