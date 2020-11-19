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

namespace TradingCompany.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Id;
        List<ProductDTO> products;
        public MainWindow()
        {

            Id = App.Id;
            InitializeComponent();
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
            Update();


        }
    }
}
