using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using MaterialSkin.Controls;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.App
{
    public partial class MainForm : MaterialForm
    {
        private UserDTO _user = new UserDTO();
        private List<ProductDTO> _buyList = new List<ProductDTO>();
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(User).Assembly, typeof(Transaction).Assembly, typeof(Status).Assembly, typeof(Role).Assembly, typeof(Product).Assembly, typeof(Logs).Assembly, typeof(Category).Assembly)
            );

            return conf.CreateMapper();
        }


        private static readonly IMapper mapper = SetupMapper();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm.GetUser() != null)
            {


                _user = loginForm.GetUser();

                label1.Text += _user.FirstName + " "+ _user.LastName;
                label2.Text += _user.Email;

            }
            if (_user != null)
            {
                button1.Hide();
                button2.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrationForm register = new RegistrationForm();

            register.ShowDialog();
            if (register.GetUser() != null)
            {


                _user = register.GetUser();

                label1.Text += _user.FirstName + " "+ _user.LastName;
                label2.Text += _user.Email;
            }
            button1.Hide();
            button2.Hide();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Catalog catalog = new Catalog(_user);
            catalog.ShowDialog();
            int totalSum = 0;
            label3.Text = "Total : ";
            _buyList.AddRange(catalog.GetBuyedProducts());
            dataGridView1.Rows.Clear();
            foreach (var p in _buyList)
            {

                totalSum += p.Price;
                
                dataGridView1.Rows.Add(p.Id, p.Name, p.Price,  p.TimeOfAdd);
            }
            label3.Text += totalSum.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string seachText = textBox1.Text;
            Catalog catalog = new Catalog(_user);
            catalog.SearchString = seachText;
            catalog.ShowDialog();
            label3.Text = "Total : ";
            _buyList.AddRange(catalog.GetBuyedProducts());
            int totalSum = 0;
            dataGridView1.Rows.Clear();
            foreach (var p in _buyList)
            {
                totalSum += p.Price;
               
                dataGridView1.Rows.Add(p.Id, p.Name, p.Price, p.TimeOfAdd);
                
            }
            label3.Text += totalSum.ToString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
