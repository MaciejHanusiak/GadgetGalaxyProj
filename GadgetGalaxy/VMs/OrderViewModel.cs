using GadgetGalaxy.Methods;
using GadgetGalaxyDatabase.DbSets;
using GadgetGalaxyDatabase;
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

namespace GadgetGalaxy.VMs
{
    public class OrderViewModel : INotifyPropertyChanged
    {
    private readonly GGDbContext _context;
    private readonly ProductsOperation _productsOperations;

    private string _categoryID;

    private string _id;

    private string _name;

    private string _price;

    private ObservableCollection<Order> _TableDisplay;


    public OrderViewModel(GGDbContext context)
    {
        _context = context;
        _productsOperations = new ProductsOperation(_context);

        Add = new Command(AddElementToDb);
        Remove = new Command(RemoveFromDb);
        UpdateTable();
    }

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }

    public string Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                OnPropertyChanged();
            }
        }
    }

    public string CategoryID
    {
        get => _categoryID;
        set
        {
            if (_categoryID != value)
            {
                _categoryID = value;
                OnPropertyChanged();
            }
        }
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

        _productsOperations.removeProduct(Convert.ToInt32(ID));
        UpdateTable();
    }

    private void AddElementToDb()
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Price) ||
            string.IsNullOrWhiteSpace(CategoryID))
        {
            MessageBox.Show("Invalid input", "Error");
            return;
        }

        if (!decimal.TryParse(Price, out var Pricee))
        {
            MessageBox.Show("Invalid Price. Please enter a valid decimal value.", "Error");
            return;
        }

        if (Convert.ToInt32(CategoryID) > 10)
        {
            MessageBox.Show("Invalid CategoryId. CategoryID ranges from 1-10 Please enter a valid value.", "Error");
            return;
        }

        _productsOperations.addProduct(Name, Price, Convert.ToInt32(CategoryID));
        UpdateTable();
    }

    public void UpdateTable()
    {
        var dbtotable = new DatabaseOperations(new GGDbContext());
        TableDisplay = new ObservableCollection<Order>(dbtotable.GetData<Order>());
    }
    }
}
