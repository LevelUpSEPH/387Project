using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResMart
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void adminLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "1234")
            {
                Stocks s = new Stocks();
                s.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Credentials wrong.");
        }

        private void button2_Click(object sender, EventArgs e) // Guest button
        {
            ReserveMenu res = new ReserveMenu();
            res.Show();
            this.Hide();
        }
    }
}
