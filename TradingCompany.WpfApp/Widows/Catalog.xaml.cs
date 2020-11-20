using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
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
    }
}
