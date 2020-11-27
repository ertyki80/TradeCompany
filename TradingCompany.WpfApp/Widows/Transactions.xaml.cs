using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using TradingCompany.WpfApp.ModelView;
using TradingCompanyDataTransfer;

namespace TradingCompany.WpfApp.Widows
{
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transactions : Window
    {
        TransactionViewModel _transactionListViewModel;
        CollectionViewSource _transactionCollection;
        public List<TransactionDTO> TransactionList;
        public Transactions(TransactionViewModel vm)
        {
            TransactionList = new List<TransactionDTO>();
            _transactionCollection = (CollectionViewSource)(Resources["TransactionCollection"]);
            _transactionListViewModel = vm;
            DataContext = vm;
            InitializeComponent();
        }
    }
}
