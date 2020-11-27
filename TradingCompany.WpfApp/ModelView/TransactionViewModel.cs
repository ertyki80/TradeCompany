using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompanyDataTransfer;

namespace TradingCompany.WpfApp.ModelView
{
    public class TransactionViewModel
    {
        private ITraderManager _manager;
        private ObservableCollection<TransactionDTO> _transactionList;
        public ObservableCollection<TransactionDTO> TransactionList
        {
            get { return _transactionList; }
            set
            {
                _transactionList = value;
            }
        }
        public TransactionViewModel(ITraderManager traderManager)
        {
            _manager = traderManager;
            Update();
        }

        public void Update()
        {
            var transactions = _manager.GetAllTransaction();
            TransactionList = new ObservableCollection<TransactionDTO>(transactions);
        }


        public ProductDTO Buy(ProductDTO product)
        {
            product.CountInStock--;
            _manager.BuyProduct(product);
            UserDTO cUser = _manager.GetUserById(App.Id);
            TransactionDTO transaction = new TransactionDTO() {
                Product = product.Id+" "+product.Name,
                User = cUser.FirstName+" " +cUser.LastName ,
                Time = DateTime.Now,
                Status = "Buy",
                TimeOfChange = DateTime.Now
                
            };
            _manager.AddTansaction(transaction);
            Update();
            return product;

        }


    }
}
