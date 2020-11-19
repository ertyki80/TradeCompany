using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
using System.Windows.Shapes;
using TradingCompany.BusinessLogic.Concrete;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;
using TradingCompany.DataAccess.Services;
using TradingCompany.WpfApp.ModelView;
using TradingCompanyDataTransfer;

namespace TradingCompany.WpfApp
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        ProductListViewModel _productListViewModel;
        CollectionViewSource _productCollection;



        public Catalog(ProductListViewModel vm)
        {
            _productListViewModel = vm;
            DataContext = vm;
            InitializeComponent();

            _productCollection = (CollectionViewSource)(Resources["ProductCollection"]);
           

        }



    }
}
