using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GadgetGalaxy.Methods;
using GadgetGalaxy.Views;
using GadgetGalaxyDatabase;
using GadgetGalaxyDatabase.DbSets;
using Order = GadgetGalaxy.Views.Order;

namespace GadgetGalaxy.VMs;

/// <summary>
/// This class is the view model for the Display window.
/// </summary>
public class DisplayWindowViewModel : INotifyPropertyChanged
{
    private readonly DatabaseOperations _databaseOperations;
    private readonly ShowStatistics _showStatistics;

    private ObservableCollection<Product> _displayTable;

    private string _totalCustomers;

    private string _totalOrders;

    private string _totalProducts;

    public DisplayWindowViewModel()
    {
        _databaseOperations = new DatabaseOperations(new GGDbContext());
        _showStatistics = new ShowStatistics(new GGDbContext());
        OrderViewShow = new Command(OrderShow);
        UserViewShow = new Command(UserShow);
        CustomersViewShow = new Command(CustomersShow);
        ProductsViewShow = new Command(ProductsShow);
        UpdateDisplayableInfo();
    }

    public void UpdateDisplayableInfo()
    {
        UpdatePartsTable();
        TotalProductsShow();
        TotalCustomersShow();
        TotalOrdersShow();
    }

    public string TotalProducts
    {
        get => "Total products: " + _totalProducts;
        set
        {
            if (_totalProducts != value)
            {
                _totalProducts = value;
                OnPropertyChanged();
            }
        }
    }

    public string TotalCustomers
    {
        get => "Total customers: " + _totalCustomers;
        set
        {
            if (_totalCustomers != value)
            {
                _totalCustomers = value;
                OnPropertyChanged();
            }
        }
    }

    public string TotalOrders
    {
        get => "Total orders: " + _totalOrders;
        set
        {
            if (_totalOrders != value)
            {
                _totalOrders = value;
                OnPropertyChanged();
            }
        }
    }

    public Command ProductsViewShow { get; set; }
    public Command CustomersViewShow { get; set; }
    public Command UserViewShow { get; set; }
    public Command OrderViewShow { get; set; }

    public ObservableCollection<Product> DisplayTable
    {
        get => _displayTable;
        set
        {
            _displayTable = value;
            OnPropertyChanged();
        }
    }

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

    private void ProductsShow()
    {
        var window = new Products();
        Application.Current.MainWindow = window;
        window.Show();
    }

    private void OrderShow()
    {
        var window = new Order();
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