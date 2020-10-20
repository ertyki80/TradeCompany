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
using TradingCompany.BusinessLogic.Helpers;
using TradingCompany.DataAccess.Models;
using TradingCompany.DataAccess.Services;
using TradingCompanyDataTransfer;

namespace TradingCompany.App
{
    public partial class RegistrationForm : MaterialForm
    {
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(User).Assembly, typeof(Transaction).Assembly, typeof(Status).Assembly, typeof(Role).Assembly, typeof(Product).Assembly, typeof(Logs).Assembly, typeof(Category).Assembly)
            );

            return conf.CreateMapper();
        }


        private static readonly IMapper mapper = SetupMapper();

        private UserDTO _currenteUser;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = @"Login";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = @"Password";
            textBox2.ForeColor = Color.Gray;
            textBox3.Text = @"First Name";
            textBox3.ForeColor = Color.Gray;
            textBox4.Text = @"Last Name";
            textBox4.ForeColor = Color.Gray;
            textBox5.Text = @"Email";
            textBox5.ForeColor = Color.Gray;
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
            if (textBox2.Text == @"Password")
            {
                textBox2.Text = "";

            }
           

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == @"First Name")
            {
                textBox3.Text = "";

            }

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == @"Last Name")
            {
                textBox4.Text = "";

            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == @"Email")
            {
                textBox5.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var authorizeLogic = new AutorizeLogic();
            authorizeLogic.Registration(textBox1.Text,textBox2.Text,checkedListBox1.CheckedItems.ToString(),textBox3.Text,textBox4.Text,dateTimePicker1.Value,textBox5.Text);
            _currenteUser = new UserDTO();
            UserService userService = new UserService(mapper);
            _currenteUser = authorizeLogic.GetUser();
            userService.Create(_currenteUser);
            Console.WriteLine(@"Registration successful");
            this.Close();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public UserDTO GetUser()
        {
            return _currenteUser;
        }

    }
    
}
