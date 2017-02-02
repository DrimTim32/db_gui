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
    using DataProxy.Entities;
    using DataProxy.Functions;
    using FirstFloor.ModernUI.Windows.Controls;

    public partial class Categories : Page
    {
        private IList<ShowableCategory> _categories;
        public IList<ShowableCategory> CategoriesList
        {
            get
            {
                if (_categories == null)
                    _categories = new ObservableCollection<ShowableCategory>(CategoriesFunctions.GetAllCategories());
                return _categories;
            }
            set { _categories = value; }
        }

        private List<string> PossibleOverridingCategories
        {
            get { return CategoriesList.Select(x => x.Name).ToList(); }
        }

        public Categories()
        {
            InitializeComponent();
            DataGridCombo.ItemsSource = PossibleOverridingCategories;
            DataGrid.PreviewKeyDown += DataGrid_PreviewKeyDown;
            DataGrid.RowEditEnding += DataGrid_RowEditEnding;

        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (this.DataGrid.SelectedItem != null)
            {
                (sender as DataGrid).RowEditEnding -= DataGrid_RowEditEnding;
                (sender as DataGrid).CommitEdit();
                (sender as DataGrid).Items.Refresh();
                (sender as DataGrid).RowEditEnding += DataGrid_RowEditEnding;
                var cat = (ShowableCategory)e.Row.Item;
                var q = CategoriesFunctions.AddCategory(cat);
                if (q != "")
                    ModernDialog.ShowMessage(q, "Problem with writing to database", MessageBoxButton.OK);
                RefreshOverridingPossibilities();
            }
            else return;
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
                    var result = ModernDialog.ShowMessage("About to delete the current row.\n\nProceed?", "Delete",
                        MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.No)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        var cat = (ShowableCategory)dgr.Item;
                        var data = CategoriesFunctions.RemoveCategory(cat.Id);
                    }
                }
            }
        }

        private void RefreshOverridingPossibilities()
        {
            DataGridCombo.ItemsSource = PossibleOverridingCategories;
        }

    }
}
