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
    using DataProxy.Entities;
    using DataProxy.Functions;
    using FirstFloor.ModernUI.Windows.Controls;

    public partial class Categories : Page
    {
        private List<ShowableCategory> CategoriesList { get; set; }

        private List<string> PossibleOverridingCategories
        {
            get { return CategoriesList.Select(x => x.Name).ToList(); }
        }
        public Categories()
        {
            InitializeComponent();
            CategoriesList = CategoriesFunctions.GetAllCategories();
            DataGrid.DataContext = CategoriesList;
            DataGridCombo.ItemsSource = PossibleOverridingCategories;
            DataGrid.AddingNewItem += DataGrid_AddingNewItem;
            DataGrid.PreviewKeyDown += DataGrid_PreviewKeyDown;

        }

        void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg != null)
            {
                DataGridRow dgr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex));
                if (e.Key == Key.Delete && !dgr.IsEditing)
                {
                    // User is attempting to delete the row
                    var result = ModernDialog.ShowMessage(
                        "About to delete the current row.\n\nProceed?",
                        "Delete", MessageBoxButton.YesNo);
                    e.Handled = (result == MessageBoxResult.No);
                }
            }
        }

        private void RefreshOverridingPossibilities()
        {
            DataGridCombo.ItemsSource = PossibleOverridingCategories;
        }
        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            RefreshOverridingPossibilities();
        }

    }
}
