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
    /// <summary>
    /// This class is the view model for the Customers window.
    /// </summary>
    public class CustomersViewModel : INotifyPropertyChanged
    {
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

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }
        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        public ObservableCollection<Customer> TableDisplay
        {
            get => _TableDisplay;
            set
            {
                _TableDisplay = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Customer> _TableDisplay;
        private readonly GGDbContext _context;
        private CustomersOperations _customersOperations;


        public CustomersViewModel(GGDbContext context)
        {
            _context = context;
            _customersOperations = new CustomersOperations(_context);

            Add = new Command(AddElementToDb);
            Remove = new Command(RemoveFromDb);
            UpdateTable();
        }

        public ICommand Add { get; set; }
        public ICommand Remove { get; set; }

        private void RemoveFromDb()
        {
            if (!int.TryParse(ID, out int partId))
            {
                MessageBox.Show("Invalid ID. Please enter a valid integer value.", "Error");
                return;
            }

            _customersOperations.DeleteCustomer(Convert.ToInt32(ID));
            UpdateTable();
        }
        private void AddElementToDb()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone))
            {
                MessageBox.Show("Invalid input", "Error");
                return; 
            }

            _customersOperations.AddCustomer(Name, Email, Phone);
            UpdateTable();
        }
        public void UpdateTable()
        {
            var displaytable = new DatabaseOperations(new GGDbContext());
            TableDisplay = new ObservableCollection<Customer>(displaytable.GetData<Customer>());
        }
    }
}
