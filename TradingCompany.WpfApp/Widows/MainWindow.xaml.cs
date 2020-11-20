using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TradingCompany.BusinessLogic.Concrete;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;
using Unity.Injection;
using Unity;
using Unity.Resolution;
using TradingCompany.BusinessLogic.Interfaces;

namespace TradingCompany.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Id;
        List<ProductDTO> products;
        ITraderManager _tradeManager;
        public MainWindow(ITraderManager traderManager)
        {
            products = new List<ProductDTO>();
            InitializeComponent();
            _tradeManager = traderManager;
            Id = App.Id;
            UserDTO currentUser = _tradeManager.GetUserById(Id);
            nameProp.Content = "Name: " + currentUser.FirstName + " " + currentUser.LastName;
            emailProp.Content = "Email:"+ currentUser.Email;
            
            Update();
        }
        void Update()
        {
            dataGrid.ItemsSource = products;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Усі права захищені.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Catalog catalog = App.Container.Resolve<Catalog>();
            catalog.ShowDialog();
            products.AddRange(catalog.BuyList);

            int sum = 0;
            foreach (var i in  products){
                sum += i.Price;
            }
            total.Content = "Сума до сплати: " + sum.ToString();
            dataGrid.Items.Refresh();
            Update();


        }
    }
}
