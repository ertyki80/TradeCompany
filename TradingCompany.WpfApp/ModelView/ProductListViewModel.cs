using System.Collections.ObjectModel;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompanyDataTransfer;

namespace TradingCompany.WpfApp.ModelView
{
    public class ProductListViewModel
    {

        private ITraderManager _manager;
        private ObservableCollection<ProductDTO> _productList;

        public ObservableCollection<ProductDTO> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
            }
        }
        public ProductListViewModel(ITraderManager traderManager)
        {
            _manager = traderManager;
            Update();
        }

        public void Update()
        {
            var products = _manager.GetAllProduct();
            ProductList = new ObservableCollection<ProductDTO>(products);
        }

        public void Delete(ProductDTO product)
        {
            _manager.DeleteProduct(product.Id);
            Update();
        }
        
        public ProductDTO Buy(ProductDTO product)
        {
            product.CountInStock--;
            _manager.BuyProduct(product);
            Update();
            return product;

        }


    }
}
