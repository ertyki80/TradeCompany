using AutoMapper;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;
using TradingCompany.DataAccess.Services;
using TradingCompanyDataTransfer;

namespace TradingCompany.App
{
    public partial class AddForm : MaterialForm
    {

        IProductManager _productManager;

        public int Option;
        public ProductDTO SelectProduct { get; set; }
        public AddForm(int option, IProductManager productManager)
        {
            _productManager = productManager;
            Option = option;
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            if (Option == 1 && SelectProduct != null)
            {

                textBox1.Text = SelectProduct.Name;
                textBox2.Text = SelectProduct.Price.ToString();
                textBox4.Text = SelectProduct.Description;
                textBox5.Text = SelectProduct.CountInStock.ToString();


            }
            else {
                textBox1.Text = "Name";
                textBox2.Text = "Price";
                
                textBox4.Text = "Description";
                textBox5.Text = "Count";
            }

            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
           
            textBox4.ForeColor = Color.Gray;
            textBox5.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (Option == 0)
            {
                ProductDTO product = new ProductDTO() { 
                    Name = textBox1.Text, 
                    Price = Convert.ToInt32(textBox2.Text), 
                    TimeOfAdd = DateTime.Now, 
                    CountInStock = Convert.ToInt32(textBox5.Text),
                    Description = textBox4.Text, 
                    
                };

                _productManager.AddProduct(product);
                this.Close();

            }
            else if (Option == 1 && SelectProduct != null)
            {
                string name = textBox1.Text;
                string price = textBox2.Text;
                string description = textBox4.Text;
                string countInStock = textBox5.Text;

                _productManager.DeleteProduct(SelectProduct.Id);
                if (name != "" && price != ""  && description != "" && countInStock != "")
                {

                    ProductDTO product = new ProductDTO
                    {
                        CountInStock = Convert.ToInt32(countInStock),
                        Description = description,
                        Name = name,
                        Price = Convert.ToInt32(price),
                        TimeOfAdd = DateTime.Now
                    };

                    _productManager.AddProduct(product);
                    this.Close();
                }

            }


        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Name")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "Description")
            {
                textBox4.Text = "";
            }

        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "Count")
            {
                textBox5.Text = "";
            }
        }
    }
}
