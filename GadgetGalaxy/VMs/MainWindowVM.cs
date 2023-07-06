using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GadgetGalaxyDatabase;
using GadgetGalaxy.Methods;
using GadgetGalaxy.Views;

namespace GadgetGalaxy.VMs
{
    class MainWindowVM : INotifyPropertyChanged
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

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private string _password;
        private readonly GGDbContext _context;
        private readonly Login _loginCommand;
        public string Password
        {
            get
            {
                return _password;
            }set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public MainWindowVM(GGDbContext context)
        {
            _context = context;
            LoginComm = new Command(Login);
            _loginCommand = new Login(_context);
        }

        private void Login()
        {
            if (_loginCommand.LoginUser(Username, Password))
            {
                var window = new DisplayWindowView();
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Close();
                }
                Application.Current.MainWindow = window;
                window.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

        public ICommand LoginComm { get; }
    }
}
