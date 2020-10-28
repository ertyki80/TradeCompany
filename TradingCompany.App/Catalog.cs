using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using MaterialSkin.Controls;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;
using TradingCompany.DataAccess.Services;
using TradingCompanyDataTransfer;

namespace TradingCompany.App
{
    public partial class Catalog : MaterialForm
    {
        

        //Services
        public ProductDTO selectedProduct;
        private readonly ITraderManager _manager;
        private List<ProductDTO> _products; 
        private List<ProductDTO> _buyList;
        UserDTO _currentUser;

        //-------------

        public string SearchString = "";

        public Catalog(ITraderManager manager,UserDTO user)
        {
            _manager = manager;
            InitializeComponent();
            Update();
        }

        private new void Update()
        {

            if (SearchString == "")
            {
                dataGridView1.Rows.Clear();
                _products = _manager.GetAllProduct();

                foreach (var p in _products)
                {
                    dataGridView1.Rows.Add(p.Id, p.Name, p.Price, p.CountInStock, p.TimeOfAdd);
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
                _products = _manager.GetAllProduct();

                foreach (var p in _products.Where(p => p.Name.Contains(SearchString)))
                {
                    dataGridView1.Rows.Add(p.Id, p.Name, p.Price, p.CountInStock, p.TimeOfAdd);
                }

            }
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            Update();


        }

        public List<ProductDTO> GetBuyedProducts()
        {
            return _buyList;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show("Buy this item?", "", buttons);

            if (dataGridView1.SelectedCells.Count > 0 && result == DialogResult.Yes)
            {
                var selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                var selectedRow = dataGridView1.Rows[selectedRowIndex];
                var id = selectedRow.Cells["Column5"].Value.ToString();
                selectedProduct = _products.ToList().Find(u => u.Id == Convert.ToInt32(id));
                selectedProduct.CountInStock--;
                _manager.BuyProduct(selectedProduct);

                var transaction = new TransactionDTO()
                {
                    Product = selectedProduct,
                    Status = _manager.GetStatusTransaction(4),
                    Time = DateTime.Now,
                    TimeOfChange = DateTime.Now,
                    User = _currentUser
                };
                _manager.AddTansaction(transaction);
                _buyList.Add(selectedProduct);
                Update();


            }

        }

        private void rowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                var selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                var selectedRow = dataGridView1.Rows[selectedRowIndex];
                var id = selectedRow.Cells["Column5"].Value.ToString();
                var selectedProduct = _products.ToList().Find(u => u.Id == Convert.ToInt32(id));
                _manager.DeleteProduct(Convert.ToInt32(id));
            }
        }

        private void buyManyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuyMany buyMany = new BuyMany();
            buyMany.ShowDialog();
            int count = buyMany.Count;
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show("Buy this item?", "", buttons);
            if (dataGridView1.SelectedCells.Count > 0 && result == DialogResult.Yes)
            {
                var selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                var selectedRow = dataGridView1.Rows[selectedRowIndex];
                var id = selectedRow.Cells["Column5"].Value.ToString();
                var selectedProduct = _products.ToList().Find(u => u.Id == Convert.ToInt32(id));
                selectedProduct.CountInStock -= count;
                _manager.BuyManyProducts(selectedProduct,count);
                selectedProduct.Price *= count;
                var transaction = new TransactionDTO()
                {
                    Product = selectedProduct,
                    Status = _manager.GetStatusTransaction(4),
                    Time = DateTime.Now,
                    TimeOfChange = DateTime.Now,
                    User = _currentUser
                };
                _manager.AddTansaction(transaction);

                _buyList.Add(selectedProduct);
                Update();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(0);
            addForm.ShowDialog();
            Update();


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(1);
            var selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            var selectedRow = dataGridView1.Rows[selectedRowIndex];
            var id = selectedRow.Cells["Column5"].Value.ToString();
            addForm.SelectProduct = _products.ToList().Find(u => u.Id == Convert.ToInt32(id));
            addForm.ShowDialog();
            Update();
        }
    }
}
