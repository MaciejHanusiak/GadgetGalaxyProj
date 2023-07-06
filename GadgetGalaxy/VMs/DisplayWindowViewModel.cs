using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GadgetGalaxy.Methods;
using GadgetGalaxy.Views;
using GadgetGalaxyDatabase;
using GadgetGalaxyDatabase.DbSets;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GadgetGalaxy.VMs
{
    public class DisplayWindowViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        private string _totalProducts;
        public string TotalProducts
        {
            get
            {
                return "Total products: "+_totalProducts;
            }
            set
            {
                if (_totalProducts != value)
                {
                    _totalProducts = value;
                    OnPropertyChanged(nameof(TotalProducts));
                }
            }
        }

        private string _totalCustomers;
        public string TotalCustomers
        {
            get
            {
                return "Total customers: "+_totalCustomers;
            }
            set
            {
                if (_totalCustomers != value)
                {
                    _totalCustomers = value;
                    OnPropertyChanged(nameof(TotalCustomers));
                }
            }
        }

        private string _totalOrders;
        public string TotalOrders
        {
            get
            {
                return "Total orders: "+_totalOrders;
            }
            set
            {
                if (_totalOrders != value)
                {
                    _totalOrders = value;
                    OnPropertyChanged(nameof(TotalOrders));
                }
            }
        }

        private ObservableCollection<Product> _displayTable;
        private readonly DatabaseOperations _databaseOperations;
        private readonly ShowStatistics _showStatistics;

        public ObservableCollection<Product> DisplayTable
        {
            get => _displayTable;
            set
            {
                _displayTable = value;
                OnPropertyChanged();
            }
        }

        public DisplayWindowViewModel()
        {
            _databaseOperations = new DatabaseOperations(new GGDbContext());
            _showStatistics = new ShowStatistics(new GGDbContext());
            OrderViewShow = new Command(OrderShow);
            UserViewShow = new Command(UserShow);
            CustomersViewShow = new Command(CustomersShow);
            ProductsViewShow = new Command(ProductsShow);
            UpdatePartsTable();
            TotalProductsShow();
            TotalCustomersShow();
            TotalOrdersShow();
        }

        private void TotalProductsShow()
        {
            TotalProducts = _showStatistics.GetTotalProducts();
        }

        private void TotalCustomersShow()
        {
            TotalCustomers = _showStatistics.GetTotalCustomers();
        }
        private void TotalOrdersShow()
        {
            TotalOrders = _showStatistics.GetTotalOrders();
        }
        public Command ProductsViewShow { get; set; }
        public Command CustomersViewShow { get; set; }
        public Command UserViewShow { get; set; }
        public Command OrderViewShow { get; set; }
        private void ProductsShow()
        {
            var window = new Products();
            Application.Current.MainWindow = window;
            window.Show();
        }
        private void OrderShow()
        {
            var window = new Views.Order();
            Application.Current.MainWindow = window;
            window.Show();
        }
        private void UserShow()
        {
            var window = new Users();
            Application.Current.MainWindow = window;
            window.Show();
        }
        private void CustomersShow()
        {
            var window = new Customers();
            Application.Current.MainWindow = window;
            window.Show();
        }
        public void UpdatePartsTable()
        {
            DisplayTable = new ObservableCollection<Product>(_databaseOperations.GetData<Product>());
        }

    }
}
