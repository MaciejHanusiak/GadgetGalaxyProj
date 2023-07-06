using GadgetGalaxyDatabase.DbSets;
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
using GadgetGalaxyDatabase;

namespace GadgetGalaxy.VMs
{
    public class UsersViewModel : INotifyPropertyChanged
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

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
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

        public ObservableCollection<User> TableDisplay
        {
            get => _partsTableDisplay;
            set
            {
                _partsTableDisplay = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<User> _partsTableDisplay;
        private readonly GGDbContext _context;
        private readonly UsersOperations _usersOperations;


        public UsersViewModel(GGDbContext context)
        {
            _context = context;
            _usersOperations = new UsersOperations(_context);

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

            _usersOperations.removeUser(Convert.ToInt32(ID));
            UpdateTable();
        }
        private void AddElementToDb()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Invalid input", "Error");
                return; 
            }

            _usersOperations.addUser(Login, Password);
            UpdateTable();
        }
        public void UpdateTable()
        {
            var dbtotable = new DatabaseOperations(new GGDbContext());
            TableDisplay = new ObservableCollection<User>(dbtotable.GetData<User>());
        }
    }

}
