using System;
using System.Drawing;
using MaterialSkin.Controls;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;
using System.Windows.Forms;
namespace TradingCompany.App
{
    public partial class LoginForm : MaterialForm
    {
        protected readonly IAuthManager _manager;

        public LoginForm(IAuthManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = @"Login";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = @"Password";
            textBox2.ForeColor = Color.Gray;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == @"Login" )
            {
                textBox1.Text = "";
                
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if ( textBox2.Text == @"Password")
            {
                textBox2.Text = "";
            }
        }
        private void doLogin()
        {
            if (_manager.Login(textBox1.Text, textBox2.Text))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            doLogin();
            
        }

        public int GetId()
        {
            return _manager.GetId(textBox1.Text);

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
}
