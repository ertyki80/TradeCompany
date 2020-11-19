using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.BusinessLogic.Interfaces;

namespace TradingCompany.WpfApp.ModelView
{
    class LoginViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            private get;
            set;
        }

        private readonly IAuthManager _security;

        public LoginViewModel(IAuthManager security)
        {
            _security = security;
        }

        public bool Login()
        {
            return _security.Login(Username, Password);
        }
    }

}
