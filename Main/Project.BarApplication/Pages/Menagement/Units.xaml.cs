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

    public partial class Units : Page
    {
        private ObservableCollection<ShowableUnit> _unitsList;
        public ObservableCollection<ShowableUnit> UnitsLits
        {
            get
            {
                if (_unitsList == null)
                    _unitsList = new ObservableCollection<ShowableUnit>(UnitsFunctions.GetAllUnits());
                return _unitsList;
            }
            set { _unitsList = value; }
        }
        public Units()
        {
            InitializeComponent();
            DataGridCombo.ItemsSource = UnitsFunctions.GetTypes();
            DataGrid.RowEditEnding += DataGrid_RowEditEnding;
            DataGrid.PreviewKeyDown += DataGrid_PreviewKeyDown;

        }

        private bool IsUnitEmpty(ShowableUnit unit)
        {
            return unit.Name == null && unit.Type == null;
        }
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var grid = sender as DataGrid;
            if (DataGrid.SelectedItem != null && grid != null)
            {
                var cat = (ShowableUnit)e.Row.Item;
                grid.RowEditEnding -= DataGrid_RowEditEnding;
                grid.CommitEdit();
                string message = "";

                if (IsUnitEmpty(cat))
                    message = "You cannot create empty unit";
                if (string.IsNullOrEmpty(cat.Name))
                    message = "You cannot create category with empty name";
                if (string.IsNullOrEmpty(cat.Type))
                    message = "You cannot create category with empty type";
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
                var q = UnitsFunctions.AddUnit(cat);
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
                    var result = ModernDialog.ShowMessage("About to delete the current row.\n\nProceed?", "Delete",
                        MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.No)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        var unit = (ShowableUnit)dgr.Item;
                        var data = UnitsFunctions.RemoveUnit(unit.Id);
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
            UnitsLits.Clear();
            var tmp = UnitsFunctions.GetAllUnits();
            foreach (var showableCategory in tmp)
            {
                UnitsLits.Add(showableCategory);
            }
            DataGrid.Items.Refresh();
        }
    }
}
