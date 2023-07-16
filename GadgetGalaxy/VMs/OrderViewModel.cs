using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GadgetGalaxy.Methods;
using GadgetGalaxyDatabase;
using GadgetGalaxyDatabase.DbSets;

namespace GadgetGalaxy.VMs;

/// <summary>
/// This class is the view model for the Orders window.
/// </summary>
public class OrderViewModel : INotifyPropertyChanged
{
    private readonly GGDbContext _context;
    private readonly OrdersOperations _ordersOperations;
    private readonly ProductsOperation _productsOperations;

    private string _categoryID;

    private string _id;

    private string _name;

    private string _price;

    private ObservableCollection<Order> _TableDisplay;


    public OrderViewModel(GGDbContext context)
    {
        _context = context;
        _ordersOperations = new OrdersOperations(_context);
        Remove = new Command(RemoveFromDb);
        UpdateTable();
    }

    public string ID
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<Order> TableDisplay
    {
        get => _TableDisplay;
        set
        {
            _TableDisplay = value;
            OnPropertyChanged();
        }
    }

    public ICommand Add { get; set; }
    public ICommand Remove { get; set; }
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

    private void RemoveFromDb()
    {
        if (!int.TryParse(ID, out var partId))
        {
            MessageBox.Show("Invalid ID. Please enter a valid integer value.", "Error");
            return;
        }

        _ordersOperations.removeOrder(Convert.ToInt32(ID));
        UpdateTable();
    }

    public void UpdateTable()
    {
        var dbtotable = new DatabaseOperations(new GGDbContext());
        TableDisplay = new ObservableCollection<Order>(dbtotable.GetData<Order>());
    }
}