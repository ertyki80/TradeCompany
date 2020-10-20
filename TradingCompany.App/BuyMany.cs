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

namespace TradingCompany.App
{
    public partial class BuyMany : MaterialForm
    {

        public int Count { get; set; }
        public BuyMany()
        {
            InitializeComponent();
        }

        private void BuyMany_Load(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Count = Convert.ToInt32(textBox1.Text);
            this.Close();
        }
    }
}
