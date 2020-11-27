using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Models;
using TradingCompany.WpfApp.ModelView;
using TradingCompany.WpfApp.Widows;
using TradingCompanyDataTransfer;
using Unity;

namespace TradingCompany.WpfApp
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        ProductListViewModel _productListViewModel;
        CollectionViewSource _productCollection;
        public List<ProductDTO> BuyList;


        public Catalog(ProductListViewModel vm)
        {
            BuyList = new List<ProductDTO>();
            _productCollection = (CollectionViewSource)(Resources["ProductCollection"]);
            _productListViewModel = vm;
            DataContext = vm;
            InitializeComponent();
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO product = (ProductDTO)dataGrid.SelectedItem;
            ProductDTO buyedProduct = _productListViewModel.Buy(product);
            BuyList.Add(buyedProduct);
            dataGrid.Items.Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO product = (ProductDTO)dataGrid.SelectedItem;
            _productListViewModel.Delete(product);
            dataGrid.Items.Refresh();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ProductDTO product = (ProductDTO)dataGrid.SelectedItem;
            AddProduct addProduct = App.Container.Resolve<AddProduct>();
            addProduct.AddParrameters(product.Id,product.Name, product.Price, product.Description, product.CountInStock);
            addProduct.ShowDialog();
            ITraderManager manager = App.Container.Resolve<ITraderManager>();
            UserDTO cUser = manager.GetUserById(App.Id);
            TransactionDTO transaction = new TransactionDTO()
            {
                Product = product.Name,

                User = cUser.FirstName + " " + cUser.LastName,
                Status = "Edit",
                Time = DateTime.Now,
                TimeOfChange = DateTime.Now
            };
            manager.AddTansaction(transaction);
            dataGrid.Items.Refresh();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = App.Container.Resolve<AddProduct>();
            addProduct.ShowDialog();
            dataGrid.Items.Refresh();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void transactionView(object sender, RoutedEventArgs e)
        {
            Widows.Transactions transaction = App.Container.Resolve<Widows.Transactions>();
            transaction.ShowDialog();
        }
    }
}
