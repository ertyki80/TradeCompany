using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TradingCompany.BusinessLogic;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Services;

namespace TradingCompany.WpfApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public int Id;
        UserService _userService;
        AuthManager _authManager;
        public Login(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox1_Copy.Text = "";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.BorderBrush = Brushes.Red;

            }
            if (textBox1_Copy.Text.Length == 0)
            {
                textBox1_Copy.BorderBrush = Brushes.Red;
            }
            else
            {
                textBox1_Copy.BorderBrush = Brushes.Green;
                textBox1.BorderBrush = Brushes.Green;
            }
            string login = textBox1.Text;
            string password = textBox1_Copy.Text;
            try
            {
              _authManager = new AuthManager(_userService);
                if (_authManager.Login(login, password))
                {
                    Id = _authManager.GetId(login);
                    DialogResult = true;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Register register = new Register(_authManager);
            register.ShowDialog();
            DialogResult = true;
            this.Close();
        }
    }
}
