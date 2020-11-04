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

namespace TradingCompany.WpfApp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            textBox1.Text = "";
            textBox1_Copy.Text = "";
            textBox1_Copy1.Text = "";
            textBox1_Copy2.Text = "";
            textBox1_Copy3.Text = "";

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.BorderBrush = Brushes.Red;

            }
            if (textBox1_Copy.Text.Length == 0)
            {
                textBox1_Copy.BorderBrush = Brushes.Red;
            }
            if (textBox1_Copy1.Text.Length == 0)
            {
                textBox1_Copy1.BorderBrush = Brushes.Red;
            }
            if (textBox1_Copy2.Text.Length == 0)
            {
                textBox1_Copy2.BorderBrush = Brushes.Red;
            }
            if (textBox1_Copy3.Text.Length == 0)
            {
                textBox1_Copy3.BorderBrush = Brushes.Red;
            }
            string login = textBox1.Text;
            string password = textBox1_Copy.Text;
        }
    }
}
