using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using TradingCompany.BusinessLogic.Services;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.App
{
    public partial class Catalog : MaterialForm
    {
        private readonly User _currentUser;
        private IEnumerable<Product> _products = new List<Product>();
        private List<Product> _buyList = new List<Product>();
        //Services
        private ProductService _productService;
        private TransactionService _transactionService;
        private StatusService _statusService;
        private LogsService _logsService;
        public Catalog(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
        }

        private new void Update()
        {
            dataGridView1.Rows.Clear();
            var dataContext = new DataContext();

            _productService = new ProductService(dataContext);
            _transactionService = new TransactionService(dataContext);
            _statusService = new StatusService(dataContext);
            _logsService = new LogsService(dataContext);
            _products = _productService.GetAllProducts();

            foreach (var p in _products)
            {
                dataGridView1.Rows.Add(p.Id, p.Name, p.Price, p.CountInStock, p.TimeOfAdd);
            }

        }
        private void Catalog_Load(object sender, EventArgs e)
        {
            Update();



        }

        public List<Product> GetBuyedProducts()
        {
            return _buyList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show("Buy this item?","", buttons);
            if (dataGridView1.SelectedCells.Count > 0 && result == DialogResult.Yes)
            {
                var selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                var selectedRow = dataGridView1.Rows[selectedRowIndex];
                var id =selectedRow.Cells["Column5"].Value.ToString();
                var selectedProduct = _products.ToList().Find(u => u.Id == Convert.ToInt32(id));
                selectedProduct.CountInStock--;

                _productService.Update(Convert.ToInt32(id), selectedProduct);
                _transactionService.Create(new Transaction()
                {
                    Product = selectedProduct,
                    Status = _statusService.GetStatus(4),
                    Time = DateTime.Now,
                    TimeOfChange = DateTime.Now,
                    User = _currentUser,
                });
                _logsService.Create(new Logs(){Name = "Buy a new product with ID = "+ id + "." ,Time = DateTime.Now });
                _buyList.Add(selectedProduct);
                Update();


            }

        }   
    }
}
