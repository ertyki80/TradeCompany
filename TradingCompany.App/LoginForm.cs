using System;
using System.Drawing;
using MaterialSkin.Controls;
using TradingCompany.BusinessLogic.Helpers;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.App
{
    public partial class LoginForm : MaterialForm
    {
        private User _currentUser;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, System.EventArgs e)
        {
            textBox1.Text = "Login";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Password";
            textBox2.ForeColor = Color.Gray;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Login" || textBox2.Text == "Password")
            {
                textBox1.Text = "";
                
                textBox2.Text = "";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Login" || textBox2.Text == "Password")
            {
                textBox1.Text = "";

                textBox2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutorizeLogic authorizeLogic = new AutorizeLogic();
            var userExist = authorizeLogic.Login(textBox1.Text, textBox2.Text);
            if (userExist)
            {
                _currentUser = authorizeLogic.GetUser();

            }
            
        }
    }
}
