using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI2.WinForms;

namespace ResMart
{
    public partial class ReserveMenu : Form
    {
        public ReserveMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ege Sefertaş\Documents\ResMartDb.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Populate()
        {
            con.Open();
            String query = "select * from StockTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var dataSet = new DataSet();
            da.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            con.Close();
        }
        private void ReserveMenu_Load(object sender, EventArgs e)
        {
            Populate();
        }
        int n = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || res_id.Text == "")
                MessageBox.Show("Missing info");
            else
            {
                try
                {
                    int res_price = 0;
                    con.Open();
                    String query = "set" +res_price +" top(1) price from StockTbl where product_id = " + res_id.Text +""; // major error here, couldn't find a solution that works on this version
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    int total = Convert.ToInt32(textBox1.Text) * res_price;
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(guna2DataGridView1);
                    newRow.Cells[0].Value = n + 1;
                    newRow.Cells[1].Value = res_id.Text;
                    newRow.Cells[2].Value = res_price;
                    newRow.Cells[3].Value = textBox1.Text;
                    newRow.Cells[4].Value = total;
                    guna2DataGridView1.Rows.Add(newRow);
                    n++;
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e) // Checkout
        {
           if( printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
        }

        private void button1_Click(object sender, EventArgs e) // Remove, no point since you can't add anything
        {

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Bring this receipt to the nearest ResMart to pick up your items.", new Font("Segoe UI", 15, FontStyle.Bold),Brushes.Green,new Point(600));
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
