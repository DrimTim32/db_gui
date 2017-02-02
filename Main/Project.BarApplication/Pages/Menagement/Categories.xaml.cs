namespace Project.BarApplication.Pages.Menagement
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using DataProxy.Entities;
    using DataProxy.Functions;
    using FirstFloor.ModernUI.Windows.Controls;

    public partial class Categories : Page
    {
        private ObservableCollection<ShowableCategory> _categories;
        public ObservableCollection<ShowableCategory> CategoriesList
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

        private bool CategoryIsEmpty(ShowableCategory cat)
        {
            return cat.Name == null && cat.Slug == null;
        }
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var grid = sender as DataGrid;
            if (DataGrid.SelectedItem != null && grid != null)
            {
                var cat = (ShowableCategory)e.Row.Item;
                grid.RowEditEnding -= DataGrid_RowEditEnding;
                grid.CommitEdit();
                string message = "";

                if (CategoryIsEmpty(cat))
                {
                    message = "You cannot create empty category";
                }
                if (string.IsNullOrEmpty(cat.Name))
                {
                    message = "You cannot create category with empty name";
                }
                if (string.IsNullOrEmpty(cat.Slug))
                {
                    message = "You cannot create category with empty slug";
                }
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
                var q = CategoriesFunctions.AddCategory(cat);
                if (q != "")
                    ModernDialog.ShowMessage(q, "Problem with writing to database", MessageBoxButton.OK);
                RefreshData();
            }
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
                        RefreshData();
                        if (data != "")
                        {
                            ModernDialog.ShowMessage(data, "Problem with writing to database", MessageBoxButton.OK);
                        }
                    }
                }
            }
        }

        private void RefreshData()
        {
            CategoriesList.Clear();
            var tmp = CategoriesFunctions.GetAllCategories();
            foreach (var showableCategory in tmp)
            {
                CategoriesList.Add(showableCategory);
            }
            RefreshOverridingPossibilities();
            DataGrid.Items.Refresh();
        }
        private void RefreshOverridingPossibilities()
        {
            DataGridCombo.ItemsSource = PossibleOverridingCategories;
        }

    }
}
