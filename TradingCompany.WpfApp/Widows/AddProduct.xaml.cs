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
using System.Windows.Shapes;
using TradingCompany.BusinessLogic.Concrete;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompanyDataTransfer;

namespace TradingCompany.WpfApp.Widows
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        ITraderManager _managerT;
        IProductManager _managerP;
        int Id;
        public AddProduct(ITraderManager traderManager, IProductManager productManager)
        {
            _managerT = traderManager;
            _managerP = productManager;
            InitializeComponent();
            ComboBox();

        }
        public void AddParrameters(int id,string name,int Price,string description,int count)
        {
            Id = id;
            nameBox.Text = name;
            priceBox.Text = Price.ToString();
            descriptionBox.Text = description;
            countBox.Text = count.ToString();
        }
        void ComboBox()
        {
            List<CategoryDTO> categories = _managerT.GetAllCategories();
            List<string> categoryName = new List<string>();
            foreach (var category in categories)
            {
                categoryName.Add(category.Name);
            }
            combobox.ItemsSource = categoryName; 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = combobox.SelectedItem.ToString();
            var product = _managerT.GetAllProduct().Where(p => p.Id == Id).FirstOrDefault();
            if(product == null)
            {
                product = new ProductDTO();
            }   
            product.Name = nameBox.Text;
            product.Price = Convert.ToInt32(priceBox.Text);
            product.Description = descriptionBox.Text;
            product.CountInStock = Convert.ToInt32(countBox.Text);
            product.TimeOfAdd = DateTime.Now;
            var category = _managerT.GetAllCategories().Where(c => c.Name == categoryName).FirstOrDefault();
            product.Category = category;
            _managerP.UpdateProduct(product);

            UserDTO cUser = _managerT.GetUserById(App.Id);
            TransactionDTO transaction = new TransactionDTO()
            {
                Product = product.Name,

                User = cUser.FirstName + " " + cUser.LastName,
                Status = "AddProduct",
                Time = DateTime.Now,
                TimeOfChange = DateTime.Now
            };
            _managerT.AddTansaction(transaction);
        }
    }
}
